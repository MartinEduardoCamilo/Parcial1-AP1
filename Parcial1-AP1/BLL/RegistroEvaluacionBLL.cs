using Parcial1_AP1.DAL;
using Parcial1_AP1.Entidades;
using System;
using System.Data.Entity;

namespace Parcial1_AP1.BLL
{
    public class RegistroEvaluacionBLL
    {
        public static bool Guardar(Evaluacion evaluacion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if(db.Evaluacions.Add(evaluacion) != null)
                {
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Evaluacion evaluacion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        
        public static Evaluacion Buscar(int id)
        {
            Contexto db = new Contexto();
            Evaluacion evaluacion = new Evaluacion();
            try
            {
                evaluacion = db.Evaluacions.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return evaluacion;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Evaluacions.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
    }
}
