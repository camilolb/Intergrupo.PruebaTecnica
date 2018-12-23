using Intergrupo.PruebaConcepto.Datos;
using Intergrupo.PruebaTecnica.Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intergrupo.PruebaTecnica.Negocio.Negocio
{
    

    public class NegocioCliente
    {
        public  DominioCliente ObtenerPorId(int id)
        {

            DominioCliente dominioCliente = null;

            using (var dbContext = new PruebaTecnicaEntities())
            {
                var item = dbContext.cliente.Where(x => x.Id == id).FirstOrDefault();

                if (item != null
                    && item.Id > 0)
                {
                    dominioCliente = new DominioCliente();

                    dominioCliente = ObtenerDominioCliente(item);
                }
            }

            return dominioCliente;
        }

        public IList<DominioCliente> ObtenerTodo()
        {
            IList<DominioCliente> listaDominioCliente = null;

            using (var dbContext = new PruebaTecnicaEntities())
            {
                var lista = dbContext.cliente.ToList();

                if (lista != null
                    && lista.Count > 0)
                {
                    listaDominioCliente = new List<DominioCliente>();

                    foreach (var item in lista)
                    {
                        DominioCliente dominioCliente = ObtenerDominioCliente(item);
                        listaDominioCliente.Add(dominioCliente);
                    }
                }
            }
            return listaDominioCliente;
        }

        public DominioCliente Guardar(DominioCliente dominioCliente)
        {
            if (dominioCliente != null
                && !string.IsNullOrEmpty(dominioCliente.Nombres)
                && !string.IsNullOrEmpty(dominioCliente.Apellidos)
                && !string.IsNullOrEmpty(dominioCliente.Telefono)
                && !string.IsNullOrEmpty(dominioCliente.Celular))
            {
                using (var dbContext = new PruebaTecnicaEntities())
                {
                    var resultado = dbContext.cliente.Add(new cliente()
                    {

                        Nombres = dominioCliente.Nombres
                        , Apellidos = dominioCliente.Apellidos
                        , Celular = dominioCliente.Celular
                        , Telefono = dominioCliente.Telefono
                    });


                    if (dbContext.SaveChanges() > 0)
                    {
                        dominioCliente.Id = resultado.Id;
                    }
                }
            }

            return dominioCliente;
        }
         
        public DominioCliente Actualizar(DominioCliente dominioCliente)
        {
            if (dominioCliente != null
            && !string.IsNullOrEmpty(dominioCliente.Nombres)
            && !string.IsNullOrEmpty(dominioCliente.Apellidos)
            && !string.IsNullOrEmpty(dominioCliente.Telefono)
            && !string.IsNullOrEmpty(dominioCliente.Celular))
            {
                using (var dbContext = new PruebaTecnicaEntities())
                {
                    var cliente = dbContext.cliente.Where(x => x.Id == dominioCliente.Id).FirstOrDefault();

                    if (cliente != null
                        && cliente.Id > 0)
                    {
                        cliente.Nombres = dominioCliente.Nombres;
                        cliente.Apellidos = dominioCliente.Apellidos;
                        cliente.Celular = dominioCliente.Celular;
                        cliente.Telefono = dominioCliente.Telefono;

                        dbContext.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                    }
                }
            }

            return dominioCliente;
        }

        public DominioCliente ObtenerDominioCliente(cliente entity)
        {
            DominioCliente dominioCliente = new DominioCliente()
            {
                Id = entity.Id
                , Nombres = entity.Nombres
                , Apellidos = entity.Apellidos
                , Celular = entity.Celular
                , Telefono = entity.Telefono
            };

            return dominioCliente;
        }
    }
}
