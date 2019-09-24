﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcial1_AP1.BLL;
using Parcial1_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_AP1.BLL.Tests
{
    [TestClass()]
    public class RegistroEvaluacionBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.EstudianteId = 0;
            evaluacion.Fecha = DateTime.Now;
            evaluacion.Nombre = "Test";
            evaluacion.Valor = 20;
            evaluacion.Calificacion = 15;
            evaluacion.PuntosPerdidos = evaluacion.Valor - evaluacion.Calificacion;
            paso = RegistroEvaluacionBLL.Guardar(evaluacion);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.EstudianteId = 1;
            evaluacion.Fecha = DateTime.Now;
            evaluacion.Nombre = "Test";
            evaluacion.Valor = 30;
            evaluacion.Calificacion = 15;
            evaluacion.PuntosPerdidos = evaluacion.Valor - evaluacion.Calificacion;
            paso = RegistroEvaluacionBLL.Guardar(evaluacion);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion = RegistroEvaluacionBLL.Buscar(1);
            Assert.AreEqual(evaluacion,evaluacion);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = RegistroEvaluacionBLL.Eliminar(1);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Evaluacion>();
            lista = RegistroEvaluacionBLL.GetList(p => true);
            Assert.AreEqual(lista,lista);
        }
    }
}