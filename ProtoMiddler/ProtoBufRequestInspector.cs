﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

//
// C:\Program Files (x86)\protobuf-net\protobuf-net-VS9>type C:\me\ProtoBufTest\DecodedAccount.txt | protoc.exe --encode=Account --proto_path=C:\me\ProtoBufTest C:\me\ProtoBufTest\Account.proto > c:\me\account.bin
//

namespace ProtoMiddler
{
    public class ProtoBufRequestInspector :  Inspector2, IRequestInspector2
    {
        private ProtoBufInspectorControl _myControl;
        private byte[] _entityBody;

        public override void AssignSession(Session oSession)
        {

            byte[] protobufBytes = null;

            if (oSession.oRequest["Content-Type"].ToLower().Contains("protobuf"))
            {
                protobufBytes = oSession.requestBodyBytes;

                _entityBody = protobufBytes;
                _myControl.Data = ProtoBufUtil.DecodeRaw(protobufBytes);
                _myControl.ProtobufBytes = protobufBytes;
                
            }
            else
            {
                _myControl.Data = "NA";  // oSession.requestBodyBytes
            }
        }

        public override void AddToTab(TabPage o)
        {
            _entityBody = new byte[2048];
            _myControl = new ProtoBufInspectorControl();
            o.Text = "ProtoBuf";
            o.Controls.Add(_myControl);
            o.Controls[0].Dock = DockStyle.Fill;
        }

        public override int GetOrder()
        {
            return 0;
        }

        public void Clear()
        {
            _myControl.Data = string.Empty;
        }

        public byte[] body
        {
            get 
            {
                if (_myControl.Text.CompareTo("NA") != 0)
                {
                    return _myControl.Encode();
                    //return ProtoBufUtil.Encode(_myControl.Data);
                    // return the protobuf encoded
                }
                return _entityBody; 
            }
            set 
            {
                this._entityBody = value; 
            }
        }

        public bool bDirty
        {
            get { return true; }
        }

        bool m_bReadOnly = false;

        public bool bReadOnly
        {
            get { return m_bReadOnly; }
            set { m_bReadOnly = value; }
        }


        HTTPRequestHeaders m_RequestHeaders;

        HTTPRequestHeaders IRequestInspector2.headers
        {
            get
            {
                return m_RequestHeaders;
            }
            set
            {
                m_RequestHeaders = value;
            }
        }
    }
}
