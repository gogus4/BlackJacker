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

        public int mise { get; set; }

        public Joueur()
        {

        }
        public void split()
        {

            if (listSimple[0].nom == listSimple[1].nom)
            {
                listSplit.Add(listSimple[0]);
                listSimple.Remove(listSimple[0]);
            }
        }
        public void initialiserJeton()
        {
            jeton = 100;
        }
        public void miserjeton(int valueMiser)
        {
            mise = valueMiser;
            jeton -= mise;
        }
    }
}
