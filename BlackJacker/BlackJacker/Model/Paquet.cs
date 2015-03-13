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
            Initialiser();
        }

        public void Initialiser() // Creation du paquet avec ttes les cartes
        {
            cartes = new List<Carte>();

            string [] nomCarte = new string[13]{"a","k","q","j","10","9","8","7","6","5","4","3","2"};
            string[] couleurCarte = new string[4] { "clubs", "diamonds", "hearts", "spades" };
            foreach (var nom in nomCarte)
            {
                foreach (var couleur in couleurCarte)
                {
                    cartes.Add(new Carte(nom,couleur));
                }
            }

            //Melanger();
        }

        public void Melanger() // Methode sort
        {
            Random rng = new Random();
            int n = cartes.Count;

            while(n>1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carte c = cartes[k];
                cartes[k] = cartes[n];
                cartes[n] = c;
            }
            
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
