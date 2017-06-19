using Newtonsoft.Json;
using SoftGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SoftGame.Controllers
{
    public class LoginController : Controller
    {
        HttpClient client;        

        public ActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel Emp)
        {
            client = new HttpClient();
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync("http://localhost:64121/api/SoftGameWebApi/ValidateUser", Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Home");
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(Emp);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Home()
        {
            SoftGameQuerySvc.SoftGameQueryServiceClient getSoftGameAll = new SoftGameQuerySvc.SoftGameQueryServiceClient();
            List<ListofGamesModel> lstofGamesAll = new List<ListofGamesModel>();
            var getSoftgameAll = getSoftGameAll.GetAllGames();
            foreach (var item in getSoftgameAll)
            {
                ListofGamesModel usr = new ListofGamesModel();
                usr.GameId = item.GameId;
                usr.GameName = item.GameName;
                lstofGamesAll.Add(usr);

            }
            return View(lstofGamesAll); 
        }

       
        public ActionResult LogOff()
        {
            return RedirectToAction("Login");
        }
    }
}
