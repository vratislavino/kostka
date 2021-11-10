using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KostkaStats
{
    public partial class Form1 : Form
    {
        public event Action<int> KostkaVrzena;

        Random random = new Random();
        Kostka kostka;
        public Form1() {
            InitializeComponent();
            KostkaVrzena += VykresliKostku;
            kostka = new Kostka(panel1.Width / 2, panel1.Height / 2);
            kostka.Invalidate += panel1.Refresh;
        }

        private void button1_Click(object sender, EventArgs e) {
            Hod();
        }

        private void button2_Click(object sender, EventArgs e) {
            for (int i = 0; i < 100; i++)
                Hod();
        }

        private void Hod() {
            var cislo = random.Next(1, 7);
            kostka.Cislo = cislo;
            //KostkaVrzena?.Invoke(cislo);
        }

        private void VykresliKostku(int cislo) {
            var g = panel1.CreateGraphics();
            g.DrawLine(Pens.Red, 0, 0, 150, 150);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            kostka.VykresliSe(e.Graphics);
        }
    }
}
