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
            InitialiserJeton();
        }

        public void Split()
        {

            if (listSimple[0].nom == listSimple[1].nom)
            {
                listSplit.Add(listSimple[0]);
                listSimple.Remove(listSimple[0]);
            }
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
