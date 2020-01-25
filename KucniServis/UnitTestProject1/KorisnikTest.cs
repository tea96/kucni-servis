using System;
using System.Linq;
using BusinessLayer;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class KorisnikTest
    {
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
        }

        [TestMethod]
        public void TestInsert()
        {
            if (!kb.GetAllKorisnik().Exists(tmp => tmp.Id_korisnika == k.Id_korisnika))
                Assert.Fail("Korisnik nije unet u bazu!");
        }

        [TestMethod]
        public void TestUpdate()
        {
            k.Ime = "Antonina";
            kb.UpdateKorisnik(k);
            if (!kb.GetAllKorisnik().Exists(tmp => tmp.Id_korisnika == k.Id_korisnika && tmp.Ime==k.Ime))
                Assert.Fail("Korisnik nije azuriran u bazi!");
        }

        [TestMethod]
        public void TestDelete()
        {
            kb.DeleteKorisnik(k.Id_korisnika);
            if(kb.GetAllKorisnik().Exists(tmp => tmp.Id_korisnika == k.Id_korisnika))
                Assert.Fail("Korisnik nije obrisan iz baze!");
        }

        [TestCleanup]
        public void CleanUp()
        {
            kb.DeleteKorisnik(k.Id_korisnika);
        }
    }
}
