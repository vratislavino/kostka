using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KostkaStats
{
    public class Kostka
    {
        public event Action Invalidate;
        private SolidBrush barvaTecky = new SolidBrush(Color.Red);
        private int velikostTecky = 60;

        private int midX, midY;

        private int cislo;
        public int Cislo {
            get { return cislo; }
            set { 
                cislo = value;
                Invalidate?.Invoke();
            }
        }

        public Kostka(int midX, int midY) {
            this.midX = midX;
            this.midY = midY;
        }

        public void VykresliSe(Graphics g) {
            if(Cislo % 2 == 1)  {
                g.FillEllipse(barvaTecky,
                    midX - velikostTecky / 2,
                    midY - velikostTecky / 2,
                    velikostTecky,
                    velikostTecky);
            }
            if(Cislo >= 2) {
                g.FillEllipse(barvaTecky,
                    midX - velikostTecky / 2 - midX/2,
                    midY - velikostTecky / 2 - midY/2,
                    velikostTecky,
                    velikostTecky);
                g.FillEllipse(barvaTecky,
                    midX - velikostTecky / 2 + midX/2,
                    midY - velikostTecky / 2 + midY/2,
                    velikostTecky,
                    velikostTecky);
            } 
            if(Cislo >= 4) {
                g.FillEllipse(barvaTecky,
                    midX - velikostTecky / 2 + midX / 2,
                    midY - velikostTecky / 2 - midY / 2,
                    velikostTecky,
                    velikostTecky);
                g.FillEllipse(barvaTecky,
                    midX - velikostTecky / 2 - midX / 2,
                    midY - velikostTecky / 2 + midY / 2,
                    velikostTecky,
                    velikostTecky);
            }
            if(Cislo == 6) {
                g.FillEllipse(barvaTecky,
                    midX - velikostTecky / 2 - midX / 2,
                    midY - velikostTecky / 2,
                    velikostTecky,
                    velikostTecky);
                g.FillEllipse(barvaTecky,
                    midX - velikostTecky / 2 + midX / 2,
                    midY - velikostTecky / 2,
                    velikostTecky,
                    velikostTecky);
            }
        }
    }
}
