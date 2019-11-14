using System;
using System.Collections.Generic;

namespace cadastro_pessoa_api.Models
{
    public partial class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UfId { get; set; }

        public virtual Uf Uf { get; set; }
    }
}
