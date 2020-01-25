using System;
using System.Linq;
using BusinessLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UslugaTest
    {
        Usluga u = new Usluga();
        UslugaBusiness ub = new UslugaBusiness();
        Random rand = new Random();

        [TestInitialize]
        public void Init()
        {
            u.Cena = rand.Next(1000,5000);
            u.Naziv = "Usluga";
            u.Opis = "Opis usluge";
            ub.InsertUsluga(u);
            u.Id_usluge = ub.GetAllUsluga().Where(tmp => tmp.Naziv == u.Naziv).ToList()[0].Id_usluge;
        }

        [TestMethod]
        public void TestInsert()
        {
            if (!ub.GetAllUsluga().Exists(tmp => tmp.Id_usluge == u.Id_usluge))
                Assert.Fail("Usluga nije uneta u bazu!");
        }

        [TestMethod]
        public void TestDelete()
        {
            ub.DeleteUsluga(u.Id_usluge);
            if (ub.GetAllUsluga().Exists(tmp => tmp.Id_usluge == u.Id_usluge))
                Assert.Fail("Usluga nije izbrisana iz baze!");
        }

        [TestCleanup]
        public void CleanUp()
        {
            ub.DeleteUsluga(u.Id_usluge);
        }
    }
}
