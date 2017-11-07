/*This file is part of ProtoMiddler

ProtoMiddler is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

Foobar is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
 
Author: Jon Boyd
Email: jboyd[at]securityinnovation[dot]com

 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

[assembly: Fiddler.RequiredVersion("2.3.0.0")]
//
// C:\Program Files (x86)\protobuf-net\protobuf-net-VS9>type C:\me\ProtoBufTest\DecodedAccount.txt | protoc.exe --encode=Account --proto_path=C:\me\ProtoBufTest C:\me\ProtoBufTest\Account.proto > c:\me\account.bin
//

namespace ProtoMiddler
{
    public class ProtoBufResponseInspector : Inspector2, IResponseInspector2
    {

        //private RichTextBox _myControl;
        private ProtoBufInspectorControl _myControl;
        private byte[] _entityBody;

        public override void AssignSession(Session oSession)
        {

            byte[] protobufBytes = null;

            if (oSession.oResponse["Content-Type"].ToLower().Contains("protobuf"))
            {
                protobufBytes = oSession.responseBodyBytes;

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
            get { return true; }
            set { m_bReadOnly = value; }
        }

        HTTPResponseHeaders m_Headers;


        public HTTPResponseHeaders headers
        {
            get
            {
                return m_Headers;
            }
            set
            {
                m_Headers = value;
            }
        }
    }
}
