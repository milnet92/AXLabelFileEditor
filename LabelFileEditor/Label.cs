using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXLabelFileEditor
{
    public class Label : ICloneable
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public Label(string id, string value)
        {
            Id = id;
            Value = value;
        }

        public Label(string id, string value, string description) : this(id, value)
        {
            Description = description;
        }

        public object Clone()
        {
            return new Label(Id, Value, Description);
        }

        public static bool IsValidId(string id)
        {
            foreach (var c in id)
            {
                if (c != '@' && c != '_' && !char.IsLetterOrDigit(c)) return false;
            }

            return true;
        }
    }
}
