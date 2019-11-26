using System;
using System.Collections.Generic;

namespace cadastro_pessoa_api.Models
{
    public partial class Email
    {
        public int? Id { get; set; }
        public string Email1 { get; set; }
        public string Tipo { get; set; }
        public int PessoaId { get; set; }

        //public virtual Pessoa Pessoa { get; set; }
    }
}
