using Mvc_Pesquisa.Models;
using System.Collections.Generic;

namespace Mvc_Pesquisa.ViewModels
{
    public class ClienteVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public List<Cliente> Clientes { get; set; }
    }
}