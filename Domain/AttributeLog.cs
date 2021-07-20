using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    [Index(nameof(LogId), nameof(AttrubuteId))]
    public class AttributeLog
    {
        //Attribute
        public int AttrubuteId {get; set;}
        public Attribute Attribute {get; set;}
        

        //Log 
        public int LogId {get;set;}
        public Log Log {get; set;}

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string Value {get; set;}
    }
}