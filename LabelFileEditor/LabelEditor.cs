using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AXLabelFileEditor
{
    public partial class LabelEditor : Form
    {
        private Label _editingLabel = null;
        private DateTime lastEditedDateTime;

        public readonly LabelFile LabelFile;
        
        public LabelEditor(LabelFile labelFile)
        {
            LabelFile = labelFile;
            labelFile.Read();

            InitializeComponent();

            this.labelFileWatcher.Path = Path.GetDirectoryName(labelFile.Metadata.LabelContentPath);
            this.labelFileWatcher.Filter = labelFile.Metadata.LabelContentFileName;
            this.labelFileWatcher.Changed += LabelFileWatcher_Changed;

            this.Text = labelFile.Metadata.Name;
            this.Load += LabelEditor_Load;
            this.FormClosing += LabelEditor_FormClosing;

            GetEditedDateTime();
        }

        private void LabelFileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            var currentEditedDateTime = GetEditedDateTime();

            if (currentEditedDateTime > lastEditedDateTime)
            {
                lastEditedDateTime = currentEditedDateTime;
                if (MessageBox.Show("Label file has been changed from outside this editor, do you want to reload it?.",
                    "Label file changed",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    // Read and load
                    LabelFile.Read();
                    labelsGridView.Invoke(new MethodInvoker(() =>
                        labelsGridView.DataSource = new BindingList<Label>(LabelFile.Labels.ToList())
                    ));
                }
            }
        }

        internal void EnableFileWatcher()
        {
            labelFileWatcher.EnableRaisingEvents = true;
        }

        internal void DisableFileWatcher()
        {
            labelFileWatcher.EnableRaisingEvents = false;
        }

        private void LabelEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!LabelFile.IsSaved 
                && MessageBox.Show(this, "There are pendign changes to save. Do you want to save now?", 
                    "Unsaved changes", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                labelFileWatcher.Changed -= LabelFileWatcher_Changed;
                LabelFile.Write();
                lastEditedDateTime = GetEditedDateTime();
                labelFileWatcher.Changed += LabelFileWatcher_Changed;
            }
        }

        private DateTime GetEditedDateTime()
        {
            var info = new FileInfo(LabelFile.Metadata.LabelContentPath);
            return info.LastWriteTime;
        }

        private void FilterResults()
        {
            IEnumerable<Label> filtered = LabelFile.Labels.Where(
                entry =>
                entry.Id.ToLower().Contains(searchBox.Text.ToLower()) ||
                entry.Value.ToLower().Contains(searchBox.Text.ToLower()) ||
                (entry.Description?.ToLower().Contains(searchBox.Text.ToLower()) ?? false));

            var a = filtered.ToList();

            if (emptyValueCheckBox.Checked)
            {
                filtered = filtered.Where(entry => string.IsNullOrEmpty(entry.Value));
            }

            labelsGridView.DataSource = new BindingList<Label>(filtered.ToList());
            labelsGridView.Update();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            FilterResults();
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string value = e.FormattedValue?.ToString() ?? string.Empty;

            // Id or value
            if (e.ColumnIndex == 0)
            {
                if (value == "" || !Label.IsValidId(value))
                {
                    e.Cancel = true;
                    return;
                }
            }

            var ds = (BindingList<Label>)labelsGridView.DataSource;
            
            if (e.ColumnIndex == 0 && ds.Count(entry => entry.Id == value) > 0)
            {
                foreach (var label in ds.Where(lbl => lbl.Id == value))
                {
                    int index = ds.IndexOf(label);

                    if (index != e.RowIndex)
                    {
                        MessageBox.Show($"Label '{value}' already exists.", "Label error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }

        private void LabelEditor_Load(object sender, EventArgs e)
        {
            labelsGridView.AutoGenerateColumns = false;
            labelsGridView.AutoSize = true;
            labelsGridView.DataSource = new BindingList<Label>(LabelFile.Labels.ToList());
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

            this.searchBox.TextChanged += SearchBox_TextChanged;

            labelsGridView.CellBeginEdit += LabelsGridView_CellBeginEdit; ;
            labelsGridView.CellEndEdit += LabelsGridView_CellEndEdit;
            labelsGridView.CellValidating += DataGridView1_CellValidating;
            labelsGridView.KeyDown += LabelsGridView_KeyDown;
            labelsGridView.KeyPress += LabelsGridView_KeyPress;
            LabelFile.SynchronizationChanged += LabelFile_SynchronizationChanged;

            labelsGridView.CurrentCell = labelsGridView.Rows.Count > 0 ? labelsGridView.Rows[0].Cells[0] : null;
        }

        private bool ctrlCPressed = false;
        private void LabelsGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == labelsGridView && e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
            {
                ctrlCPressed = true;
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                string previouslySelectedLabelId = null;

                if (labelsGridView.SelectedRows.Count == 1)
                {
                    previouslySelectedLabelId = labelsGridView.SelectedRows[0].Cells[0].Value.ToString();
                }

                // Write to file
                labelFileWatcher.Changed -= LabelFileWatcher_Changed;
                LabelFile.Write();
                lastEditedDateTime = GetEditedDateTime();
                labelFileWatcher.Changed += LabelFileWatcher_Changed;

                // Read and load
                LabelFile.Read();
                labelsGridView.DataSource = new BindingList<Label>(LabelFile.Labels.ToList());

                // Try to go back to the previously selected row
                if (previouslySelectedLabelId != null)
                {
                    var newIndex = LabelFile.Labels.IndexOf(LabelFile.Labels.FirstOrDefault(l => l.Id == previouslySelectedLabelId));

                    if (newIndex != -1)
                    {
                        labelsGridView.ClearSelection();
                        labelsGridView.CurrentCell = labelsGridView.Rows[newIndex].Cells[0];
                        labelsGridView.Invalidate();
                    }
                }
            }

        }

        private void LabelsGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ctrlCPressed)
            {
                // Get current label
                if (labelsGridView.CurrentCell?.ColumnIndex == 0)
                {
                    e.Handled = true;
                    Clipboard.SetText($"@{LabelFile.Metadata.LabelFileId}:{labelsGridView.CurrentCell.Value}");
                }

                ctrlCPressed = false;
            }
        }

        private void LabelsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_editingLabel == null) return;

            var label = labelsGridView.Rows[e.RowIndex].DataBoundItem as Label;

            bool modified = _editingLabel.Id != label.Id || _editingLabel.Value != label.Value || _editingLabel.Description != label.Description;

            if (modified)
            {
                LabelFile.IsSaved = false;
            }
        }

        private void LabelsGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var l = labelsGridView.Rows[e.RowIndex].DataBoundItem as Label;
            _editingLabel = (Label)l.Clone();
        }

        private void LabelsGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            _editingLabel = labelsGridView.Rows[e.RowIndex].DataBoundItem as Label;
        }

        private void LabelFile_SynchronizationChanged(object sender, EventArgs e)
        {
            this.Text = $"{LabelFile.Metadata.Name}" + (LabelFile.IsSaved ? "" : " (NOT SAVED)");
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var dataSource = (BindingList<Label>)labelsGridView.DataSource;

            // Find the last "NewLabel" added
            int cnt = dataSource.Count(l => l.Id.StartsWith("NewLabel"));
            string newLabelId = "NewLabel" + (cnt == 0 ? "" : (cnt + 1).ToString());

            Label newLabel = new Label(newLabelId, "New Text");
            LabelFile.AddLabel(newLabel);
            dataSource.Add(newLabel);
            this.ScrollToRow(labelsGridView.RowCount - 1);
        }

        private void ScrollToRow(int rowIndex)
        {
            labelsGridView.ClearSelection();
            labelsGridView.FirstDisplayedScrollingRowIndex = rowIndex;
            labelsGridView.CurrentCell = labelsGridView.Rows[rowIndex].Cells[0];
            labelsGridView.BeginEdit(true);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in labelsGridView.SelectedCells)
            {
                // Get Id from cell's row
                if (cell.RowIndex != -1)
                {
                    var row = labelsGridView.Rows[cell.RowIndex];
                    RemoveRow(row);
                }
            }
        }

        private void RemoveRow(DataGridViewRow row)
        {
            LabelFile.RemoveLabelById(row.Cells[0].Value.ToString());
            labelsGridView.Rows.Remove(row);
        }

        private void emptyValueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterResults();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            var copyForm = new Copy(LabelFile);

            if (copyForm.ShowDialog() == DialogResult.Yes)
            {
                DisableFileWatcher();
                LabelFile.Write();
                EnableFileWatcher();

                labelsGridView.DataSource = new BindingList<Label>(LabelFile.Labels.ToList());
            }
        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            var form = new LabelComparer(LabelFile, this);
            form.ShowDialog();

            if (form.NeedsToReload)
            {
                labelsGridView.DataSource = new BindingList<Label>(LabelFile.Labels.ToList());
            }
        }
    }
}
