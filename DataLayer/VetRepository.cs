using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VetRepository
    {
        public List<Vet> GetAllVets()
        {
            List<Vet> vetList = new List<Vet>();
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string commandText = "Select * from Vets";
                SqlCommand com = new SqlCommand(commandText, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    Vet v = new Vet(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3));
                    vetList.Add(v);
                }
                return vetList;
            }

        }
        public int insertVet(Vet v)
        {
            int result;
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string commandText = "Insert into Vets(FullName,Specialty,YearsExperience) values (@FullName,@Specialty,@YearsExperience) ";
                SqlCommand com = new SqlCommand(commandText, con);
                com.Parameters.AddWithValue("@fullName", v.fullName);
                com.Parameters.AddWithValue("@Specialty", v.specialty);
                com.Parameters.AddWithValue("@YearsExperience", v.yearsExperience);
                result = com.ExecuteNonQuery();
            }
            return result;
        }
        public int deletVet(int vetId)
        {
            int result;
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string commandText = "Delete from Vets where id=@id";
                SqlCommand com = new SqlCommand(commandText, con);
                com.Parameters.AddWithValue("@id", vetId);
                result = com.ExecuteNonQuery();
            }
            return result;
        }
    }
}
