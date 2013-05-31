using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProtoMiddler
{
    public partial class ProtoBufInspectorControl : UserControl
    {
        public ProtoBufInspectorControl()
        {
            InitializeComponent();
            this.ProtoFile = string.Empty;
            this.MessageType = string.Empty;
        }

        public byte[] ProtobufBytes
        {
            get;
            set;
        }

        public string Data
        {
            get
            {
                return this.rtbData.Text;
            }

            set
            {
                this.rtbData.Text = value;
            }
        }

        public string ProtoFile;
        public string MessageType;

        public byte[] Encode()
        {
            if (string.IsNullOrEmpty(this.ProtoFile) || string.IsNullOrEmpty(this.MessageType))
            {
                return ProtobufBytes;
            }

            // try to encode using these things...

            return ProtoBufUtil.EncodeWithProto(this.Data, this.MessageType, this.ProtoFile);
        }

        private void bnBrowse_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                txtProtoFile.Text = openFileDialog1.FileName;

                this.ProtoFile = txtProtoFile.Text.Trim();
                // also parse the proto file to fill in the cbType combo box
                if (File.Exists(this.ProtoFile))
                {
                    string rawProtoFile = File.ReadAllText(this.ProtoFile);
                    string[] tokens = rawProtoFile.Split(" \t\n{},".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int x = 0; x < tokens.Length; x++)
                    {
                        if (tokens[x].CompareTo("message") == 0)
                        {
                            string t = tokens[x + 1];
                            cbType.Items.Add(t);
                            cbType.Enabled = true;
                        }
                    }
                }

            }
        }

        private void bnDecodeAs_Click(object sender, EventArgs e)
        {
            this.MessageType = (string) cbType.SelectedItem;
            this.ProtoFile = txtProtoFile.Text;

            this.Data = ProtoBufUtil.DecodeWithProto(this.ProtobufBytes, this.MessageType, this.ProtoFile);
        }
    }
}
