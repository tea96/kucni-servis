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
    public partial class UserForm : Form
    {
        int ocena = 0;
        Korisnik trenutniKorisnik;
        KorisnikBusiness korisnikBusiness = new KorisnikBusiness();
        OcenaBusiness ocenaBusiness = new OcenaBusiness();
        UslugaBusiness uslugaBusiness = new UslugaBusiness();
        public UserForm(Korisnik korisnik)
        {
            trenutniKorisnik = korisnik;
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void UserForm_Load(object sender, EventArgs e)
        {

            
            comboBox1.Items.AddRange(korisnikBusiness.GetAllKorisnik().Select(x => x.Grad).Distinct().ToArray());
            comboBox1.SelectedIndex = 0;
        }

        private void Fill()
        {
            listBox1.Items.Clear();
            foreach (Korisnik k in korisnikBusiness.GetAllKorisnik())
            {
                if (k.Id_korisnika != trenutniKorisnik.Id_korisnika)
                {
                    listBox1.Items.Add(k.Id_korisnika + ". " +k.Ime+" "+k.Prezime+" "+k.Grad+" "+k.Adresa+" "+k.EMail+" "+k.Broj_telefona);
                }
            }
        }
        private void Fill1()
        {
            listBox1.Items.Clear();
            foreach (Usluga u in uslugaBusiness.GetAllUsluga())
            { 
                    listBox1.Items.Add(u.Id_usluge + ". " + u.Naziv + " " + u.Cena + " " + u.Opis);
                
            }
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            Fill();
        }

        private void buttonCity_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Korisnik k in korisnikBusiness.PretraziPoGradu(comboBox1.GetItemText(comboBox1.SelectedItem)))
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
            foreach (Usluga u in usluge)
            {
                listBox2.Items.Add(u.Id_usluge + ". " + u.Naziv + " - " + u.Cena + " - " + u.Opis);
            }

        }
        private int size = 50;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
            pictureBox3.Height = pictureBox3.Width = size;
            if (pictureBox3.Height == size)
            {
                pictureBox4.Height = 41;
                pictureBox4.Width = 47;
                pictureBox6.Height = 38;
                pictureBox6.Width = 32;
                pictureBox8.Height = 38;
                pictureBox8.Width = 32;
                pictureBox9.Height = 48;
                pictureBox9.Width = 42;
                ocena = 1;
            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            
                pictureBox6.Height = pictureBox6.Width = size;
            if (pictureBox6.Height == size)
            {
                pictureBox4.Height = 41;
                pictureBox4.Width = 47;
                pictureBox3.Height = 48;
                pictureBox3.Width = 42;
                pictureBox8.Height = 38;
                pictureBox8.Width = 32;
                pictureBox9.Height = 48;
                pictureBox9.Width = 42;
                ocena = 2;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
      
            pictureBox4.Height = pictureBox4.Width =65;
            if (pictureBox4.Height == 65)
            {
                pictureBox3.Height = 48;
                pictureBox3.Width = 42;
                pictureBox6.Height = 38;
                pictureBox6.Width = 32;
                pictureBox8.Height = 38;
                pictureBox8.Width = 32;
                pictureBox9.Height = 48;
                pictureBox9.Width = 42;
                ocena = 3;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

           
                pictureBox8.Height = pictureBox8.Width = size;
            if (pictureBox8.Height == size)
            {
                pictureBox4.Height = 41;
                pictureBox4.Width = 47;
                pictureBox6.Height = 38;
                pictureBox6.Width = 32;
                pictureBox3.Height = 48;
                pictureBox3.Width = 42;
                pictureBox9.Height = 48;
                pictureBox9.Width = 42;
                ocena = 4;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            
                pictureBox9.Height = pictureBox9.Width = size;
            if (pictureBox9.Height == size)
            {
                pictureBox4.Height = 41;
                pictureBox4.Width = 47;
                pictureBox6.Height = 38;
                pictureBox6.Width = 32;
                pictureBox8.Height = 38;
                pictureBox8.Width = 32;
                pictureBox3.Height = 48;
                pictureBox3.Width = 42;
                ocena = 5;
            }
        }

        private void buttonOcena_Click(object sender, EventArgs e)
        {
            Ocena upis = new Ocena();
            string s = listBox1.SelectedItem.ToString();
            List<Korisnik> k = new List<Korisnik>();
            k = korisnikBusiness.GetAllKorisnik();
            s = s.Substring(0, s.IndexOf('.'));
            upis.Id_korisnika = int.Parse(s);
            upis.Vrednost = ocena;
            ocenaBusiness.InsertOcena(upis);
            MessageBox.Show("Rating successfully assinged to user", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            pictureBox3.Height = 48;
            pictureBox3.Width = 42;
            pictureBox4.Height = 41;
            pictureBox4.Width = 47;
            pictureBox6.Height = 38;
            pictureBox6.Width = 32;
            pictureBox8.Height = 38;
            pictureBox8.Width = 32;
            pictureBox9.Height = 48;
            pictureBox9.Width = 42;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
