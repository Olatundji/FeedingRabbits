using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Lapin
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Code { get; set; }
        public string CodeParent { get; set; }
        public string Race { get; set; }
        public double Poids { get; set;}
        public double Taille { get; set; }
        public string Sexe { get; set; }
        public DateTime Naissance { get; set; } = DateTime.Now;
        public string Categorie { get; set; }
        public bool Malade { get; set; }
        public DateTime Vente { get; set; } = DateTime.Now;
        public bool Deces { get; set; }
        public Action<object, PropertyChangedEventArgs> PropertyChanged { get; internal set; }
        //public int LapinId { get; internal set; }

        //[ForeignKey(nameof(LapinType))] public int
        //TypeId { get; set; }
        //public virtual ObservableCollection<Observation> Observations { get; set; }
        //public virtual ICollection<Type> Types { get; set; } 
        //public virtual ICollection<Alimentation> Alimentations { get; set; }
    }
}
