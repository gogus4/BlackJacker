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

        public Carte(string p_nom, string p_valeur,string p_path)
        {
            nom = p_nom;
            couleur = p_valeur;
            pathImage = p_path;
        }
    }
}
