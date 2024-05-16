using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUTNMauiCuascotaRoberto.Models
{
    internal class Videojuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public double Precio { get; set; }
        public int Tienda_onlineId { get; set; }
    }
}
