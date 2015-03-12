using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJacker.Model
{
    public class Paquet
    {
        public List<Carte> cartes { get; set; }

        public Paquet()
        {
            cartes = new List<Carte>();
        }

        public void Initialiser() // Creation du paquet avec ttes les cartes
        {
            string [] valeurCarte = new string[13]{"a","k","q","j","10","9","8","7","6","5","4","3","2"};
            string[] couleurCarte = new string[4] { "clubs", "diamonds", "hearts", "spades" };
            foreach (var nom in valeurCarte)
            {
                foreach (var couleur in couleurCarte)
                {
                    cartes.Add(new Carte(nom,couleur, String.Format(@"\data\img\carte\{0}-{1}-75.png", couleur, nom)));
                }
                
            }
            for (int i = 0; i < 54;i++ )
            {
                
            }
        }

        public void Melanger() // Methode sort
        {

        }

        public Carte Retirer() // Retirer la premiere carte du paquet
        {
            int index = cartes.Count() - 1;
            Carte carte = cartes.ElementAt(index);
            cartes.RemoveAt(index);
            return carte;
        }
    }
}
