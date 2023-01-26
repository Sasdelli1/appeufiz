using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace appeufiz.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public Boolean Status { get; set; }
        public string Messagem { get; set; }

    }
}
