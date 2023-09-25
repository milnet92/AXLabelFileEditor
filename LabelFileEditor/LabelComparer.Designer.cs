namespace AXLabelFileEditor
{
    partial class LabelComparer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mergeToRightButton = new System.Windows.Forms.Button();
            this.mergeToLeftButton = new System.Windows.Forms.Button();
            this.changedDiffCheckBox = new System.Windows.Forms.CheckBox();
            this.missingDiffCheckBox = new System.Windows.Forms.CheckBox();
            this.swapButton = new System.Windows.Forms.Button();
            this.showDiffCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rightComboBox = new System.Windows.Forms.ComboBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.leftComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.leftDataGridView = new System.Windows.Forms.DataGridView();
            this.rightDataGridView = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.changedRight = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.missingRight = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.changedLeft = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.missingLeft = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightDataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.changedDiffCheckBox);
            this.panel1.Controls.Add(this.missingDiffCheckBox);
            this.panel1.Controls.Add(this.swapButton);
            this.panel1.Controls.Add(this.showDiffCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rightComboBox);
            this.panel1.Controls.Add(this.infoLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.leftComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1149, 91);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.mergeToRightButton);
            this.panel4.Controls.Add(this.mergeToLeftButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(949, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 91);
            this.panel4.TabIndex = 13;
            // 
            // mergeToRightButton
            // 
            this.mergeToRightButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mergeToRightButton.Enabled = false;
            this.mergeToRightButton.Location = new System.Drawing.Point(32, 49);
            this.mergeToRightButton.Name = "mergeToRightButton";
            this.mergeToRightButton.Size = new System.Drawing.Size(136, 33);
            this.mergeToRightButton.TabIndex = 14;
            this.mergeToRightButton.Text = "Merge to right ->";
            this.mergeToRightButton.UseVisualStyleBackColor = true;
            this.mergeToRightButton.Click += new System.EventHandler(this.mergeToRightButton_Click);
            // 
            // mergeToLeftButton
            // 
            this.mergeToLeftButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mergeToLeftButton.Enabled = false;
            this.mergeToLeftButton.Location = new System.Drawing.Point(32, 9);
            this.mergeToLeftButton.Name = "mergeToLeftButton";
            this.mergeToLeftButton.Size = new System.Drawing.Size(136, 33);
            this.mergeToLeftButton.TabIndex = 13;
            this.mergeToLeftButton.Text = "<- Merge to left";
            this.mergeToLeftButton.UseVisualStyleBackColor = true;
            this.mergeToLeftButton.Click += new System.EventHandler(this.mergeToLeftButton_Click);
            // 
            // changedDiffCheckBox
            // 
            this.changedDiffCheckBox.AutoSize = true;
            this.changedDiffCheckBox.Checked = true;
            this.changedDiffCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changedDiffCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changedDiffCheckBox.Location = new System.Drawing.Point(867, 62);
            this.changedDiffCheckBox.Name = "changedDiffCheckBox";
            this.changedDiffCheckBox.Size = new System.Drawing.Size(84, 20);
            this.changedDiffCheckBox.TabIndex = 10;
            this.changedDiffCheckBox.Text = "Changed";
            this.changedDiffCheckBox.UseVisualStyleBackColor = true;
            this.changedDiffCheckBox.CheckedChanged += new System.EventHandler(this.changedDiffCheckBox_CheckedChanged);
            // 
            // missingDiffCheckBox
            // 
            this.missingDiffCheckBox.AutoSize = true;
            this.missingDiffCheckBox.Checked = true;
            this.missingDiffCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.missingDiffCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.missingDiffCheckBox.Location = new System.Drawing.Point(867, 38);
            this.missingDiffCheckBox.Name = "missingDiffCheckBox";
            this.missingDiffCheckBox.Size = new System.Drawing.Size(75, 20);
            this.missingDiffCheckBox.TabIndex = 9;
            this.missingDiffCheckBox.Text = "Missing";
            this.missingDiffCheckBox.UseVisualStyleBackColor = true;
            this.missingDiffCheckBox.CheckedChanged += new System.EventHandler(this.missingDiffCheckBox_CheckedChanged);
            // 
            // swapButton
            // 
            this.swapButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swapButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.swapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swapButton.Location = new System.Drawing.Point(358, 23);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(44, 24);
            this.swapButton.TabIndex = 8;
            this.swapButton.Text = "«-»";
            this.swapButton.UseVisualStyleBackColor = true;
            this.swapButton.Click += new System.EventHandler(this.swapButton_Click);
            // 
            // showDiffCheckBox
            // 
            this.showDiffCheckBox.AutoSize = true;
            this.showDiffCheckBox.Checked = true;
            this.showDiffCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDiffCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showDiffCheckBox.Location = new System.Drawing.Point(783, 12);
            this.showDiffCheckBox.Name = "showDiffCheckBox";
            this.showDiffCheckBox.Size = new System.Drawing.Size(159, 20);
            this.showDiffCheckBox.TabIndex = 7;
            this.showDiffCheckBox.Text = "Show only differences";
            this.showDiffCheckBox.UseVisualStyleBackColor = true;
            this.showDiffCheckBox.CheckedChanged += new System.EventHandler(this.showDiffCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Right:";
            // 
            // rightComboBox
            // 
            this.rightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rightComboBox.FormattingEnabled = true;
            this.rightComboBox.Location = new System.Drawing.Point(480, 22);
            this.rightComboBox.Name = "rightComboBox";
            this.rightComboBox.Size = new System.Drawing.Size(257, 24);
            this.rightComboBox.TabIndex = 5;
            this.rightComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 63);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 16);
            this.infoLabel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Left:";
            // 
            // leftComboBox
            // 
            this.leftComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftComboBox.FormattingEnabled = true;
            this.leftComboBox.Location = new System.Drawing.Point(68, 23);
            this.leftComboBox.Name = "leftComboBox";
            this.leftComboBox.Size = new System.Drawing.Size(257, 24);
            this.leftComboBox.TabIndex = 2;
            this.leftComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 574);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1149, 49);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1149, 483);
            this.panel3.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel9);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel10);
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1149, 483);
            this.splitContainer1.SplitterDistance = 488;
            this.splitContainer1.TabIndex = 0;
            // 
            // leftDataGridView
            // 
            this.leftDataGridView.AllowUserToAddRows = false;
            this.leftDataGridView.AllowUserToDeleteRows = false;
            this.leftDataGridView.AllowUserToResizeRows = false;
            this.leftDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.leftDataGridView.CausesValidation = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.leftDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.leftDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.leftDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.leftDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftDataGridView.Location = new System.Drawing.Point(0, 0);
            this.leftDataGridView.Name = "leftDataGridView";
            this.leftDataGridView.ReadOnly = true;
            this.leftDataGridView.RowHeadersWidth = 51;
            this.leftDataGridView.RowTemplate.Height = 24;
            this.leftDataGridView.Size = new System.Drawing.Size(488, 456);
            this.leftDataGridView.TabIndex = 0;
            this.leftDataGridView.SelectionChanged += new System.EventHandler(this.SelectionChanged);
            // 
            // rightDataGridView
            // 
            this.rightDataGridView.AllowUserToAddRows = false;
            this.rightDataGridView.AllowUserToDeleteRows = false;
            this.rightDataGridView.AllowUserToResizeRows = false;
            this.rightDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightDataGridView.CausesValidation = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rightDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.rightDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rightDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.rightDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightDataGridView.Location = new System.Drawing.Point(0, 0);
            this.rightDataGridView.Name = "rightDataGridView";
            this.rightDataGridView.ReadOnly = true;
            this.rightDataGridView.RowHeadersWidth = 51;
            this.rightDataGridView.RowTemplate.Height = 24;
            this.rightDataGridView.Size = new System.Drawing.Size(657, 456);
            this.rightDataGridView.TabIndex = 1;
            this.rightDataGridView.SelectionChanged += new System.EventHandler(this.SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.changedLeft);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.missingLeft);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(488, 27);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.changedRight);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.missingRight);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(657, 27);
            this.panel6.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.leftDataGridView);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 27);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(488, 456);
            this.panel9.TabIndex = 2;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.rightDataGridView);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 27);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(657, 456);
            this.panel10.TabIndex = 3;
            // 
            // changedRight
            // 
            this.changedRight.AutoSize = true;
            this.changedRight.BackColor = System.Drawing.Color.Yellow;
            this.changedRight.Location = new System.Drawing.Point(222, 5);
            this.changedRight.Name = "changedRight";
            this.changedRight.Size = new System.Drawing.Size(14, 16);
            this.changedRight.TabIndex = 11;
            this.changedRight.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Changed:";
            // 
            // missingRight
            // 
            this.missingRight.AutoSize = true;
            this.missingRight.BackColor = System.Drawing.Color.Red;
            this.missingRight.Location = new System.Drawing.Point(65, 5);
            this.missingRight.Name = "missingRight";
            this.missingRight.Size = new System.Drawing.Size(14, 16);
            this.missingRight.TabIndex = 9;
            this.missingRight.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Missing:";
            // 
            // changedLeft
            // 
            this.changedLeft.AutoSize = true;
            this.changedLeft.BackColor = System.Drawing.Color.Yellow;
            this.changedLeft.Location = new System.Drawing.Point(217, 5);
            this.changedLeft.Name = "changedLeft";
            this.changedLeft.Size = new System.Drawing.Size(14, 16);
            this.changedLeft.TabIndex = 11;
            this.changedLeft.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Changed:";
            // 
            // missingLeft
            // 
            this.missingLeft.AutoSize = true;
            this.missingLeft.BackColor = System.Drawing.Color.Red;
            this.missingLeft.Location = new System.Drawing.Point(65, 5);
            this.missingLeft.Name = "missingLeft";
            this.missingLeft.Size = new System.Drawing.Size(14, 16);
            this.missingLeft.TabIndex = 9;
            this.missingLeft.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Missing:";
            // 
            // LabelComparer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 623);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LabelComparer";
            this.Text = "Copy";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightDataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox leftComboBox;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox rightComboBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView leftDataGridView;
        private System.Windows.Forms.DataGridView rightDataGridView;
        private System.Windows.Forms.CheckBox showDiffCheckBox;
        private System.Windows.Forms.Button swapButton;
        private System.Windows.Forms.CheckBox changedDiffCheckBox;
        private System.Windows.Forms.CheckBox missingDiffCheckBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button mergeToRightButton;
        private System.Windows.Forms.Button mergeToLeftButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label changedLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label missingLeft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label changedRight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label missingRight;
        private System.Windows.Forms.Label label10;
    }
}