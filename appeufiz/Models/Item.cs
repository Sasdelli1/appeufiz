using SQLite;
using System;

namespace appeufiz.Models
{
    public class Item
    {
        [PrimaryKey,AutoIncrement]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}