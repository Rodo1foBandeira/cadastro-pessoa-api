using System;
using System.Collections.Generic;

namespace cadastro_pessoa_api.Models
{
    public partial class LogPessoa
    {
        public int IdLog { get; set; }
        public DateTime? DataModificacao { get; set; }
        public int? Id { get; set; }
        public string NomeRazao { get; set; }
        public string CpfCnpj { get; set; }
        public string TipoPessoa { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int BairroId { get; set; }
        public int CidadeId { get; set; }
    }
}
