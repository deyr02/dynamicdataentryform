using System.Collections.Generic;

namespace Domain
{
    public class DataType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Attribute> Attributes {get; set;}
    }
}