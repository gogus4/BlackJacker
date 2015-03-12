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

        public Utils() { }

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


        public int PlayerWin(Croupier croupier, Joueur joueur)
        {
            int value = 0;

            if (GetScore(croupier.listSimple) > GetScore(joueur.listSimple))
            {
                value++;
            }
            if (GetScore(croupier.listSimple) > GetScore(joueur.listSplit))
            {
                value++;
            }

            return value;
        }

        public void UpdatePlayer()
        {

        }

        public void UpdatePartie(Croupier croupier, Joueur joueur)
        {
            if (joueur.isSplit)
            {
                if (PlayerWin(croupier, joueur) == 2)
                {
                    joueur.jeton += joueur.mise * 2;
                }

            }
            else
            {
                if (PlayerWin(croupier, joueur) == 1)
                {
                    joueur.jeton += joueur.mise;
                }

            }
            // réinitialiser l'interface 

        }

    }

}

