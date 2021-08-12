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
        }
    }
}