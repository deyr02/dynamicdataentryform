using System.Collections.Generic;

namespace Domain
{
    public class Rule
    {
        public int Id {get; set;}
        public string Name {get; set;}

        //AttributeRules 
        public List<AttributeRule> Attributes{get; set;}
    }
}