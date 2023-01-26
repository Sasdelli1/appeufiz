using System;
using System.Collections.Generic;
using System.Text;

namespace appeufiz.Models
{
    public class Local
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
