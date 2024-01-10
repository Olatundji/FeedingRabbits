
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MauiApp1.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Profil { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
