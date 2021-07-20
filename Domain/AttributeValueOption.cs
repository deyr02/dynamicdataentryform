using Microsoft.EntityFrameworkCore;

namespace Domain
{
    [Index(nameof(AttributeId))]
    public class AttributeValueOption
    {
        public int Id {get; set;}
        public string Option {get; set;}

        //Attribute
        public int AttributeId {get; set;}
        public Attribute Attribute {get; set;}
    }
}