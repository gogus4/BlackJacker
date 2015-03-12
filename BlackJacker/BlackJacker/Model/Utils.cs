using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJacker.Model
{
    public class Utils
    {
        private Utils instance;

        private Utils() { }

        public Utils Instance()
        {
            if (instance == null)
            {
                instance = new Utils();   
            }
            return instance;
        }

        public int GetScore(List<Carte> cartes)
        {
            int score = 0;
            foreach (var carte in cartes)
            {
                score += carte.valeur;
            }
            return score;
        }


        public Boolean PlayerWin(Croupier croupier, Joueur joueur)
        {
            if (GetScore(croupier.listSimple) > GetScore(joueur.listSimple))
            {
                return false;
            }

            return true;
        }


    }
}
