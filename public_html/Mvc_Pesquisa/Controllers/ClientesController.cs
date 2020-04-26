using Mvc_Pesquisa.Models;
using Mvc_Pesquisa.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Mvc_Pesquisa.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Pesquisa()
        {
            using (var db = new EstudoEntities())
            {
                var _cliente = db.Clientes.ToList();
                var data = new ClienteVM()
                {
                    Clientes = _cliente
                };
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Pesquisa(ClienteVM _clientevm)
        {
            using (var db = new EstudoEntities())
            {
                var clientePesquisa = from clienterec in db.Clientes
                                      where ((_clientevm.Nome == null) || (clienterec.Nome == _clientevm.Nome.Trim()))
                                      && ((_clientevm.Cidade == null) || (clienterec.Cidade == _clientevm.Cidade.Trim()))
                                      && ((_clientevm.Estado == null) || (clienterec.Estado == _clientevm.Estado.Trim()))
                                      select new
                                      {
                                          Id = clienterec.Id,
                                          Nome = clienterec.Nome,
                                          Cidade = clienterec.Cidade,
                                          Estado = clienterec.Estado
                                      };
                List<Cliente> listaClientes = new List<Cliente>();
                foreach (var reg in clientePesquisa)
                {
                    Cliente clientevalor = new Cliente();
                    clientevalor.Id = reg.Id;
                    clientevalor.Nome = reg.Nome;
                    clientevalor.Cidade = reg.Cidade;
                    clientevalor.Estado = reg.Estado;
                    listaClientes.Add(clientevalor);
                }
                _clientevm.Clientes = listaClientes;
                return View(_clientevm);
            }
        }
    }
}