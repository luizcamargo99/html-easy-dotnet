using System.Collections.Generic;

namespace HTMLEasyDotnet.Models
{
    public class HTMLElement
    {
        public string Id { get; set; }
        public List<HTMLElement> Children { get; set; }
        public string[] ClassList { get; set; }
        public string ClassName { get; set; }
        public string Value { get; set; }
        public string NodeName { get; set; }
        public string InnerHTML { get; set; }
    }
}
