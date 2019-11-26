using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace cadastro_pessoa_api.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Emails = new HashSet<Email>();
            Fones = new HashSet<Fone>();
        }

        public int Id { get; set; }
        public string NomeRazao { get; set; }
        public string CpfCnpj { get; set; }
        public string TipoPessoa { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int BairroId { get; set; }
        public int CidadeId { get; set; }

        public virtual Bairro Bairro { get; set; }
        public virtual Cidade Cidade { get; set; }        
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Fone> Fones { get; set; }
    }
}
