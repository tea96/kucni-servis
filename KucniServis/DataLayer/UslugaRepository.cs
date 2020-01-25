using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UslugaRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KucniServisBaza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Usluga> GetAllUsluga()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Usluga";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Usluga> listToReturn = new List<Usluga>();

                while (sqlDataReader.Read())
                {
                    Usluga s = new Usluga();
                    s.Id_usluge = sqlDataReader.GetInt32(0);
                    s.Naziv = sqlDataReader.GetString(1);
                    s.Cena = sqlDataReader.GetDouble(2);
                    s.Opis = sqlDataReader.GetString(3);
                    listToReturn.Add(s);
                }

                return listToReturn;
            }
        }


        public int InsertUsluga(Usluga s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Usluga VALUES(" + string.Format(
                    "'{0}', '{1}', '{2}'", s.Naziv, s.Cena,s.Opis) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteUsluga(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Usluga WHERE Id_usluge = " + id;

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Usluga> UslugaPoKorisniku(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT p.*, pu.Id_korisnika FROM Usluga p join (Pruzanje_Usluga pu join Korisnik k on k.Id_korisnika=pu.Id_korisnika ) on p.Id_usluge=pu.Id_usluge WHERE k.Id_korisnika=" + id;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Usluga> listToReturn = new List<Usluga>();

                while (sqlDataReader.Read())
                {
                    Usluga s = new Usluga();
                    s.Id_usluge = sqlDataReader.GetInt32(0);
                    s.Naziv = sqlDataReader.GetString(1);
                    s.Cena = sqlDataReader.GetDouble(2);
                    s.Opis = sqlDataReader.GetString(3);
                    listToReturn.Add(s);
                }

                return listToReturn;
            }
        }







    }
}
