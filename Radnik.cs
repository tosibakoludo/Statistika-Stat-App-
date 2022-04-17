using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistika__Stat_App_
{
    public class Radnik
    {
        int sifra; //Id INTEGER
        string imePrezime; //EmployeeName TEXT
        string zanimanje; //JobTitle TEXT
        double plata; //BasePay NUMERIC
        double prekovremeni; //OvertimePay NUMERIC
        double ostalo; //OtherPay NUMERIC
        double benefiti; //Benefits NUMERIC
        double ukupno; //TotalPay NUMERIC
        double ukupnoSaBenefitima; //TotalPayBenefits NUMERIC
        int godina; //Year INTEGER
        string beleske; //Notes TEXT
        string mesto; //Agency TEXT
        string status; //Status TEXT

        public Radnik(int sifra, string imePrezime, string zanimanje, double plata, double prekovremeni, double ostalo, double benefiti, double ukupno, double ukupnoSaBenefitima, int godina, string beleske, string mesto, string status)
        {
            this.sifra = sifra;
            this.imePrezime = imePrezime;
            this.zanimanje = zanimanje;
            this.plata = plata;
            this.prekovremeni = prekovremeni;
            this.ostalo = ostalo;
            this.benefiti = benefiti;
            this.ukupno = ukupno;
            this.ukupnoSaBenefitima = ukupnoSaBenefitima;
            this.godina = godina;
            this.beleske = beleske;
            this.mesto = mesto;
            this.status = status;
        }

        public int Sifra { get => sifra; set => sifra = value; }
        public string ImePrezime { get => imePrezime; set => imePrezime = value; }
        public string Zanimanje { get => zanimanje; set => zanimanje = value; }
        public double Plata { get => plata; set => plata = value; }
        public double Prekovremeni { get => prekovremeni; set => prekovremeni = value; }
        public double Ostalo { get => ostalo; set => ostalo = value; }
        public double Benefiti { get => benefiti; set => benefiti = value; }
        public double Ukupno { get => ukupno; set => ukupno = value; }
        public double UkupnoSaBenefitima { get => ukupnoSaBenefitima; set => ukupnoSaBenefitima = value; }
        public int Godina { get => godina; set => godina = value; }
        public string Beleske { get => beleske; set => beleske = value; }
        public string Mesto { get => mesto; set => mesto = value; }
        public string Status { get => status; set => status = value; }

        public override string ToString()
        {
            return sifra + " " + imePrezime + " " + godina;
        }
    }
}
