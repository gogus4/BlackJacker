using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJacker.Model
{
    public class Utils
    {

        private static Utils instance;
        public static Utils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Utils();
                }

                return instance;
            }
        }

        public Utils() { }

        public int GetScore(List<Carte> cartes)
        {
            int score = 0;
            int numberOfAs = 0;
            foreach (var carte in cartes)
            {
                if (carte.nom == "a")
                {
                    numberOfAs++;
                }
                score += carte.valeur;
            }

            if (numberOfAs > 0)
            {
                if (score > 21)
                {
                    score -= 10;
                }
            }

            return score;
        }


        public int PlayerWin(Croupier croupier, Joueur joueur)
        {
            int value = 0;
            if (GetScore(joueur.listSimple) <= 21)
            {
                if (GetScore(joueur.listSimple) >= GetScore(croupier.listSimple) || GetScore(croupier.listSimple) > 21 )
                {
                    value++;
                }

            }

            if (GetScore(joueur.listSplit) <= 21 && joueur.isSplit)
            {
                if (GetScore(joueur.listSplit) >= GetScore(croupier.listSimple) || GetScore(croupier.listSimple) > 21 )
                {
                    value++;
                }
            }

            return value;
        }

        public void UpdatePlayer()
        {

        }

        public void UpdatePartie(Croupier croupier, Joueur joueur)
        {
            if (PlayerWin(croupier, joueur) == 2)
            {
                joueur.jeton += joueur.mise * 4;
            }
            else if (PlayerWin(croupier, joueur) == 1)
            {
                if (Utils.Instance.GetScore(joueur.listSimple) == 21 && joueur.isSplit == false)
                {
                    joueur.jeton += joueur.mise * 2.5;
                }
                else
                {
                    joueur.jeton += joueur.mise * 2;
                }
            }
        }

    }

}

