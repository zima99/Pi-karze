using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piłkarze
{
    class Piłkarz
    {
        private string imie;
        private string nazwisko;
        private int wiek;
        private int waga;
        

        public Piłkarz(string imie, string nazwisko, int wiek, int waga)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
            this.waga = waga;
        }

       

        public override string ToString()
        {
            return $"Imię: {imie} Nazwisko: {nazwisko} Wiek: {wiek} Waga: {waga}";
        }
        
        public string Imie
        {
            get => imie;
            set => imie = value;
        }
        public string Nazwisko
        {
            get => nazwisko;
            set => nazwisko = value;
        }
        public int Wiek
        {
            get => wiek;
            set => wiek = value;
        }
        public int Waga
        {
            get => waga;
            set => waga = value;
        }
    }
}
