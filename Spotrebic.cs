using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP03
{
    class Spotrebic
    {
        private string kod;
        private double prikon; //wattsekundy
        private TimeSpan celkovaDobaProvozu = new TimeSpan();
        private DateTime okamzikZapnuti;
        private bool jeVProvozu = false;
        public string Kod
        {
            get
            {
                return kod;
            }
            set 
            {
                //oprava
                string prac = value;
                prac = value.ToUpper();
                int i = 0;
                while(i<prac.Length)
                {
                    if (!char.IsLetterOrDigit(prac[i]) && !(prac[i] == '-'))
                    {
                        prac = prac.Remove(i, 1);
                    }
                    else ++i;
                }
                kod = prac;
            }
        }
        public bool JeVProvozu 
        {
            get 
            {
                return jeVProvozu;
            }
        }
        public Spotrebic(string kod, double prikon)
        {
            //vlastnost neni this
            Kod = kod;
            this.prikon = prikon;
        }
        public void Zapni()
        {
            jeVProvozu = true;
            okamzikZapnuti = DateTime.Now;
        }
        public void Vypni()
        {
            jeVProvozu = false;
            celkovaDobaProvozu += DateTime.Now - okamzikZapnuti;
            System.Windows.Forms.MessageBox.Show("Celková doba provozu je: " + celkovaDobaProvozu.TotalSeconds);
        }
        public double CelkovaSpotreba()
        {
            double spotreba = celkovaDobaProvozu.TotalSeconds * prikon;
            if (JeVProvozu) 
            {
                spotreba += (DateTime.Now - okamzikZapnuti).TotalSeconds * prikon;
            }
            return spotreba;
        }
        public override string ToString()
        {
            string s = "\nKód spotřebiče je: " + Kod +"\nCelková doba provozu je: " + celkovaDobaProvozu.TotalSeconds + " sekund\n" + "Celková spotřeba je: " + CelkovaSpotreba() + "Wattsekund";
            return base.ToString() + s;
        }
    }
}
