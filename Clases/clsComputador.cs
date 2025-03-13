using Examen1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Examen1.Clases
{
    public class clsComputador
    {
        private Examen1Entities dbContext = new Examen1Entities();

        public Computador computador { get; set; }

        public string Insertar()
        {
            try
            {
                dbContext.Computadors.Add(computador);
                dbContext.SaveChanges();
                return "Computador insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el computador: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Computador comp = Consultar(computador.IdComputador);
                if (comp == null)
                {
                    return "El computador con el ID ingresado no existe, por lo tanto no se puede actualizar";
                }

                dbContext.Computadors.AddOrUpdate(computador);
                dbContext.SaveChanges();
                return "Se actualizó el computador correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el computador: " + ex.Message;
            }
        }

        public List<Computador> ConsultarTodos()
        {
            return dbContext.Computadors
                .OrderBy(c => c.IdComputador)
                .ToList();
        }

        public Computador Consultar(int idComputador)
        {
            return dbContext.Computadors.FirstOrDefault(c => c.IdComputador == idComputador);
        }

        public string Eliminar()
        {
            try
            {
                Computador comp = Consultar(computador.IdComputador);
                if (comp == null)
                {
                    return "El computador con el ID ingresado no existe, por lo tanto no se puede eliminar";
                }
                dbContext.Computadors.Remove(comp);
                dbContext.SaveChanges();
                return "Se eliminó el computador correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el computador: " + ex.Message;
            }
        }
    }
}
