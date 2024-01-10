using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Aliment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        //public virtual ICollection<Alimentation> Alimentations { get; set; }

    }
}
