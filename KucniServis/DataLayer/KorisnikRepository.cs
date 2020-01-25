using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class KorisnikRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KucniServisBaza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Korisnik> GetAllKorisnik()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Korisnik";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Korisnik> listToReturn = new List<Korisnik>();

                while (sqlDataReader.Read())
                {
                    Korisnik s = new Korisnik();
                    s.Id_korisnika = sqlDataReader.GetInt32(0);
                    s.Ime = sqlDataReader.GetString(1);
                    s.Prezime = sqlDataReader.GetString(2);
                    s.GetSetKorisnickoIme = sqlDataReader.GetString(3);
                    s.Sifra = sqlDataReader.GetString(4);
                    s.Grad= sqlDataReader.GetString(5);
                    s.Adresa= sqlDataReader.GetString(6);
                    s.GetSetEMail= sqlDataReader.GetString(7);
                    s.Admin = sqlDataReader.GetString(8);
                    s.Broj_telefona = sqlDataReader.GetString(9);
                    listToReturn.Add(s);
                }

                return listToReturn;
            }
        }


        public int InsertKorisnik(Korisnik s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Korisnik VALUES(" + string.Format(
                    "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", s.Ime, s.Prezime, s.GetSetKorisnickoIme, s.Sifra, s.Grad, s.Adresa, s.GetSetEMail, s.Broj_telefona, s.Admin) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteKorisnik(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                int countExecuteNonQurey = 0;

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Ocena WHERE Id_korisnikaFK = " + id;
                countExecuteNonQurey += sqlCommand.ExecuteNonQuery();
                sqlCommand.CommandText = "DELETE FROM Korisnik WHERE Id_korisnika = " + id;
                countExecuteNonQurey += sqlCommand.ExecuteNonQuery();

                return countExecuteNonQurey;
            }
        }


        public int UpdateKorisnik(Korisnik s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Korisnik SET Ime = '" + s.Ime +
                    "', Prezime = '" + s.Prezime + "',  KorisnickoIme= '" + s.GetSetKorisnickoIme +
                    "', Sifra = '" + s.Sifra + "', Grad = '" + s.Grad + "', Adresa = '" + s.Adresa +
                    "', EMail = '" + s.GetSetEMail + "', Admin = '" + s.Admin + "' WHERE Id_korisnika = " + s.Id_korisnika;

                return sqlCommand.ExecuteNonQuery();
            }
        }



    }
}
