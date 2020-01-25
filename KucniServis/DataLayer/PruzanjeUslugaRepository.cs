using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PruzanjeUslugaRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KucniServisBaza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Pruzanje_Usluga> GetAllPruzanje_Usluga()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Pruzanje_Usluga";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Pruzanje_Usluga> listToReturn = new List<Pruzanje_Usluga>();

                while (sqlDataReader.Read())
                {
                    Pruzanje_Usluga s = new Pruzanje_Usluga();
                    s.Id_korisnika = sqlDataReader.GetInt32(0);
                    s.Id_usluge = sqlDataReader.GetInt32(1);
                      listToReturn.Add(s);
                }

                return listToReturn;
            }
        }


        public int InsertPruzanje_Usluga(Pruzanje_Usluga s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Pruzanje_Usluga VALUES(" + string.Format(
                    "'{0}', '{1}'", s.Id_korisnika, s.Id_usluge) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeletePruzanje_Usluga(Pruzanje_Usluga s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Pruzanje_Usluga WHERE Id_korisnika = " + s.Id_korisnika + " AND Id_usluge = " + s.Id_usluge;

                return sqlCommand.ExecuteNonQuery();
            }
        }


    }
}
