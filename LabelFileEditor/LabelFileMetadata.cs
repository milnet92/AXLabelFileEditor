using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AXLabelFileEditor
{
    public class LabelFileMetadata
    {
        private const string LabelResources = "LabelResources";

        public string Name { get; private set; }
        public string LabelContentFileName { get; private set; }
        public string LabelFileId { get; private set; }
        public string Language { get; private set; }
        public string RelativeUriInModelStore { get; private set; }
        public string LabelContentPath { get; private set; }
        public string MetadataPath { get; private set; }

        public static LabelFileMetadata FromMetadataFile(string metadataFile)
        {
            if (metadataFile == null)
            {
                throw new ArgumentNullException(nameof(metadataFile));
            }

            LabelFileMetadata labelFileMetadata = new LabelFileMetadata();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(metadataFile);

            labelFileMetadata.MetadataPath = metadataFile;
            labelFileMetadata.Name = xmlDocument.DocumentElement.SelectSingleNode("/AxLabelFile/Name").InnerText;
            labelFileMetadata.LabelContentFileName = xmlDocument.DocumentElement.SelectSingleNode("/AxLabelFile/LabelContentFileName").InnerText;
            labelFileMetadata.LabelFileId = xmlDocument.DocumentElement.SelectSingleNode("/AxLabelFile/LabelFileId").InnerText;

            // Language may not be specified for en-US
            var languageNode = xmlDocument.DocumentElement.SelectSingleNode("/AxLabelFile/Language");
            labelFileMetadata.Language = languageNode?.InnerText ?? "en-US";

            labelFileMetadata.RelativeUriInModelStore = xmlDocument.DocumentElement.SelectSingleNode("/AxLabelFile/RelativeUriInModelStore").InnerText;

            labelFileMetadata.LabelContentPath = Path.Combine(Path.GetDirectoryName(metadataFile), 
                LabelResources, 
                labelFileMetadata.Language,
                labelFileMetadata.LabelContentFileName);

            return labelFileMetadata;
        }
    }
}
