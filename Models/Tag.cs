using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int ProdutoId { get; set; }
    }
}