using System;
using System.Collections.Generic;
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

        public Carte(string p_nom, string p_valeur)
        {
            nom = p_nom;
            couleur = p_valeur;
            pathImage = String.Format(@"\image\carte\{0}-{1}-img.png", p_nom, p_nom);
        }
    }
}
