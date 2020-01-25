using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer.Models;
using System.Windows.Input;

namespace PresentationLayer
{
    public partial class Login : Form
    {
        private KorisnikBusiness korisnikBusiness = new KorisnikBusiness();
        public Login()
        {
            InitializeComponent();
        }
        

        private void buttonLog_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = korisnikBusiness.Login(textBoxUn.Text, textBoxPass.Text);
            if (korisnik == null)
            {
                MessageBox.Show("Wrong username or password!", "Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBoxUn.Clear();
                textBoxPass.Clear();
                return;
            }
            else if(!(korisnik.Admin=="false"))
            {
                MessageBox.Show("Admin successfully logged in!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                AdminForm af = new AdminForm(korisnik);
                af.Show();
                this.Hide();
                
            }
             else
            {
                MessageBox.Show("User successfully logged in!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                UserForm uf = new UserForm(korisnik);
                uf.Show();
                this.Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLog.PerformClick();
            }
        }
    }
    }

