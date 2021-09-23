using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    [Index(nameof(FormId))]
    public class Attribute
    {
        public int AttributeId {get; set;}
        public string AttributeName {get; set;}
        public string Description { get; set; }


        //Form
        public Guid FormId{get; set;}
        public Form Form {get; set;}

        //Data Types    
        public int DataTypeId {get; set;}
        public DataType DataType{get; set;}

        //AttributeRule
        public List<AttributeRule> Rules {get; set;}

        //ControlType
        public int ControlTypeId {get; set;}
        public ControlType ControlType {get; set;}


        //AttributeOptionValue 
        public List<AttributeValueOption> ValueOptions {get; set;}

        //AttributeLog
        public List <AttributeLog> Logs {get; set;}

       
    }
}