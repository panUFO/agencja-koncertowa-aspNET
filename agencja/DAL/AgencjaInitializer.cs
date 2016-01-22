using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using agencja.Models;

namespace agencja.DAL
{
    public class AgencjaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AgencjaContext>
    {


        protected override void Seed(AgencjaContext context)
        {
            var kluby = new List<Klub>
            {
            new Klub{Nazwa="B90",Miasto="Gdańsk",Ilosc_miejsc=2000},
            new Klub{Nazwa="Progresja",Miasto="Warszawa",Ilosc_miejsc=1500},

            };

            kluby.ForEach(s => context.Kluby.Add(s));
            context.SaveChanges();

            var koncerty = new List<Koncert>
            {
            new Koncert{IDKlub=1,Nazwa="Stonemite",cena_biletu=30,},
            new Koncert{IDKlub=2,Nazwa="Metalfest",cena_biletu=230,},

            };
            koncerty.ForEach(s => context.Koncerty.Add(s));
            context.SaveChanges();



            var pracownicy = new List<Pracownik>
            {
            new Pracownik{Imie="Kamil",Nazwisko="Liwiński",Plec="m", Stanowisko="programistaPDF", Pesel="93092612617"},
            };
            pracownicy.ForEach(s => context.Pracownicy.Add(s));
            context.SaveChanges();

        }

    }
}