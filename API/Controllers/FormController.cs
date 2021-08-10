using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    // [Authorize(AuthenticationSchemes = "Bearer")]
    public class FormController : BaseApiController
    {

        [HttpGet("formlist")]
        public string FormList()
        {
            return "There is no form created yet...";
        }

        // [HttpPost]
        // public Task<IActionResult> CreateNewForm(){

        // }

    }
}