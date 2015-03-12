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
