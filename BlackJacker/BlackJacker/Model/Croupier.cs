﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJacker.Model
{
    public class Croupier : Personne
    {
        public Paquet paquet { get; set; }

        public Croupier()
        {

        }

        public void Distribuer(Personne personne, Boolean isSplit)
        {
            if (!isSplit)
            {
                personne.AjouterCarte(paquet.Retirer());
            }
            else
            {
              ((Joueur)personne).AjouterSplit(paquet.Retirer());
            }
        }

        public void RetournerCarte()
        {
            
        }

    }
}
