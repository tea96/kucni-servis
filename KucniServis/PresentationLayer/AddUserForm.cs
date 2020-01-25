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
    public partial class AddUserForm : Form
    {
        Korisnik trenutniKorisnik;
        KorisnikBusiness korisnikBusiness = new KorisnikBusiness();
        public AddUserForm(Korisnik korisnik)
        {
            trenutniKorisnik = korisnik;
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("true");
            comboBox1.Items.Add("false");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Korisnik k = new Korisnik();
            k.Ime = textBox1.Text;
            k.Prezime = textBox2.Text;
            k.KorisnickoIme = textBox3.Text;
            k.Sifra = textBox4.Text;
            k.Grad = textBox5.Text;
            k.Adresa = textBox6.Text;
            k.EMail = textBox7.Text;
            k.Broj_telefona = comboBox1.Text;
            k.Admin = textBox8.Text;
            this.korisnikBusiness.InsertKorisnik(k);
            MessageBox.Show("The user successfully added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminForm ad = new AdminForm(trenutniKorisnik);
            ad.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
