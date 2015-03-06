namespace DirectoryScaner.WFUI
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_cancelScan = new System.Windows.Forms.Button();
            this.button_scan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_directories = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog_file_path = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox_info = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_rights = new System.Windows.Forms.Label();
            this.label_owner = new System.Windows.Forms.Label();
            this.label_size = new System.Windows.Forms.Label();
            this.label_attributes = new System.Windows.Forms.Label();
            this.label_lastAccessDate = new System.Windows.Forms.Label();
            this.label_modificationDate = new System.Windows.Forms.Label();
            this.label_creationDate = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView_directory = new System.Windows.Forms.TreeView();
            this.button_file_path = new System.Windows.Forms.Button();
            this.label_file_path = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_file_path);
            this.groupBox1.Controls.Add(this.button_file_path);
            this.groupBox1.Controls.Add(this.button_cancelScan);
            this.groupBox1.Controls.Add(this.button_scan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_directories);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(960, 98);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // button_cancelScan
            // 
            this.button_cancelScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancelScan.Enabled = false;
            this.button_cancelScan.Location = new System.Drawing.Point(877, 67);
            this.button_cancelScan.Name = "button_cancelScan";
            this.button_cancelScan.Size = new System.Drawing.Size(75, 23);
            this.button_cancelScan.TabIndex = 3;
            this.button_cancelScan.Text = "Stop";
            this.button_cancelScan.UseVisualStyleBackColor = true;
            this.button_cancelScan.Click += new System.EventHandler(this.button_cancelScan_Click);
            // 
            // button_scan
            // 
            this.button_scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_scan.Location = new System.Drawing.Point(796, 67);
            this.button_scan.Name = "button_scan";
            this.button_scan.Size = new System.Drawing.Size(75, 23);
            this.button_scan.TabIndex = 1;
            this.button_scan.Text = "Start";
            this.button_scan.UseVisualStyleBackColor = true;
            this.button_scan.Click += new System.EventHandler(this.button_scan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination file:";
            // 
            // comboBox_directories
            // 
            this.comboBox_directories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_directories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_directories.FormattingEnabled = true;
            this.comboBox_directories.Location = new System.Drawing.Point(105, 22);
            this.comboBox_directories.Name = "comboBox_directories";
            this.comboBox_directories.Size = new System.Drawing.Size(847, 21);
            this.comboBox_directories.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose directory:";
            // 
            // saveFileDialog_file_path
            // 
            this.saveFileDialog_file_path.FileName = "Derictory Structure";
            this.saveFileDialog_file_path.Filter = "XML files|*.xml|All files|*.*";
            this.saveFileDialog_file_path.Title = "Save as";
            this.saveFileDialog_file_path.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_file_path_FileOk);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.richTextBox_info);
            this.groupBox3.Location = new System.Drawing.Point(7, 415);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(960, 86);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Additional information";
            // 
            // richTextBox_info
            // 
            this.richTextBox_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_info.Enabled = false;
            this.richTextBox_info.Location = new System.Drawing.Point(7, 20);
            this.richTextBox_info.Name = "richTextBox_info";
            this.richTextBox_info.Size = new System.Drawing.Size(947, 60);
            this.richTextBox_info.TabIndex = 0;
            this.richTextBox_info.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label_rights);
            this.groupBox2.Controls.Add(this.label_owner);
            this.groupBox2.Controls.Add(this.label_size);
            this.groupBox2.Controls.Add(this.label_attributes);
            this.groupBox2.Controls.Add(this.label_lastAccessDate);
            this.groupBox2.Controls.Add(this.label_modificationDate);
            this.groupBox2.Controls.Add(this.label_creationDate);
            this.groupBox2.Controls.Add(this.label_name);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(563, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 298);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // label_rights
            // 
            this.label_rights.AutoSize = true;
            this.label_rights.Location = new System.Drawing.Point(73, 111);
            this.label_rights.Name = "label_rights";
            this.label_rights.Size = new System.Drawing.Size(0, 13);
            this.label_rights.TabIndex = 15;
            // 
            // label_owner
            // 
            this.label_owner.AutoSize = true;
            this.label_owner.Location = new System.Drawing.Point(54, 98);
            this.label_owner.Name = "label_owner";
            this.label_owner.Size = new System.Drawing.Size(0, 13);
            this.label_owner.TabIndex = 14;
            // 
            // label_size
            // 
            this.label_size.AutoSize = true;
            this.label_size.Location = new System.Drawing.Point(43, 85);
            this.label_size.Name = "label_size";
            this.label_size.Size = new System.Drawing.Size(0, 13);
            this.label_size.TabIndex = 13;
            // 
            // label_attributes
            // 
            this.label_attributes.AutoSize = true;
            this.label_attributes.Location = new System.Drawing.Point(67, 72);
            this.label_attributes.Name = "label_attributes";
            this.label_attributes.Size = new System.Drawing.Size(0, 13);
            this.label_attributes.TabIndex = 12;
            // 
            // label_lastAccessDate
            // 
            this.label_lastAccessDate.AutoSize = true;
            this.label_lastAccessDate.Location = new System.Drawing.Point(104, 59);
            this.label_lastAccessDate.Name = "label_lastAccessDate";
            this.label_lastAccessDate.Size = new System.Drawing.Size(0, 13);
            this.label_lastAccessDate.TabIndex = 11;
            // 
            // label_modificationDate
            // 
            this.label_modificationDate.AutoSize = true;
            this.label_modificationDate.Location = new System.Drawing.Point(104, 46);
            this.label_modificationDate.Name = "label_modificationDate";
            this.label_modificationDate.Size = new System.Drawing.Size(0, 13);
            this.label_modificationDate.TabIndex = 10;
            // 
            // label_creationDate
            // 
            this.label_creationDate.AutoSize = true;
            this.label_creationDate.Location = new System.Drawing.Point(86, 33);
            this.label_creationDate.Name = "label_creationDate";
            this.label_creationDate.Size = new System.Drawing.Size(0, 13);
            this.label_creationDate.TabIndex = 9;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(42, 20);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(0, 13);
            this.label_name.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Your rights:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Owner:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Size:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Attributes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Last access date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Modification date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Creation date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // treeView_directory
            // 
            this.treeView_directory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_directory.Location = new System.Drawing.Point(10, 117);
            this.treeView_directory.Name = "treeView_directory";
            this.treeView_directory.Size = new System.Drawing.Size(550, 292);
            this.treeView_directory.TabIndex = 5;
            this.treeView_directory.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_directory_NodeMouseClick);
            // 
            // button_file_path
            // 
            this.button_file_path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_file_path.Location = new System.Drawing.Point(715, 67);
            this.button_file_path.Name = "button_file_path";
            this.button_file_path.Size = new System.Drawing.Size(75, 23);
            this.button_file_path.TabIndex = 4;
            this.button_file_path.Text = "Save to...";
            this.button_file_path.UseVisualStyleBackColor = true;
            this.button_file_path.Click += new System.EventHandler(this.button_file_path_Click);
            // 
            // label_file_path
            // 
            this.label_file_path.AutoSize = true;
            this.label_file_path.Location = new System.Drawing.Point(102, 49);
            this.label_file_path.Name = "label_file_path";
            this.label_file_path.Size = new System.Drawing.Size(65, 13);
            this.label_file_path.TabIndex = 5;
            this.label_file_path.Text = "not selected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 511);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.treeView_directory);
            this.MinimumSize = new System.Drawing.Size(990, 550);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Directory Scaner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_scan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_directories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_file_path;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox_info;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView_directory;
        private System.Windows.Forms.Button button_cancelScan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_lastAccessDate;
        private System.Windows.Forms.Label label_modificationDate;
        private System.Windows.Forms.Label label_creationDate;
        private System.Windows.Forms.Label label_attributes;
        private System.Windows.Forms.Label label_size;
        private System.Windows.Forms.Label label_owner;
        private System.Windows.Forms.Label label_rights;
        private System.Windows.Forms.Button button_file_path;
        private System.Windows.Forms.Label label_file_path;

    }
}

