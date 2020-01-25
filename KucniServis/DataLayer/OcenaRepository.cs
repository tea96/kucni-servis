using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OcenaRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KucniServisBaza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Ocena> GetAllOcena()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Ocena";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Ocena> listToReturn = new List<Ocena>();

                while (sqlDataReader.Read())
                {
                    Ocena s = new Ocena();
                    s.Id_ocene= sqlDataReader.GetInt32(0);
                    s.Id_korisnika = sqlDataReader.GetInt32(1);
                    s.Vrednost = sqlDataReader.GetInt32(2);
                    listToReturn.Add(s);
                }

                return listToReturn;
            }
        }


        public int InsertOcena(Ocena s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Ocena VALUES(" + string.Format(
                    "'{0}','{1}'", s.Id_korisnika, s.Vrednost) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteOcena(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Ocena WHERE Id_ocene = " + id;

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateOcena(Ocena s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Ocena SET Id_korisnikaFK = '" + s.Id_korisnika +
                    "', Vrednost = '" + s.Vrednost +  "' WHERE Id_ocene = " + s.Id_ocene;

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
