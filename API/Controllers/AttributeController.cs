using System.Threading.Tasks;
using Application.Attributes;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AttributeController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAttribute(Attribute attribute)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Attribute = attribute }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAttribute(int Id, Attribute attribute)
        {
            attribute.AttributeId = Id;
            return HandleResult(await Mediator.Send(new Edit.Command { Attribute = attribute }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{Id= id}));
        }
    }
}