using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJacker.Model
{
    public class Carte
    {
      
        public int valeur { get; set; }

        public string couleur { get; set; }
        public string nom { get; set; }

        public string pathImage { get; set; }

        public Carte(string p_nom, string p_couleur)
        {
            nom = p_nom;
            couleur = p_couleur;
            pathImage = Path.GetFullPath(String.Format("/data/img/carte/{0}-{1}-75.png", couleur, nom));
            if (p_nom.Equals("as"))
            { 
                valeur = 1; 
            }
            else 
            {
                if (p_nom.Equals("q") || p_nom.Equals("j") || p_nom.Equals("k"))
                {
                    valeur = 10;
                }
                else
                {
                    valeur = Convert.ToInt32(p_nom);
                }
            }
           

        }
    }
}
