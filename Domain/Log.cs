using System;
using System.Collections.Generic;

namespace Domain
{
    public class Log
    {
        public int Id {get; set;}
        public DateTime CreatedAt {get; set;}

        //Attribute Log
        public List<AttributeLog> AttributeLogs {get; set;}
    }
}