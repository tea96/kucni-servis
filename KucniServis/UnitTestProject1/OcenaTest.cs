using System;
using System.Linq;
using BusinessLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class OcenaTest
    {
        Ocena o = new Ocena();
        OcenaBusiness ob = new OcenaBusiness();
        Korisnik k = new Korisnik();
        KorisnikBusiness kb = new KorisnikBusiness();
        Random rand = new Random();

        [TestInitialize]
        public void Init()
        {
            k.Ime = "Korisnik";
            k.Prezime = "Korisnikovic";
            k.Sifra = "12345678";
            k.Broj_telefona = "303-030";
            k.Adresa = "Korisnicka 2";
            k.Admin = "true";
            k.EMail = "korisnik@korisnik.com";
            k.KorisnickoIme = "korisnik1";
            k.Grad = "Koralovo";

            kb.InsertKorisnik(k);
            k.Id_korisnika = kb.GetAllKorisnik().Where(tmp => tmp.Ime == k.Ime).ToList()[0].Id_korisnika;

            o.Vrednost = rand.Next(1, 5);
            o.Id_korisnika = k.Id_korisnika;

            ob.InsertOcena(o);
            o.Id_ocene = ob.GetAllOcena().Where(tmp => tmp.Id_korisnika==k.Id_korisnika).ToList()[0].Id_ocene;
        }

        [TestMethod]
        public void TestInsert()
        {
            if (!ob.GetAllOcena().Exists(tmp => tmp.Id_ocene == o.Id_ocene))
                Assert.Fail("Ocena nije uneta u bazu!");
        }

        [TestMethod]
        public void TestUpdate()
        {
            o.Vrednost = rand.Next(1, 5);
            ob.UpdateOcena(o);
            if (!ob.GetAllOcena().Exists(tmp => tmp.Id_ocene == o.Id_ocene && tmp.Vrednost==o.Vrednost))
                Assert.Fail("Ocena nije azurirana u bazi!");
        }

        [TestMethod]
        public void TestDelete()
        {
            ob.DeleteOcena(o.Id_ocene);
            if (ob.GetAllOcena().Exists(tmp => tmp.Id_ocene == o.Id_ocene))
                Assert.Fail("Ocena nije izbrisana iz baze!");
        }

        [TestCleanup]
        public void CleanUp()
        {
            ob.DeleteOcena(o.Id_ocene);
            kb.DeleteKorisnik(k.Id_korisnika);
        }
    }
}
