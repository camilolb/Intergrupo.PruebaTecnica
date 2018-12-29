using Intergrupo.PruebaTecnica.Negocio.Dominio;
using Intergrupo.PruebaTecnica.Negocio.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Intergrupo.PruebaTecnica.Presentacion_.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                IList<DominioCliente> listaClientes = new NegocioCliente().ObtenerTodo();

                if (listaClientes != null
                    && listaClientes.Count > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listaClientes));
                }
                
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // GET: api/Cliente/5
        public HttpResponseMessage Get(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                if (id > 0)
                {
                    DominioCliente dominioCliente = new NegocioCliente().ObtenerPorId(id);

                    if (dominioCliente != null
                        && dominioCliente.Id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(dominioCliente));
                    }
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // POST: api/Cliente
        public HttpResponseMessage Post(DominioCliente dominioCliente)
        {
            var response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                if (dominioCliente != null
                    && !string.IsNullOrEmpty(dominioCliente.Nombres)
                    && !string.IsNullOrEmpty(dominioCliente.Apellidos)
                    && !string.IsNullOrEmpty(dominioCliente.Telefono)
                    && !string.IsNullOrEmpty(dominioCliente.Celular))
                {
                    dominioCliente = new NegocioCliente().Guardar(dominioCliente);

                    if (dominioCliente.Id > 0)
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(dominioCliente));
                    }
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // PUT: api/Cliente/5
        public HttpResponseMessage Put(DominioCliente dominioCliente)
        {
            var response = Request.CreateResponse(HttpStatusCode.InternalServerError);

            try
            {
                if (dominioCliente != null
                && !string.IsNullOrEmpty(dominioCliente.Nombres)
                && !string.IsNullOrEmpty(dominioCliente.Apellidos)
                && !string.IsNullOrEmpty(dominioCliente.Telefono)
                && !string.IsNullOrEmpty(dominioCliente.Celular))
                {

                    dominioCliente = new NegocioCliente().Actualizar(dominioCliente);

                    response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(dominioCliente));
                }

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

            return response;
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
