using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXLabelFileEditor
{
    public interface IComparison
    {
        string LabelId { get; }
    }

    public class Missing : IComparison
    {
        public bool LeftIsMissing { get; set; }
        public Label Label { get; set; }

        public string LabelId => Label.Id;

        public Missing(Label label, bool leftIsMissing)
        {
            Label = label;
            LeftIsMissing = leftIsMissing;
        }
    }

    public class Difference : IComparison
    {
        public string LabelId => Label1.Id;

        public Label Label1 {  get; set; }
        public Label Label2 { get; set; }
        public string Property {  get; set; }

        public Difference(Label label1, Label label2, string property)
        {
            Label1 = label1;
            Label2 = label2;
            Property = property;
        }
    }

    public class Same : IComparison
    {
        public string LabelId => Label1.Id;

        public Label Label1 { get; set; }
        public Label Label2 { get; set; }

        public Same(Label label1, Label label2)
        {
            Label1 = label1;
            Label2 = label2;
        }
    }
}
