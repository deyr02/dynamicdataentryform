using Application.Record;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Form, Form>();
            CreateMap<Attribute, Attribute>();
            CreateMap<AttributeValueOption, AttributeValueOption>();
            CreateMap<AttributeRule, AttributeRule>();
            CreateMap<Form, RecordDto>()
            .ForMember(d => d.RecordId, r => r.MapFrom(s => s.Attributes[0].Logs[0].LogId))
            .ForMember(rec => rec.Record, r => r.MapFrom(s => s.Attributes));

        }
    }
}