namespace AXLabelFileEditor
{
    partial class LabelEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.compareButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.emptyValueCheckBox = new System.Windows.Forms.CheckBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelsGridView = new System.Windows.Forms.DataGridView();
            this.labelFileWatcher = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelFileWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.compareButton);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.copyButton);
            this.panel1.Controls.Add(this.removeButton);
            this.panel1.Controls.Add(this.newButton);
            this.panel1.Controls.Add(this.searchBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 133);
            this.panel1.TabIndex = 0;
            // 
            // compareButton
            // 
            this.compareButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.compareButton.Location = new System.Drawing.Point(465, 64);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(123, 51);
            this.compareButton.TabIndex = 6;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.emptyValueCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(596, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // emptyValueCheckBox
            // 
            this.emptyValueCheckBox.AutoSize = true;
            this.emptyValueCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emptyValueCheckBox.Location = new System.Drawing.Point(26, 31);
            this.emptyValueCheckBox.Name = "emptyValueCheckBox";
            this.emptyValueCheckBox.Size = new System.Drawing.Size(157, 20);
            this.emptyValueCheckBox.TabIndex = 0;
            this.emptyValueCheckBox.Text = "Only with empty value";
            this.emptyValueCheckBox.UseVisualStyleBackColor = true;
            this.emptyValueCheckBox.CheckedChanged += new System.EventHandler(this.emptyValueCheckBox_CheckedChanged);
            // 
            // copyButton
            // 
            this.copyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.copyButton.Location = new System.Drawing.Point(336, 64);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(123, 51);
            this.copyButton.TabIndex = 4;
            this.copyButton.Text = "Copy from language";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeButton.Location = new System.Drawing.Point(161, 64);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(123, 51);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // newButton
            // 
            this.newButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newButton.Location = new System.Drawing.Point(16, 64);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(117, 51);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(72, 21);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(477, 24);
            this.searchBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search:";
            // 
            // labelsGridView
            // 
            this.labelsGridView.AllowUserToAddRows = false;
            this.labelsGridView.AllowUserToDeleteRows = false;
            this.labelsGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelsGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.labelsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.labelsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.labelsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelsGridView.Location = new System.Drawing.Point(0, 133);
            this.labelsGridView.Name = "labelsGridView";
            this.labelsGridView.RowHeadersWidth = 51;
            this.labelsGridView.RowTemplate.Height = 24;
            this.labelsGridView.Size = new System.Drawing.Size(1053, 537);
            this.labelsGridView.TabIndex = 1;
            // 
            // labelFileWatcher
            // 
            this.labelFileWatcher.EnableRaisingEvents = true;
            this.labelFileWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.labelFileWatcher.SynchronizingObject = this;
            // 
            // LabelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 670);
            this.Controls.Add(this.labelsGridView);
            this.Controls.Add(this.panel1);
            this.Name = "LabelEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelFileWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.DataGridView labelsGridView;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox emptyValueCheckBox;
        private System.Windows.Forms.Button compareButton;
        private System.IO.FileSystemWatcher labelFileWatcher;
    }
}

