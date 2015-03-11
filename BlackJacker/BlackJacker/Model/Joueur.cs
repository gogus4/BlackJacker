using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJacker.Model
{
    public class Joueur : Personne
    {
        public int jeton { get; set; }

        public List<Carte> listSplit { get; set; }

        public Joueur()
        {

        }
    }
}
