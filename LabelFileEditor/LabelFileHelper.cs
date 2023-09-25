using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AXLabelFileEditor
{
    internal static class LabelFileHelper
    {
        public static string[] GetAllLanguageFilesFromMetadata(string metadataFile)
        {
            return Directory.GetFiles(Path.GetDirectoryName(metadataFile), "*.xml");
        }

        public static IEnumerable<Label> CompareSourceToDestination(LabelFile source, LabelFile destination)
        {
            return source.Labels.Where(sourceLabel => !destination.Labels.Any(destinationLabel => destinationLabel.Id == sourceLabel.Id));
        }

        public static List<IComparison> Compare(LabelFile left, LabelFile right)
        {
            List<IComparison> comparisons = new List<IComparison>();

            // First compare left to right
            foreach (var leftLabel in left.Labels)
            {
                var rightLabel = right.Labels.FirstOrDefault(l => l.Id == leftLabel.Id);

                if (rightLabel == null)
                {
                    comparisons.Add(new Missing(leftLabel, false));
                }
                else
                {
                    if ((rightLabel.Description ?? "") != (leftLabel.Description ?? ""))
                    {
                        comparisons.Add(new Difference(leftLabel, rightLabel, "Description"));
                    }
                    else if ((rightLabel.Value ?? "") != (leftLabel.Value ?? ""))
                    {
                        comparisons.Add(new Difference(leftLabel, rightLabel, "Value"));
                    }
                    else
                    {
                        comparisons.Add(new Same(leftLabel, rightLabel));
                    }
                }
            }

            // Now compare right to left. Only check for missing
            // values because the rest are already returned
            foreach (var rightLabel in right.Labels)
            {
                var leftLabel = left.Labels.FirstOrDefault(l => l.Id == rightLabel.Id);

                if (leftLabel == null)
                {
                    comparisons.Add(new Missing(rightLabel, true));            
                }
            }

            return comparisons;
        }
    }
}
