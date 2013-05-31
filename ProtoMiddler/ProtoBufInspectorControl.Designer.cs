namespace ProtoMiddler
{
    partial class ProtoBufInspectorControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbData = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProtoFile = new System.Windows.Forms.TextBox();
            this.bnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.bnDecodeAs = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbData
            // 
            this.rtbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbData.Location = new System.Drawing.Point(0, 0);
            this.rtbData.Name = "rtbData";
            this.rtbData.Size = new System.Drawing.Size(849, 315);
            this.rtbData.TabIndex = 0;
            this.rtbData.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Protofile:";
            // 
            // txtProtoFile
            // 
            this.txtProtoFile.Location = new System.Drawing.Point(102, 13);
            this.txtProtoFile.Name = "txtProtoFile";
            this.txtProtoFile.Size = new System.Drawing.Size(576, 20);
            this.txtProtoFile.TabIndex = 2;
            // 
            // bnBrowse
            // 
            this.bnBrowse.Location = new System.Drawing.Point(693, 13);
            this.bnBrowse.Name = "bnBrowse";
            this.bnBrowse.Size = new System.Drawing.Size(75, 23);
            this.bnBrowse.TabIndex = 3;
            this.bnBrowse.Text = "Browse...";
            this.bnBrowse.UseVisualStyleBackColor = true;
            this.bnBrowse.Click += new System.EventHandler(this.bnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Proto Files|*.proto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Type:";
            // 
            // cbType
            // 
            this.cbType.Enabled = false;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(102, 39);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(576, 21);
            this.cbType.TabIndex = 5;
            // 
            // bnDecodeAs
            // 
            this.bnDecodeAs.Location = new System.Drawing.Point(693, 42);
            this.bnDecodeAs.Name = "bnDecodeAs";
            this.bnDecodeAs.Size = new System.Drawing.Size(75, 23);
            this.bnDecodeAs.TabIndex = 6;
            this.bnDecodeAs.Text = "Decode As";
            this.bnDecodeAs.UseVisualStyleBackColor = true;
            this.bnDecodeAs.Click += new System.EventHandler(this.bnDecodeAs_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.bnDecodeAs);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cbType);
            this.splitContainer1.Panel1.Controls.Add(this.txtProtoFile);
            this.splitContainer1.Panel1.Controls.Add(this.bnBrowse);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbData);
            this.splitContainer1.Size = new System.Drawing.Size(849, 401);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 7;
            // 
            // ProtoBufInspectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ProtoBufInspectorControl";
            this.Size = new System.Drawing.Size(849, 401);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProtoFile;
        private System.Windows.Forms.Button bnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button bnDecodeAs;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
