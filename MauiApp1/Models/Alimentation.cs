using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Alimentation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateAlim { get; set; } = DateTime.Now;
        public double Quantite { get; set; }
        public string Commentaire { get; set; }

        [ForeignKey(nameof(Lapin))]
        public int LapinId { get; set; }
        //public virtual Lapin Lapin { get; set; }

        [ForeignKey(nameof(Aliment))]
        public int AlimentId { get; set; }

        //public virtual Aliment Aliment { get; set; }



        //[ForeignKey("lapin")]
        //public int LapinId { get; set; }
        //public virtual Lapin lapin { get; set; }

        //[ForeignKey("aliment")]
        //public int AlimentId { get; set; }
        //public virtual Aliment aliment { get; set; }


    }
}
