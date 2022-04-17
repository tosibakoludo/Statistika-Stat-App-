using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistika__Stat_App_
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap b;
        List<Radnik> L = new List<Radnik>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = b;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.Lavender);
            Pen orangePen = new Pen(Color.Orange, 3);
            g.DrawEllipse(orangePen, 25, 125, 650, 200);
            g.DrawLine(orangePen, 500, 50, 200, 450);
            g.DrawLine(orangePen, 200, 50, 500, 450);
            g.FillEllipse(Brushes.LightGoldenrodYellow, 25, 125, 650, 200);
            g.DrawString("Statistika", new Font("Consolas", 16, FontStyle.Bold), Brushes.Black, 285, 185);
            g.DrawString("(Stat App)", new Font("Consolas", 16, FontStyle.Bold), Brushes.Black, 285, 265);
            pictureBox1.Invalidate();

            try
            {
                string[] linije = File.ReadAllLines(@"..\..\Salaries.csv");
                foreach (string linija in linije)
                {
                    string[] niz = linija.Split(',');

                    if (niz.Length == 13)
                    {

                        int sifra = int.Parse(niz[0]);
                        string imePrezime = niz[1];
                        string zanimanje = niz[2];
                        double plata = double.TryParse(niz[3], out plata) ? (double)plata : -1;
                        double prekovremeni = double.TryParse(niz[4], out prekovremeni) ? (double)prekovremeni : -1;
                        double ostalo = double.TryParse(niz[5], out ostalo) ? (double)ostalo : -1;
                        double benefiti = double.TryParse(niz[6], out benefiti) ? (double)benefiti : -1;
                        double ukupno = double.TryParse(niz[7], out ukupno) ? (double)ukupno : -1;
                        double ukupnoSaBenefitima = double.TryParse(niz[8], out ukupnoSaBenefitima) ? (double)ukupnoSaBenefitima : -1;
                        int godina = int.Parse(niz[9]);
                        string beleske = niz[10];
                        string mesto = niz[11];
                        string status = niz[12];

                        if (plata != -1 && prekovremeni != -1 && ostalo != -1 && ukupno != -1 && ukupnoSaBenefitima != -1)
                        {
                            Radnik r = new Radnik(sifra, imePrezime, zanimanje, plata, prekovremeni, ostalo, benefiti, ukupno, ukupnoSaBenefitima, godina, beleske, mesto, status);
                            L.Add(r);
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("GREŠKA/ERROR: " + x.Message);
            }
        }

        private void sRPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(L);
            f2.Show();
        }

        private void eNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(L);
            f3.Show();
        }
    }
}