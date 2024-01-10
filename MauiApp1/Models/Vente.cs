using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Vente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateVente { get; set; } = DateTime.Now;
        public double Prix { get; set; }

        [ForeignKey(nameof(Lapin))]
        public int LapinId { get; set; }
    }
}
