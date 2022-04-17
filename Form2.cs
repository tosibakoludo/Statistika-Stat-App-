using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Statistika__Stat_App_
{
    public partial class Form2 : Form
    {
        List<Radnik> L;
        public Form2(List<Radnik> L)
        {
            InitializeComponent();
            this.L = L;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Dictionary<int, double> R = new Dictionary<int, double>();
            foreach (Radnik r in L)
            {
                if (R.Keys.Contains(r.Godina))
                {
                    R[r.Godina] += r.Plata;
                }
                else
                {
                    R[r.Godina] = r.Plata;
                }
            }

            chart1.Series[0].Name = "Ukupni troškovi za plate radnika od 2011 do 2014";

            int i = 0;
            foreach (int godina in R.Keys)
            {
                chart1.Series[0].Points.Add(R[godina]);
                chart1.Series[0].Points[i].AxisLabel = godina.ToString();
                i++;
            }

            Dictionary<string, double> R1 = new Dictionary<string, double>();
            R1["I kategorija (do 50000 USD)"] = 0;
            R1["II kategorija (do 100000 USD)"] = 0;
            R1["III kategorija (do 200000 USD)"] = 0;
            R1["IV kategorija (preko 200000 USD)"] = 0;
            foreach (Radnik r in L)
            {
                if (r.UkupnoSaBenefitima <= 50000)
                {
                    R1["I kategorija (do 50000 USD)"]++;
                }
                else if (r.UkupnoSaBenefitima <= 100000)
                {
                    R1["II kategorija (do 100000 USD)"]++;
                }
                else if (r.UkupnoSaBenefitima <= 200000)
                {
                    R1["III kategorija (do 200000 USD)"]++;
                }
                else
                {
                    R1["IV kategorija (preko 200000 USD)"]++;
                }
            }

            Title pieTitle = new Title("Plate radnika po kategorijama", Docking.Top, new Font("Microsoft Sans Serif", 12), Color.Black);
            chart2.Titles.Add(pieTitle);

            i = 0;
            foreach (string kategorija in R1.Keys)
            {
                chart2.Series[0].Points.Add(R1[kategorija]);
                chart2.Series[0].Points[i].LegendText = kategorija;
                chart2.Series[0].Points[i].AxisLabel = R1[kategorija].ToString();
                i++;
            }

            Dictionary<string, int> R2 = new Dictionary<string, int>();
            foreach (Radnik r in L)
            {
                if (R2.Keys.Contains(r.Zanimanje.ToUpper()))
                {
                    R2[r.Zanimanje.ToUpper()]++;
                }
                else
                {
                    R2[r.Zanimanje.ToUpper()] = 1;
                }
            }

            Dictionary<string, int> R3 = new Dictionary<string, int>();
            for (int j = 0; j < 10; j++)
            {
                int max = R2.Values.Max();
                string brisi = "";
                foreach (string zanimanje in R2.Keys)
                {
                    if (R2[zanimanje] == max)
                    {
                        brisi = zanimanje;
                        R3[zanimanje] = R2[zanimanje];
                    }
                }
                R2.Remove(brisi);
            }

            Dictionary<string, double> R4 = new Dictionary<string, double>();
            foreach (Radnik r in L)
            {
                if (R3.Keys.Contains(r.Zanimanje.ToUpper()) && R4.Keys.Contains(r.Zanimanje.ToUpper()))
                {
                    R4[r.Zanimanje.ToUpper()] += r.Plata;
                }
                else if (R3.Keys.Contains(r.Zanimanje.ToUpper()))
                {
                    R4[r.Zanimanje.ToUpper()] = r.Plata;
                }
            }
            foreach (string zanimanje in R3.Keys)
            {
                R4[zanimanje] = R4[zanimanje] / R3[zanimanje];
            }

            chart3.Series[0].Name = "Prosečne plate najčešćih zanimanja";

            i = 0;
            foreach (string zanimanje in R4.Keys)
            {
                chart3.Series[0].Points.Add(R4[zanimanje]);
                chart3.Series[0].Points[i].LegendText = Math.Round(R4[zanimanje], 2).ToString();
                chart3.Series[0].Points[i].AxisLabel = zanimanje;
                i++;
            }
        }
    }
}
