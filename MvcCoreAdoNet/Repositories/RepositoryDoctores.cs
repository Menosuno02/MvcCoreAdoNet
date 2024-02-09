using MvcCoreAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctores
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;User ID=sa;Password=MCSD2023;Encrypt=False"; ;
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "SELECT * FROM DOCTOR";
            this.com.CommandText = sql;
            this.com.CommandType = CommandType.Text;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                int hospitalCod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                int doctorNo = int.Parse(this.reader["DOCTOR_NO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                string especialidad = this.reader["ESPECIALIDAD"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                Doctor doctor = new Doctor(hospitalCod, doctorNo, apellido, especialidad, salario);
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.cn.Close();
            return doctores;
        }

        public List<Doctor> GetDoctoresPorEspecialidad(string? especialidad)
        {
            string sql = "SELECT * FROM DOCTOR WHERE ESPECIALIDAD = @ESPECIALIDAD";
            this.com.Parameters.AddWithValue("@ESPECIALIDAD", especialidad);
            this.com.CommandText = sql;
            this.com.CommandType = CommandType.Text;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                int hospitalCod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                int doctorNo = int.Parse(this.reader["DOCTOR_NO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                Doctor doctor = new Doctor(hospitalCod, doctorNo, apellido, especialidad, salario);
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();
            return doctores;
        }

        public List<string> GetEspecialidades()
        {
            string sql = "SELECT DISTINCT ESPECIALIDAD FROM DOCTOR";
            this.com.CommandText = sql;
            this.com.CommandType = CommandType.Text;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> especialidades = new List<string>();
            while (this.reader.Read())
            {
                especialidades.Add(this.reader["ESPECIALIDAD"].ToString());
            }
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();
            return especialidades;
        }
    }
}
