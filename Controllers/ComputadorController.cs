using Examen1.Clases;
using Examen1.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen1.Controllers
{
    [RoutePrefix("api/Computadores")]
    public class ComputadorController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Computador> ConsultarTodos()
        {
            clsComputador computador = new clsComputador();
            return computador.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Computador ConsultarXId(int idComputador)
        {
            clsComputador computador = new clsComputador();
            return computador.Consultar(idComputador);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Computador computador)
        {
            clsComputador comp = new clsComputador();
            comp.computador = computador;
            return comp.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Computador computador)
        {
            clsComputador comp = new clsComputador();
            comp.computador = computador;
            return comp.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idComputador)
        {
            clsComputador comp = new clsComputador();
            comp.computador = new Computador { IdComputador = idComputador };
            return comp.Eliminar();
        }
    }
}