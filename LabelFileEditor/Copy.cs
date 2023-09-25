using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AXLabelFileEditor
{
    public partial class Copy : Form
    {
        public LabelFile LabelFile { get; }
        
        public Copy(LabelFile labelFile)
        {
            LabelFile = labelFile;

            InitializeComponent();

            this.Load += Copy_Load;
            this.Text = $"Copy to {LabelFile.Metadata.Name}";
        }

        private void Copy_Load(object sender, EventArgs e)
        {
            foreach (var file in LabelFileHelper.GetAllLanguageFilesFromMetadata(LabelFile.Metadata.MetadataPath))
            {
                LabelFileMetadata labelFileMetadata = LabelFileMetadata.FromMetadataFile(file);

                if ((labelFileMetadata.LabelFileId == LabelFile.Metadata.LabelFileId && labelFileMetadata.Language != LabelFile.Metadata.Language) ||
                    (labelFileMetadata.LabelFileId != LabelFile.Metadata.LabelFileId ))
                {
                    sourceComboBox.Items.Add(labelFileMetadata.Name);
                }
            }

            labelsGridView.AutoGenerateColumns = false;
            labelsGridView.AutoSize = true;
            labelsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            labelsGridView.AllowUserToDeleteRows = false;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Id";
            column.Name = "Id";
            column.Width = 200;
            labelsGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Value";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.Name = "Value";
            labelsGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Description";
            column.Name = "Description";
            column.Width = 100;
            labelsGridView.Columns.Add(column);
        }

        private void sourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourceComboBox.SelectedIndex != -1)
            {
                // Get metadata file
                var metadataFileName = sourceComboBox.Items[sourceComboBox.SelectedIndex].ToString();
                var fullMetadataFile = Path.Combine(Path.GetDirectoryName(LabelFile.Metadata.MetadataPath), metadataFileName + ".xml");

                var sourceLabelFile = new LabelFile(fullMetadataFile);

                infoLabel.Text = $"Select the labels you want to create in {LabelFile.Metadata.Name} from {sourceLabelFile.Metadata.Name}";

                sourceLabelFile.Read();

                var comparison = LabelFileHelper.CompareSourceToDestination(sourceLabelFile, LabelFile);

                labelsGridView.DataSource = new BindingList<Label>(comparison.ToList());
                labelsGridView.Update();
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            int toBeCopiedTotal = labelsGridView.SelectedRows.Count;

            if (MessageBox.Show($"A total of {toBeCopiedTotal} label(s) will be copied into {LabelFile.Metadata.Name}. Do you want to continue?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
                foreach(DataGridViewRow row in labelsGridView.SelectedRows)
                {
                    Label label = (Label)row.DataBoundItem;

                    LabelFile.AddLabel(label);
                }

                DialogResult = DialogResult.Yes;
                this.Close();
                return;
            }

            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
