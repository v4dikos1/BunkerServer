using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BunkerServer.Controllers
{
    [ApiController]
    [Route("api/user/auth")]
    public class AuthControlles : ControllerBase
    {


        public ActionResult<IUser> Register(IUser request)
        {


            return Ok();
        }
    }
}
