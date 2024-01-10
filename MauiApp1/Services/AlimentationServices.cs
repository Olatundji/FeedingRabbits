using MauiApp1.Models;
using SQLite;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace MauiApp1.Services
{
    public class AlimentationServices : IAlimentationServices
    {
        private SQLiteAsyncConnection _dbConnection;

        public AlimentationServices()
        {
            // Ne rien initialiser ici
        }
        private async Task SetUpDb()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestLapin.db3");
            _dbConnection = new SQLiteAsyncConnection(dbPath);

            //    Créer la table User
            await _dbConnection.CreateTableAsync<Alimentation>();
        }
        public double CalculerQuantiteAliment(string categorie, double poids, DateTime naissance, string nom)
        {
            const double quantiteMaleReproducteur = 150;
            const double quantiteFemelleReproductrice = 150;
            const double quantiteFemelleGestante = 150;
            const double quantiteFemelleAllaitante = 350;
            const double quantiteLapereaux = 100;
            const double quantiteGranulesSupplementaires = 10;
            const double quantiteGranules = 10;
            const double quantiteGranulesSupplementairesSecond = 10;
            const double quantiteGranulesSupplementairesthird = 20;


            double quantite = 0;
            int ageInDays = (DateTime.Today - naissance).Days;
            if (nom == "Granulés") 
            {
                switch (categorie)
                {
                    case "Male reproducteur":
                        quantite = quantiteMaleReproducteur;
                        if (poids > 5)
                        {
                            quantite = quantite - quantiteGranulesSupplementaires;
                        }
                        break;
                    case "Femelle reproductrice":
                        quantite = quantiteFemelleReproductrice;
                        break;
                    case "Femelle gestante":
                        quantite = quantiteFemelleGestante;
                        if (poids > 3)
                        {
                            quantite = quantite - quantiteGranules;
                        }
                        break;
                    case "Femelle allaitante":
                        quantite = quantiteFemelleAllaitante;
                        break;
                    case "Lapereaux":
                        if (ageInDays < 35)
                        {
                            quantite = 0;
                        }
                        else if (ageInDays > 35 && poids > 0.8)
                        {
                            quantite = quantiteLapereaux;
                        }
                        else if (ageInDays > 35 && poids > 1.2)
                        {
                            quantite += quantiteGranulesSupplementairesSecond;
                        }
                        else if (ageInDays > 35 && poids > 1.5)
                        {
                            quantite += quantiteGranulesSupplementairesthird;
                        }
                        else
                        {
                            Console.WriteLine("Alerte", "Une erreur s'est produite", "OK");
                        }
                        break;
                } 
            }
            else
            {
                Console.WriteLine("Alerte", "Une erreur s'est produite", "OK");
            }
            return quantite;
        }

        public double CalculerQuantiteEau(string categorie, string nom)
        {
            const double quantitelitreeauMale = 1;
            const double quantitelitreeauReproductrice = 1;
            const double quantitelitreeauGestante = 1;
            const double quantitelitreeauAllaitante = 2;
            const double quantitelitreeauLapereaux = 1;

            double quantiteEau = 0;
            if (nom == "Granulés")
            {
                switch (categorie)
                {
                    case "Male reproducteur":
                        quantiteEau = quantitelitreeauMale;
                        break;
                    case "Femelle reproductrice":
                        quantiteEau = quantitelitreeauReproductrice;
                        break;
                    case "Femelle gestante":
                        quantiteEau = quantitelitreeauGestante;
                        break;
                    case "Femelle allaitante":
                        quantiteEau = quantitelitreeauAllaitante;
                        break;
                    case "Lapereaux":
                        quantiteEau = quantitelitreeauLapereaux;
                        break;
                }
            }
            //else
            //{
            //    Console.WriteLine("Alerte", "Une erreur s'est produite", "OK");
            //}
            return quantiteEau;
        }

        //public double CalculerQuantiteAliment(string Categorie, double Poids, DateTime Naissance, string Nom)
        //{
        //    double Quantite = 0;

        //    switch (Categorie)
        //    {
        //        case "Male Reproducteur":
        //            Quantite = 160;
        //            break;
        //        case "Femelle Reproductrice":
        //            Quantite = 150;
        //            break;
        //        case "Femelle Gestante":
        //            Quantite = 150;
        //            break;
        //        case "Femelle Allaitante":
        //            Quantite = 350;
        //            break;
        //        case "Lapreaux":
        //            Quantite = 100;
        //            break;
        //    }

        //    if (Nom == "Granulés")
        //    {
        //        if (Categorie == "Male Reproducteur")
        //        {
        //            if (Poids > 25)
        //            {
        //                Quantite += 10;
        //            }
        //            return Quantite;
        //        }
        //        else if (Categorie == "Femelle Reproductrice")
        //        {
        //            Quantite = 150;
        //            return Quantite;
        //        }
        //        else if (Categorie == "Femelle Gestante")
        //        {
        //            Quantite = 150;
        //            return Quantite;
        //        }
        //        else if (Categorie == "Femelle Allaitante")
        //        {
        //            Quantite = 150;
        //            return Quantite;
        //        }
        //        else if (Categorie == "Lapereaux")
        //        {
        //            if (Naissance.Day < 35)
        //            {
        //                Quantite = 120;
        //            }
        //            else if (Naissance.Day > 35)
        //            {
        //                Quantite = 100;
        //            }
        //            else if (Poids > 5 && Naissance.Day > 35)
        //            {
        //                Quantite = 100;
        //            }
        //            else if (Poids > 10 && Naissance.Day > 35)
        //            {
        //                Quantite = 100;
        //            }
        //            return Quantite;
        //        }
        //    }

        //    return Quantite;
        //}

        public async Task<Lapin> GetLapinById(int id)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            return await _dbConnection.FindAsync<Lapin>(id);
        }

        public async Task<Aliment> GetAlimentById(int id)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            return await _dbConnection.FindAsync<Aliment>(id);
        }

        public async Task<IEnumerable<Lapin>> GetAllLapins()
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var allLapins = await _dbConnection.Table<Lapin>().ToListAsync();

            return allLapins;
        }

        public async Task<IEnumerable<Aliment>> GetAllAliments()
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            var allAliments = await _dbConnection.Table<Aliment>().ToListAsync();

            return allAliments;
        }

        public async Task UpdateAliment(Aliment aliment)
        {
            if (_dbConnection == null)
            {
                await SetUpDb();
            }

            await _dbConnection.UpdateAsync(aliment);
        }
    }
}
