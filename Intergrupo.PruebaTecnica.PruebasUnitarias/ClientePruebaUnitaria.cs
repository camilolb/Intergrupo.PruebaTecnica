using System;
using Intergrupo.PruebaConcepto.Datos;
using Intergrupo.PruebaTecnica.Negocio.Negocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Intergrupo.PruebaTecnica.Negocio.Dominio;

namespace Intergrupo.PruebaTecnica.PruebasUnitarias
{
    [TestClass]
    public class ClientePruebaUnitaria
    {
        [TestMethod]
        public void ObtenerTodosLosClientes()
        {
            IList<DominioCliente> listaClientes = new List<DominioCliente>();
            listaClientes = new NegocioCliente().ObtenerTodo();

            Assert.IsNotNull(listaClientes);
            Assert.IsTrue(listaClientes.Count > 0);
        }
    }
}
