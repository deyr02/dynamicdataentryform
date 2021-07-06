using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/[controller]")]

    public class FormController : ControllerBase
    {

        [HttpGet("formlist")]
        public string FormList()
        {
            return "There is no form created yet...";
        }

    }
}