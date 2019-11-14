using System;
using System.Collections.Generic;

namespace cadastro_pessoa_api.Models
{
    public partial class Fone
    {
        public int Id { get; set; }
        public int? Ddd { get; set; }
        public int? Numero { get; set; }
        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
