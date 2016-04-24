﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroupUpWeb.Helpers.EF;
using Moq;
using GroupUpWeb.Models;
using GroupUpWeb.BusinessInterface;
using GroupUpWeb.Helpers;
using GroupUpWeb.Controllers;
using GroupUpWeb.Helpers.Uow;

namespace UnitTestProject
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
        void Initialize() {

            repoFac = new RepositoryFactories();
            repoProvider = new RepositoryProvider(repoFac);
            uow = new UnityOfWork(repoProvider);
            userInterface = new User(uow);
            controller = new UsersController(userInterface);
        }

        [TestMethod]
        void Create_User() {


            controller.CreateUser(Builder.user(uow,5));
        }
    }
}
