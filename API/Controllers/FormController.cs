using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Forms;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    // [Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous]
    public class FormController : BaseApiController
    {

        [HttpGet("formlist")]
        public async Task<ActionResult<List<Form>>> FormList()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNewForm(Form form)
        {
            //return BadRequest(form);
            return HandleResult(await Mediator.Send(new Create.Command { Form = form }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditForm(Guid id, Form form)
        {
            form.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Form = form }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}