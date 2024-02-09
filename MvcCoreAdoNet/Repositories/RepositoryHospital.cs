using MvcCoreAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryHospital
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;User ID=sa;Password=MCSD2023;Encrypt=False";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Hospital> GetHospitales()
        {
            string sql = "SELECT * FROM HOSPITAL";
            this.com.CommandText = sql;
            this.com.CommandType = CommandType.Text;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Hospital> hospitales = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitales.Add(hospital);
            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }

        public Hospital FindHospitalById(int idhospital)
        {
            string sql = "SELECT * FROM HOSPITAL WHERE HOSPITAL_COD = @IDHOSPITAL";
            SqlParameter pamIdHospital =
                new SqlParameter("@IDHOSPITAL", idhospital);
            this.com.Parameters.Add(pamIdHospital);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();
            Hospital hospital = new Hospital();
            hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            hospital.Nombre = this.reader["NOMBRE"].ToString();
            hospital.Direccion = this.reader["DIRECCION"].ToString();
            hospital.Telefono = this.reader["TELEFONO"].ToString();
            hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();
            return hospital;
        }

        public void InsertHospital(int idhospital, string nombre, string direccion, string telefono, int camas)
        {
            string sql = "INSERT INTO HOSPITAL VALUES (@IDHOSPITAL, @NOMBRE, @DIRECCION, @TELEFONO, @CAMAS)";
            SqlParameter paramId = new SqlParameter("@IDHOSPITAL", idhospital);
            SqlParameter paramNombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter paramDirecc = new SqlParameter("@DIRECCION", direccion);
            SqlParameter paramTlf = new SqlParameter("@TELEFONO", telefono);
            SqlParameter paramCamas = new SqlParameter("@CAMAS", camas);
            this.com.Parameters.Add(paramId);
            this.com.Parameters.Add(paramNombre);
            this.com.Parameters.Add(paramDirecc);
            this.com.Parameters.Add(paramTlf);
            this.com.Parameters.Add(paramCamas);
            this.com.CommandText = sql;
            this.com.CommandType = CommandType.Text;
            this.cn.Open();
            int result = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateHospital(Hospital hospital)
        {
            string sql = "UPDATE HOSPITAL SET NOMBRE = @NOMBRE, DIRECCION = @DIRECCION," +
                " TELEFONO = @TELEFONO, NUM_CAMA = @CAMAS WHERE HOSPITAL_COD = @IDHOSPITAL";
            this.com.Parameters.AddWithValue("@IDHOSPITAL", hospital.IdHospital);
            this.com.Parameters.AddWithValue("@NOMBRE", hospital.Nombre);
            this.com.Parameters.AddWithValue("@DIRECCION", hospital.Direccion);
            this.com.Parameters.AddWithValue("@TELEFONO", hospital.Telefono);
            this.com.Parameters.AddWithValue("@CAMAS", hospital.Camas);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int result = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void DeleteHospital(int idhospital)
        {
            string sql = "DELETE FROM HOSPITAL WHERE HOSPITAL_COD = @IDHOSPITAL";
            this.com.Parameters.AddWithValue("@IDHOSPITAL", idhospital);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int result = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
