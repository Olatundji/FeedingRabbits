using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Observation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateAjout { get; set; } = DateTime.Now;
        public string Note { get; set; }

        [ForeignKey(nameof(Lapin))]
        public int LapinId { get; set; }

        //public virtual Lapin Lapin { get; set; }

        //[ForeignKey(nameof(Lapin))]

        //public Lapin Lapin { get; set; }

    }
}
