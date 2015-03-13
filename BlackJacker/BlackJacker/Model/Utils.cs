﻿using System;
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

            if (GetScore(joueur.listSimple) >= GetScore(croupier.listSimple))
            {
                value++;
            }
            if (GetScore(joueur.listSplit) >= GetScore(croupier.listSimple))
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
                    joueur.jeton += joueur.mise * 4;
                } 
                else if (PlayerWin(croupier, joueur) == 1)
                {
                    joueur.jeton += joueur.mise * 2;
                }
            }
            else
            {
                if (PlayerWin(croupier, joueur) == 1)
                {
                    joueur.jeton += joueur.mise * 2;
                }

            }
            // TODO : réinitialiser l'interface 

        }

    }

}

