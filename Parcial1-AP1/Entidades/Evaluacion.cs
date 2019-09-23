using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_AP1.Entidades
{
    public class Evaluacion
    {
        [Key]
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public decimal  Calificacion { get; set; }
        public decimal PuntosPerdidos { get; set; }
        public int Pronostico { get; set; }

        public Evaluacion()
        {
            EstudianteId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Valor = 0;
            Calificacion = 0;
            PuntosPerdidos = 0;
            Pronostico = 0;
        }
    }
}
