namespace MvcCoreAdoNet.Models
{
    public class Mascota
    {
        public Mascota(string nombre, string especie, string raza, int edad)
        {
            Nombre = nombre;
            Especie = especie;
            Raza = raza;
            Edad = edad;
        }

        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }

        public int Edad { get; set; }
    }
}
