﻿using System;
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
        public int Evaluacionid { get; set; }
        public DateTime Fecha { get; set; }
        public string Estudiante { get; set; }
        public decimal Valor { get; set; }
        public decimal  Logrado { get; set; }
        public decimal PuntosPerdidos { get; set; }
        public int Pronostico { get; set; }

        public Evaluacion()
        {
            Evaluacionid = 0;
            Fecha = DateTime.Now;
            Estudiante = string.Empty;
            Valor = 0;
            Logrado = 0;
            PuntosPerdidos = 0;
            Pronostico = 0;
        }
    }
}
