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
        private double prikon;
        private TimeSpan celkovaDobaProvozu;
        private DateTime okamzikZapnuti;
        private bool jeVProvozu;
        public string Kod
        {
            get
            {
                return kod;
            }
            set 
            {
                // pořešit nefunguje
                for(int i = 0; i < value.Length;++i)
                {
                    if (char.IsNumber(value[i])) { }
                    else if (char.IsLetter(value[i]))
                    {
                        if (char.IsLower(value[i]))
                        {
                            value =  char.ToUpper(value[i]) + value.Substring(i+1);
                            System.Windows.Forms.MessageBox.Show(value.ToString());
                        }
                    }
                    else if (value[i] == '-') { }
                    else
                    {
                        value = value.Remove(i, 1) + value.Substring(i+1);
                    }
                }
                kod = value;
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
            this.kod = kod;
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
            double spotreba = 0;
            if (JeVProvozu) 
            {
                spotreba = double.Parse((DateTime.Now - okamzikZapnuti).TotalSeconds.ToString())*prikon;
            }
            else 
            {
                spotreba = double.Parse(celkovaDobaProvozu.TotalSeconds.ToString()) * prikon;
            }
            return spotreba;
        }
        public override string ToString()
        {
            string s = "\nKód spotřebiče je: " + Kod +"\nCelková doba provozu je: " + celkovaDobaProvozu.TotalSeconds + " sekund\n" + "Celková spotřeba je: " + CelkovaSpotreba() + "W";
            return base.ToString() + s;
        }
    }
}
