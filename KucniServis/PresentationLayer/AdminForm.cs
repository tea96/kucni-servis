using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class AdminForm : Form
    {

        Korisnik trenutniKorisnik;
        KorisnikBusiness korisnikBusiness = new KorisnikBusiness();
        UslugaBusiness uslugaBusiness = new UslugaBusiness();
        OcenaBusiness ocenaBusiness = new OcenaBusiness();
        public AdminForm(Korisnik korisnik)
        {
            trenutniKorisnik = korisnik;
            InitializeComponent();
        }

        private void Fill()
        {
            listBox1.Items.Clear();
            foreach (Korisnik k in korisnikBusiness.GetAllKorisnik())
            {
                if (k.Id_korisnika != trenutniKorisnik.Id_korisnika)
                {
                    listBox1.Items.Add(k.Id_korisnika + ". " + k.Ime + " " + k.Prezime + " " + k.Grad + " " + k.Adresa + " " + k.EMail + " " + k.Broj_telefona);
                }
            }
        }



      

        private void buttonAll_Click(object sender, EventArgs e)
        {
            Fill();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            comboBox2.Items.AddRange(korisnikBusiness.GetAllKorisnik().Select(x => x.Grad).Distinct().ToArray());
           
            comboBox1.Items.AddRange(uslugaBusiness.GetAllUsluga().Select(x => x.Naziv).Distinct().ToArray());
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
           
            foreach(Korisnik korisnik in korisnikBusiness.GetAllKorisnik())
            {
                comboBox3.Items.Add(korisnik.Id_korisnika + ". " + korisnik.Ime + " " + korisnik.Prezime);
            }
            comboBox3.SelectedIndex = 0;

            foreach (Usluga u in uslugaBusiness.GetAllUsluga())
            {
                comboBox4.Items.Add(u.Id_usluge + ". " + u.Naziv + " " + u.Cena);
            }
            comboBox4.SelectedIndex = 0;
        }

        private void buttonCity_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Korisnik k in korisnikBusiness.PretraziPoGradu(comboBox2.GetItemText(comboBox2.SelectedItem)))
            {
                if (k.Id_korisnika != trenutniKorisnik.Id_korisnika)
                {
                    listBox1.Items.Add(k.Id_korisnika + ". " + k.Ime + " " + k.Prezime + " " + k.Grad + " " + k.Adresa + " " + k.EMail + " " + k.Broj_telefona);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();
            List<Korisnik> k = new List<Korisnik>();
            k = korisnikBusiness.GetAllKorisnik();
            s = s.Substring(0, s.IndexOf('.'));

            Korisnik korisnikZaUsluge = new Korisnik();

            foreach (Korisnik korisnik in k)
            {
                if (korisnik.Id_korisnika == int.Parse(s))
                {
                    label35.Text = korisnik.Id_korisnika.ToString();
                    label13.Text = korisnik.Ime;
                    label14.Text = korisnik.Prezime;
                    label15.Text = korisnik.Grad;
                    label16.Text = korisnik.Adresa;
                    label17.Text = korisnik.EMail;
                    label18.Text = korisnik.Broj_telefona;
                    korisnikZaUsluge = korisnik;

                    try
                    {
                        label31.Text = ocenaBusiness.GetAllOcena().Where(x => x.Id_korisnika == korisnik.Id_korisnika).Select(x => x.Vrednost).ToArray().Average().ToString();
                    }
                    catch
                    {
                        label31.Text = "0";
                    }
                }
            }

            UslugaBusiness uslugaBusiness = new UslugaBusiness();
            List<Usluga> usluge = uslugaBusiness.UslugaPoKorisniku(korisnikZaUsluge.Id_korisnika);
            listBox2.Items.Clear();
            foreach(Usluga u in usluge)
            {
                listBox2.Items.Add(u.Id_usluge + ". " + u.Naziv + " - " + u.Cena + " - " + u.Opis);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();
            List<Korisnik> k = new List<Korisnik>();
            k = korisnikBusiness.GetAllKorisnik();
            s = s.Substring(0, s.IndexOf('.'));
            foreach (Korisnik korisnik in k)
            {
                if (korisnik.Id_korisnika == int.Parse(s))
                    korisnikBusiness.DeleteKorisnik(korisnik.Id_korisnika);
                
                    
            }
            MessageBox.Show("The user successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Fill();
            label35.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";


        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddUserForm ad = new AddUserForm(trenutniKorisnik);
            ad.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string korisnik = listBox1.SelectedItem.ToString();
            korisnik = korisnik.Substring(0, korisnik.IndexOf('.'));

            string usluga = listBox2.SelectedItem.ToString();
            usluga = usluga.Substring(0, usluga.IndexOf('.'));

            int korisnikId = Int32.Parse(korisnik);
            int uslugaId = Int32.Parse(usluga);

            PruzanjeUslugaBusiness pruzanjeUslugaBusiness = new PruzanjeUslugaBusiness();

            Pruzanje_Usluga pu = new Pruzanje_Usluga()
            {
                Id_korisnika = korisnikId,
                Id_usluge = uslugaId
            };
            pruzanjeUslugaBusiness.DeletePruzanje_Usluga(pu);
            UslugaBusiness uslugaBusiness = new UslugaBusiness();
            List<Usluga> usluge = uslugaBusiness.UslugaPoKorisniku(pu.Id_korisnika);
            listBox2.Items.Clear();
            foreach (Usluga u in usluge)
            {
                listBox2.Items.Add(u.Id_usluge + ". " + u.Naziv + " - " + u.Cena + " - " + u.Opis);
            }
            MessageBox.Show("Service successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string korisnik1 = comboBox3.SelectedItem.ToString();
            korisnik1 = korisnik1.Substring(0, korisnik1.IndexOf('.'));

            string usluga1 = comboBox4.SelectedItem.ToString();
            usluga1 = usluga1.Substring(0, usluga1.IndexOf('.'));

            int korisnikId1 = Int32.Parse(korisnik1);
            int uslugaId1= Int32.Parse(usluga1);

            PruzanjeUslugaBusiness pruzanjeUslugaBusiness1 = new PruzanjeUslugaBusiness();

            Pruzanje_Usluga pu1 = new Pruzanje_Usluga()
            {
                Id_korisnika = korisnikId1,
                Id_usluge = uslugaId1
            };
            pruzanjeUslugaBusiness1.InsertPruzanje_Usluga(pu1);
            MessageBox.Show("Service successfully assigned", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            Usluga u = new Usluga();
            u.Naziv = comboBox1.Text;
            u.Cena = double.Parse(textBoxPrice.Text);
            u.Opis = textBoxAbout.Text;
            this.uslugaBusiness.InsertUsluga(u);
            MessageBox.Show("Service successfully added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
