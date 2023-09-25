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
using System.Windows.Input;

namespace AXLabelFileEditor
{
    public partial class LabelComparer : Form
    {
        public LabelFile LabelFile { get; }

        private LabelFile leftLabelFile;
        private LabelFile rightLabelFile;
        private readonly LabelEditor labelEditor;

        public bool NeedsToReload = false;

        public LabelComparer(LabelFile labelFile, LabelEditor labelEditor = null)
        {
            LabelFile = labelFile;
            this.labelEditor = labelEditor;

            InitializeComponent();

            this.Load += Copy_Load;
            this.Text = $"Compare files";
        }

        private void Copy_Load(object sender, EventArgs e)
        {
            foreach (var file in LabelFileHelper.GetAllLanguageFilesFromMetadata(LabelFile.Metadata.MetadataPath))
            {
                LabelFileMetadata labelFileMetadata = LabelFileMetadata.FromMetadataFile(file);

                leftComboBox.Items.Add(labelFileMetadata.Name);
                rightComboBox.Items.Add(labelFileMetadata.Name);
            }

            leftComboBox.SelectedItem = LabelFile.Metadata.Name;

            ConfigureDataGridView(leftDataGridView);
            ConfigureDataGridView(rightDataGridView);
        }

        private void ConfigureDataGridView(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AutoSize = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Id";
            column.Name = "Id";
            column.Width = 120;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Value";
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.Name = "Value";
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Description";
            column.Name = "Description";
            column.Width = 100;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns.Add(column);

            splitContainer1.SplitterDistance = splitContainer1.Width / 2;

            dataGridView.Scroll += DataGridScroll;
            dataGridView.MouseDown += DataGridView_MouseDown;
        }

        private void DataGridView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (DataGridView)sender;

                int currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow != -1)
                {
                    if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.LeftShift))
                    {
                        dgv.ClearSelection();
                    }

                    dgv.Rows[currentMouseOverRow].Selected = true;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("<- Merge to the left", OnMergeToLeft));
                    m.MenuItems.Add(new MenuItem("Merge to the right ->", OnMergeToRight));

                    m.Show((DataGridView)sender, new Point(e.X, e.Y));
                }
            }
        }

        private void OnMergeToLeft(object sender, EventArgs e)
        {
            Merge(rightDataGridView, rightLabelFile, leftDataGridView, leftLabelFile);
        }

        private void OnMergeToRight(object sender, EventArgs e)
        {
            Merge(leftDataGridView, leftLabelFile, rightDataGridView, rightLabelFile);
        }

        private void Merge(DataGridView sourceDgv, LabelFile sourceLabelFile, DataGridView destinationDgv, LabelFile destinationLabelFile)
        {
            // Left and right row count are the same and contains the same IComparison (stored on Tag)
            foreach (DataGridViewRow sourceRow in sourceDgv.SelectedRows)
            {
                DataGridViewRow destinationRow = destinationDgv.Rows[sourceRow.Index];

                IComparison comparison = (IComparison)sourceRow.Tag;

                if (comparison is Difference difference)
                {
                    Label newLabel = sourceLabelFile.GetLabelById(difference.LabelId);
                    Label labelToModify = destinationLabelFile.GetLabelById(difference.LabelId);

                    labelToModify.Value = newLabel.Value;
                    labelToModify.Description = newLabel.Description;
                }
                else if (comparison is Missing missing)
                {
                    // If what is missing is source, we need to remove from destination
                    if (sourceRow.Cells[0].Value == null)
                    {
                        destinationLabelFile.RemoveLabelById(missing.LabelId);
                    }
                    // Otherwise we create the label
                    else
                    {
                        destinationLabelFile.AddLabel((Label)missing.Label.Clone());
                    }
                }
            }

            // Disable file watcher while writing to the file opened in the editor
            if (destinationLabelFile == LabelFile)
                labelEditor?.DisableFileWatcher();

            destinationLabelFile.Write();

            // Enable it again
            if (destinationLabelFile == LabelFile)
            {
                NeedsToReload = true;
                labelEditor?.EnableFileWatcher();
            }

            SelectedIndexChanged(null, null);
        }

        private void DataGridScroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (sender == leftDataGridView)
                {
                    rightDataGridView.FirstDisplayedScrollingRowIndex = leftDataGridView.FirstDisplayedScrollingRowIndex;
                    rightDataGridView.Update();
                }
                else
                {
                    leftDataGridView.FirstDisplayedScrollingRowIndex = rightDataGridView.FirstDisplayedScrollingRowIndex;
                    leftDataGridView.Update();
                }
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            leftLabelFile = null;
            rightLabelFile = null;

            if (leftComboBox.SelectedIndex != -1 && rightComboBox.SelectedIndex != -1)
            {
                leftDataGridView.ClearSelection();
                rightDataGridView.ClearSelection();

                leftDataGridView.Rows.Clear();
                rightDataGridView.Rows.Clear();

                string leftMetadataFile = leftComboBox.Items[leftComboBox.SelectedIndex].ToString();
                string rightMetadataFile = leftComboBox.Items[rightComboBox.SelectedIndex].ToString();

                leftLabelFile = LabelFile;
                rightLabelFile = LabelFile;

                if (leftMetadataFile != LabelFile.Metadata.Name)
                {
                    var fullMetadataFile = Path.Combine(Path.GetDirectoryName(LabelFile.Metadata.MetadataPath), leftMetadataFile + ".xml");
                    leftLabelFile = new LabelFile(fullMetadataFile);
                    leftLabelFile.Read();
                }
                
                if (rightMetadataFile != LabelFile.Metadata.Name)
                {
                    if (rightMetadataFile == leftMetadataFile)
                    {
                        rightLabelFile = leftLabelFile;
                    }
                    else
                    {
                        var fullMetadataFile = Path.Combine(Path.GetDirectoryName(LabelFile.Metadata.MetadataPath), rightMetadataFile + ".xml");
                        rightLabelFile = new LabelFile(fullMetadataFile);
                        rightLabelFile.Read();
                    }
                }

                // Compare
                int missingLeftCount = 0;
                int missingRightCount = 0;
                int changedCount = 0;

                foreach (var comparison in LabelFileHelper.Compare(leftLabelFile, rightLabelFile))
                {
                    if (comparison is Same same && !showDiffCheckBox.Checked)
                    {
                        InsertLabel(leftDataGridView, same.Label1, Color.White, comparison);
                        InsertLabel(rightDataGridView, same.Label2, Color.White, comparison);
                    }
                    else if (comparison is Difference difference && changedDiffCheckBox.Checked)
                    {
                        changedCount++;
                        InsertLabel(leftDataGridView, difference.Label1, Color.Yellow, comparison);
                        InsertLabel(rightDataGridView, difference.Label2, Color.Yellow, comparison);
                    }
                    else if (comparison is Missing missing && missingDiffCheckBox.Checked)
                    {
                        if (missing.LeftIsMissing)
                        {
                            missingLeftCount++;
                            InsertLabel(rightDataGridView, missing.Label, Color.White, comparison);
                            InsertLabel(leftDataGridView, null, Color.Red, comparison);
                        }
                        else
                        {
                            missingRightCount++;
                            InsertLabel(leftDataGridView, missing.Label, Color.White, comparison);
                            InsertLabel(rightDataGridView, null, Color.Red, comparison);
                        }
                    }
                }

                missingLeft.Text = missingLeftCount.ToString();
                changedLeft.Text = changedCount.ToString();
                missingRight.Text = missingRightCount.ToString();
                changedRight.Text = changedCount.ToString();

                leftDataGridView.CurrentCell = null;
                rightDataGridView.CurrentCell = null;
            }
        }

        private void InsertLabel(DataGridView dgv, Label label, Color color, IComparison comparison)
        {
            var index = dgv.Rows.Add();
            var row = dgv.Rows[index];

            row.Cells[0].Value = label?.Id;
            row.Cells[1].Value = label?.Value;
            row.Cells[2].Value = label?.Description;
            row.DefaultCellStyle.BackColor = color;
            row.Tag = comparison;
        }

        private void showDiffCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            missingDiffCheckBox.Enabled = showDiffCheckBox.Checked;
            changedDiffCheckBox.Enabled = showDiffCheckBox.Checked;

            SelectedIndexChanged(sender, e);
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            if (leftDataGridView.Rows.Count != rightDataGridView.Rows.Count) return;

            if (sender == leftDataGridView)
            {
                ChangeSelection(leftDataGridView, rightDataGridView);
            }
            else if (sender == rightDataGridView)
            {
                ChangeSelection(rightDataGridView, leftDataGridView);
            }
        }

        private void ChangeSelection(DataGridView sourceDgv, DataGridView destinationDgv)
        {
            destinationDgv.SelectionChanged -= SelectionChanged;
            destinationDgv.ClearSelection();

            if (sourceDgv.CurrentRow != null)
            {
                destinationDgv.CurrentCell = destinationDgv.Rows[sourceDgv.CurrentRow.Index].Cells[0];
            }

            foreach (DataGridViewRow row in sourceDgv.SelectedRows)
            {
                destinationDgv.Rows[row.Index].Selected = true;
            }

            destinationDgv.SelectionChanged += SelectionChanged;

            mergeToLeftButton.Enabled = sourceDgv.SelectedRows.Count > 0;
            mergeToRightButton.Enabled = sourceDgv.SelectedRows.Count > 0;
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            var selectedItemLeft = leftComboBox.SelectedItem;

            // Remove temporarly the event so when we change the selection item
            // the comparison is not triggered at first
            leftComboBox.SelectedIndexChanged -= SelectedIndexChanged;
            leftComboBox.SelectedItem = rightComboBox.SelectedItem;
            leftComboBox.SelectedIndexChanged += SelectedIndexChanged;

            rightComboBox.SelectedItem = selectedItemLeft;
        }

        private void missingDiffCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged(sender, e);
        }

        private void changedDiffCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged(sender, e);
        }

        private void mergeToLeftButton_Click(object sender, EventArgs e)
        {
            Merge(rightDataGridView, rightLabelFile, leftDataGridView, leftLabelFile);
        }

        private void mergeToRightButton_Click(object sender, EventArgs e)
        {
            Merge(leftDataGridView, leftLabelFile, rightDataGridView, rightLabelFile);
        }
    }
}
