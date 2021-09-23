using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    [Index(nameof(LogId), nameof(AttributeId))]
    public class AttributeLog
    {
        //Attribute
        public int AttributeId {get; set;}
        public Attribute Attribute {get; set;}
        

        //Log 
        public int LogId {get;set;}
        public Log Log {get; set;}

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string Value {get; set;}
    }
}