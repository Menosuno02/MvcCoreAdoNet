namespace MvcCoreAdoNet.Models
{
    public class Doctor
    {
        public Doctor(int hospitalCod, int doctorNo, string apellido, string especialidad, int salario)
        {
            HospitalCod = hospitalCod;
            DoctorNo = doctorNo;
            Apellido = apellido;
            Especialidad = especialidad;
            Salario = salario;
        }

        public int HospitalCod { get; set; }
        public int DoctorNo { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public int Salario { get; set; }
    }
}
