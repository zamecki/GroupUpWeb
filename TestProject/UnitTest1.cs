using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroupUpWeb.Helpers.EF;
using GroupUpWeb.Helpers.Uow;
using GroupUpWeb.BusinessInterface;
using GroupUpWeb.Controllers;
using GroupUpWeb.Models;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        RepositoryFactories repoFac;
        IRepositoryProvider repoProvider;
        IUnityOfWork uow;
        IUser userInterface;
        UsersController controller;

        [TestInitialize]
        void Initialize()
        {

            repoFac = new RepositoryFactories();
            repoProvider = new RepositoryProvider(repoFac);
            uow = new UnityOfWork(repoProvider);
            userInterface = new User(uow);
            controller = new UsersController(userInterface);
        }

        [TestMethod]
        void Create_User()
        {
        }
    }
}
