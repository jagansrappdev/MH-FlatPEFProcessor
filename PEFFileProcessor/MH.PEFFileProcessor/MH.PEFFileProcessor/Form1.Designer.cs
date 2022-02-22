
namespace MH.PEFFileProcessor
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCountLines = new System.Windows.Forms.Button();
            this.btnProcessPEFtoDB = new System.Windows.Forms.Button();
            this.rtb_Status = new System.Windows.Forms.RichTextBox();
            this.btnSplitFile = new System.Windows.Forms.Button();
            this.btnProcessAllfiles = new System.Windows.Forms.Button();
            this.btnCreateDbTbl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCountLines
            // 
            this.btnCountLines.Location = new System.Drawing.Point(23, 65);
            this.btnCountLines.Name = "btnCountLines";
            this.btnCountLines.Size = new System.Drawing.Size(123, 73);
            this.btnCountLines.TabIndex = 0;
            this.btnCountLines.Text = "Count total Lines";
            this.btnCountLines.UseVisualStyleBackColor = true;
            this.btnCountLines.Click += new System.EventHandler(this.btnCountLines_Click);
            // 
            // btnProcessPEFtoDB
            // 
            this.btnProcessPEFtoDB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProcessPEFtoDB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProcessPEFtoDB.Location = new System.Drawing.Point(174, 65);
            this.btnProcessPEFtoDB.Name = "btnProcessPEFtoDB";
            this.btnProcessPEFtoDB.Size = new System.Drawing.Size(111, 73);
            this.btnProcessPEFtoDB.TabIndex = 1;
            this.btnProcessPEFtoDB.Text = "Process PEF to DB";
            this.btnProcessPEFtoDB.UseVisualStyleBackColor = false;
            this.btnProcessPEFtoDB.Click += new System.EventHandler(this.btnProcessPEFtoDB_Click);
            // 
            // rtb_Status
            // 
            this.rtb_Status.Location = new System.Drawing.Point(23, 155);
            this.rtb_Status.Name = "rtb_Status";
            this.rtb_Status.Size = new System.Drawing.Size(383, 146);
            this.rtb_Status.TabIndex = 2;
            this.rtb_Status.Text = "";
            // 
            // btnSplitFile
            // 
            this.btnSplitFile.Location = new System.Drawing.Point(567, 65);
            this.btnSplitFile.Name = "btnSplitFile";
            this.btnSplitFile.Size = new System.Drawing.Size(105, 74);
            this.btnSplitFile.TabIndex = 3;
            this.btnSplitFile.Text = "Split File";
            this.btnSplitFile.UseVisualStyleBackColor = true;
            this.btnSplitFile.Click += new System.EventHandler(this.btnSplitFile_Click);
            // 
            // btnProcessAllfiles
            // 
            this.btnProcessAllfiles.Location = new System.Drawing.Point(307, 65);
            this.btnProcessAllfiles.Name = "btnProcessAllfiles";
            this.btnProcessAllfiles.Size = new System.Drawing.Size(99, 73);
            this.btnProcessAllfiles.TabIndex = 4;
            this.btnProcessAllfiles.Text = "Process All Files";
            this.btnProcessAllfiles.UseVisualStyleBackColor = true;
            // 
            // btnCreateDbTbl
            // 
            this.btnCreateDbTbl.Location = new System.Drawing.Point(23, 324);
            this.btnCreateDbTbl.Name = "btnCreateDbTbl";
            this.btnCreateDbTbl.Size = new System.Drawing.Size(135, 80);
            this.btnCreateDbTbl.TabIndex = 5;
            this.btnCreateDbTbl.Text = "Create d/b tbl from ORMLite";
            this.btnCreateDbTbl.UseVisualStyleBackColor = true;
            this.btnCreateDbTbl.Click += new System.EventHandler(this.btnCreateDbTbl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 689);
            this.Controls.Add(this.btnCreateDbTbl);
            this.Controls.Add(this.btnProcessAllfiles);
            this.Controls.Add(this.btnSplitFile);
            this.Controls.Add(this.rtb_Status);
            this.Controls.Add(this.btnProcessPEFtoDB);
            this.Controls.Add(this.btnCountLines);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCountLines;
        private System.Windows.Forms.Button btnProcessPEFtoDB;
        private System.Windows.Forms.RichTextBox rtb_Status;
        private System.Windows.Forms.Button btnSplitFile;
        private System.Windows.Forms.Button btnProcessAllfiles;
        private System.Windows.Forms.Button btnCreateDbTbl;
    }
}

