using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroupUpWeb.Controllers;
using GroupUpWeb.BusinessInterface;
using GroupUpWeb.Models;
using GroupUpWeb.Helpers.Uow;
using GroupUpWeb.Helpers.EF;
using UnitTestProject.BuilderModels;
using System.Net;
using GroupUpWeb.Helpers;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        static Mock<GroupUpContext> dbcontext;

        static Mock<RepositoryFactories> repositoryFactory;

        static Mock<IRepositoryProvider> repositoryProvider;

        static Mock<UnityOfWork> Uow;

        static Mock<User> userInterface;

        static Mock<UserFriends> userFriendsInterface;

        static Mock<UsersController> controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext) {
            dbcontext = new Mock<GroupUpContext>();

            dbcontext.Setup(x => x.Set<User>());

            repositoryFactory = new Mock<RepositoryFactories>();

            repositoryProvider = new Mock<IRepositoryProvider>();

            repositoryProvider.Setup(x => x.GetRepositoryForEntityType<User>());

            Uow = new Mock<UnityOfWork>(repositoryProvider.Object);

            userInterface = new Mock<User>(Uow.Object);

            userFriendsInterface = new Mock<UserFriends>(Uow.Object);

            controller = new Mock<UsersController>(userInterface.Object, userFriendsInterface.Object);

        }

        [TestMethod]
        public void TestMethod()
        {           
            var result = controller.Object.CreateUser(Builder.user(Uow.Object));

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
