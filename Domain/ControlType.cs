using System.Collections.Generic;

namespace Domain
{
    public class ControlType
    {
        public int Id { get; set; }
        public string Name {get; set;}

        //Attribute
        public List<Attribute> Attributes {get; set;}
    }
}