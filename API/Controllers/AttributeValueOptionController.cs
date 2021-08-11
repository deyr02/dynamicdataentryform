using System.Threading.Tasks;
using Application.AttributeValueOptions;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AttributeValueOptionController: BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateAttributeValueOption(AttributeValueOption option){
            
            return HandleResult(await Mediator.Send(new Create.Command{AttributeValueOption = option}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>EditAttributeValueOption(int id, AttributeValueOption option){
            option.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command{AttributeValueOption = option}));
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult>DeleteAttributeValueOption(int id){
            return HandleResult(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}