using System.Threading.Tasks;
using Application.AttributeRules;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AttributeRuleController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> AssignRule(AttributeRule attributeRule)
        {
            return HandleResult(await Mediator.Send(new AssignRule.Command { AttributeRule = attributeRule }));
        }


        [HttpPut]
        public async Task<IActionResult> EditAssignedRule(AttributeRule attributeRule)
        {
            return HandleResult(await Mediator.Send(new EditAssignedRule.Command { AttributeRule = attributeRule }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAssignedRule(AttributeRule attributeRule)
        {
            return HandleResult(await Mediator.Send(new DeleteAssignedRule.Command { AttributeRule = attributeRule }));
        }
    }
}