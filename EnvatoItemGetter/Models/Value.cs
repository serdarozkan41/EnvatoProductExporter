using System.Collections.Generic;

namespace EnvatoItemGetter.Models
{
    public struct Value
    {
        public string String;
        public List<string> StringArray;

        public static implicit operator Value(string String) => new Value { String = String };
        public static implicit operator Value(List<string> StringArray) => new Value { StringArray = StringArray };
        public bool IsNull => StringArray == null && String == null;
    }
}
