using System.Collections.Generic;

namespace Application.Record
{
    public class RecordDto
    {
        public int RecordId { get; set; }
        public List<AttributeDto> Record { get; set; }
    }


    public class AttributeDto
    {
        public string DataType { get; set; }
        public string Name { get; set; }
        public string value { get; set; }
    }
}