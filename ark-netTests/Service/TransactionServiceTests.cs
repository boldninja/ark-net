﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArkNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArkNet.Utils.Enum;

namespace ArkNet.Service.Tests
{
    [TestClass()]
    public class TransactionServiceTests
    {
        [TestInitialize]
        public void Init()
        {
            ArkNetApi.Instance.Start(NetworkType.MainNet).Wait();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var trans = TransactionService.GetAll();
            Assert.IsTrue(trans.Transactions.Count > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var trans = TransactionService.GetAll().Transactions.FirstOrDefault();
            Assert.IsNotNull(trans);

            var trans1 = TransactionService.GetById(trans.Id);
            Assert.IsNotNull(trans1);
        }

        [TestMethod()]
        public void GetByIdErrorTest()
        {
            var trans = TransactionService.GetById("ErrorId");

            Assert.IsFalse(trans.Success);
            Assert.IsNotNull(trans.Error);
        }

        [TestMethod()]
        public void GetUnConfirmedByIdTest()
        {
            var trans = TransactionService.GetUnconfirmedAll();
            Assert.IsNotNull(trans);

            if (trans.Transactions.Any())
            {
                var trans1 = TransactionService.GetUnConfirmedById(trans.Transactions.FirstOrDefault().Id);
                Assert.IsNotNull(trans1);
            }
        }

        [TestMethod()]
        public void GetUnConfirmedByIdErrorTest()
        {
            var trans = TransactionService.GetUnConfirmedById("ErrorId");

            Assert.IsFalse(trans.Success);
            Assert.IsNotNull(trans.Error);
        }

        [TestMethod()]
        public void GetUnconfirmedAllTest()
        {
            var trans = TransactionService.GetUnconfirmedAll();
            Assert.IsNotNull(trans);
        }
    }
}