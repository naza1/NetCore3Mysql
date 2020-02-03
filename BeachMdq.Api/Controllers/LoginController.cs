using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BeachMdq.Api.Controllers
{

    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        public LoginController()
        {

        }

        //[HttpGet]
        //public HttpResponseMessage Validate(string token, string username)
        //{
        //    bool exists = new UserRepository().GetUser(username) != null;
        //    if (!exists) return Request.CreateResponse(HttpStatusCode.NotFound,
        //        "The user was not found.");
        //    string tokenUsername = TokenManager.ValidateToken(token);
        //    if (username.Equals(tokenUsername))
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}
    }
}
