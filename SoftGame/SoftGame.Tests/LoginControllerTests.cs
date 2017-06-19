using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftGame.Controllers;
using SoftGame.Models;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SoftGame.Tests
{
    [TestClass]
    public class LoginControllerTests
    {
        LoginController loginController = new LoginController();
        LoginViewModel loginModel = new LoginViewModel();
        ListofGamesModel lstofGamesModel = new ListofGamesModel();

        [TestMethod]
        public async Task LoginControllerwithModel_Valid()
        {
            //Arrange
            loginModel.UserName = "rajarathinam";
            loginModel.Pwd = "rajarathinam";

            //Act
            var result = loginController.Login(loginModel) as Task<ActionResult>;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task LoginControllerwithModel_InValid()
        {
            //Arrange
            loginModel.UserName = "SoftCrylic";
            loginModel.Pwd = "SoftCrylic";

            //Act
            var result = loginController.Login(loginModel) as Task<ActionResult>;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task LoginControllerwithOutModel_Valid()
        {
            //Arrange
            loginModel.UserName = "rajarathinam";
            loginModel.Pwd = "rajarathinam";

            //Act
            var result = loginController.Login() as ActionResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task LoginControllerHome_Valid()
        {
            //Arrange
            List<ListofGamesModel> listOfGamesModel = new List<ListofGamesModel>()
            {
                new ListofGamesModel { GameId=1, GameName="Cricket" }
            };
            //Act
            var result = loginController.Home() as Task<ActionResult>; ;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
