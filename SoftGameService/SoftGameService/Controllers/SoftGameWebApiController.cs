using SoftGameEFDataModel.Entities;
using SoftGameService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftGameService.Controllers
{
    public class SoftGameWebApiController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ValidateUser(UserInformations userInfo)
        {
            SoftcrylicEntities context = new SoftcrylicEntities();
            ActiveUser activeUser = new ActiveUser();
            var validateLogin = (from p in
                                    context.Users
                                 where p.UserName == userInfo.UserName && p.Pwd == userInfo.Pwd
                                 select p).FirstOrDefault();           
            if (validateLogin != null)
            {
                //activeUser.ActiveUserName = validateLogin.UserName;
                //context.ActiveUsers1.Add(activeUser);
                //context.SaveChanges();
                return Ok("Valid User");
            }
            else
                return NotFound();
        }
    }
}
