using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJacker.Model
{
    public class Personne
    {
        public string nom { get; set; }

        public List<Carte> listSimple { get; set; }

        public Personne()
        {
            listSimple = new List<Carte>();
        }

        public void AjouterCarte(Carte carte)
        {
            listSimple.Add(carte);
        }
       
    }
}
