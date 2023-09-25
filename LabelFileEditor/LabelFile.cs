using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AXLabelFileEditor
{
    public class LabelFile
    {
        public readonly List<Label> Labels = new List<Label>();
        public LabelFileMetadata Metadata { get; set; }

        private bool _read = false;
        private bool _saved = false;
        public bool IsSaved
        {
            get => _saved;
            set
            {
                if (_saved != value)
                {
                    _saved = value;
                    OnSynchronizationChanged(new EventArgs());
                }
            }
        }

        public event EventHandler SynchronizationChanged;

        public LabelFile(string metadataFile)
        {
            if (metadataFile == null) throw new ArgumentNullException(nameof(metadataFile));

            Metadata = LabelFileMetadata.FromMetadataFile(metadataFile);

            Init();
        }

        public void RemoveLabelById(string id)
        {
            Label label = Labels.FirstOrDefault(l => l.Id == id);

            if (label == null)
                throw new Exception($"Label {label.Id} does not exists.");
            
            IsSaved = false;
            Labels.Remove(label);
        }

        public void AddLabel(Label label)
        {
            if (Labels.Exists(l => l.Id == label.Id))
                throw new Exception($"Label {label.Id} already exists.");

            IsSaved = false;
            Labels.Add(label);
        }

        public Label GetLabelById(string id)
        {
            return Labels.FirstOrDefault(label => label.Id == id);
        }

        private void Init()
        {
            IsSaved = false;
        }

        public void Read()
        {
            Labels.Clear();

            Label currentEntry = null;

            foreach (var line in File.ReadAllLines(Metadata.LabelContentPath))
            {
                if (line.StartsWith(" ;"))
                {
                    Debug.Assert(currentEntry != null);

                    currentEntry.Description = line.Substring(2);
                }
                else
                {
                    string[] parts = line.Split(new char[] { '=' }, 2);
                    currentEntry = new Label(parts[0], parts[1]);

                    Labels.Add(currentEntry);
                }
            }

            _read = true;
            IsSaved = true;
        }

        public void Write(bool ordered = true)
        {
            Write(Metadata.LabelContentPath, ordered);
        }

        private void Write(string fileName, bool ordered = true)
        {
            if (!_read) return;
            if (IsSaved) return;

            using (var writer = new StreamWriter(fileName, false, new UTF8Encoding(true)))
            {
                IEnumerable<Label> entries = ordered ? Labels.OrderBy(e => e.Id.Replace("_", "Z")) :(IEnumerable<Label>)Labels;

                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Id}={entry.Value}");

                    if (entry.Description != null)
                        writer.WriteLine(" ;" + entry.Description);
                }
            }

            IsSaved = true;
        }

        internal void OnSynchronizationChanged(EventArgs e)
        {
            SynchronizationChanged?.Invoke(this, e);
        }
    }
}
