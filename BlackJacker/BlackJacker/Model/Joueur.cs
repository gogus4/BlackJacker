using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJacker.Model
{
    public class Joueur : Personne
    {
        public double jeton { get; set; }

        public List<Carte> listSplit { get; set; }

        public Boolean isSplit { get; set; }

        public int mise { get; set; }

        public Joueur()
        {
            InitialiserJeton();
            listSplit = new List<Carte>();
        }

        public Boolean Split()
        {
            if (jeton > mise)
            {
                if (listSimple[0].nom == listSimple[1].nom)
                {
                    listSplit.Add(listSimple[1]);
                    listSimple.Remove(listSimple[1]);

                    isSplit = true;

                    return true;
                }
            }

            return false;
        }

        public void InitialiserJeton()
        {
            jeton = 100;
        }

        public void Miserjeton(int valueMiser)
        {
            mise = valueMiser;
            jeton -= mise;
        }

        public void AjouterSplit(Carte carte)
        {
            listSplit.Add(carte);
        }

       

    }
}
