using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    [Index(nameof(AttributeId))]
    public class AttributeRule
    {
        //Attibute
        public int AttributeId { get; set; }
        public Attribute Attribute { get; set; }

        //Rule
        public int RuleId { get; set; }
        public Rule Rule { get; set; }

        //other column
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string Info { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string ErrorMessage { get; set; }

    }
}