using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    
    public class Form
    {
        public Guid Id {get; set;}
        public string FormName {get; set;}

        [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText )]
        public string Description{get; set;}
        public DateTime Created{ get; set;}
       
        //creator
        public string UserID {get; set;}
        public AppUser User {get; set;}

        //Attributes
        public List<Attribute> Attributes{get;set;}


    }
}