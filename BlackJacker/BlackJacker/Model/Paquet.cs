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

        }

        public void Melanger() // Methode sort
        {

        }

        public Carte Retirer() // Retirer la premiere carte du paquet
        {
            return null;
        }
    }
}
