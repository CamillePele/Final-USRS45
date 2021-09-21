using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Allumettes
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Avec combien d'allumettes voullez-vous jouer ?");
            int nbAllumettes = int.Parse(Console.ReadLine()); //Variable qui sert à savoir combien d'allumettes il y a au début de la partie
            int nbAllumettesRestantes = nbAllumettes; //Variable qui sert à savoir combien d'allumette il reste, et donc de savoir si la partie la partie est finie

            afficheBarres(nbAllumettesRestantes, nbAllumettes);

            Random rand = new Random();
            
            //Permet de répéter les tours de la partie
            while(nbAllumettesRestantes > 0){
                int nbAllumettesPrise = -85; //On mets le nombre d'allumettes prise à 85 pour savoir si le joueur à déjà choisi une fois
                do {
                    if (nbAllumettesPrise == -85) //On peut donc changer le message en fonction de si le joueur a déjà essayer de prendre des allumettes
                        Console.WriteLine("Combien d'allumettes voullez-vous prendre ? (1, 2 ou 3)");
                    else
                        Console.WriteLine("Veuillez choisir un nombre valide d’allumettes");
                    nbAllumettesPrise = int.Parse(Console.ReadLine());
                } while (!(nbAllumettesPrise >= 1 && nbAllumettesPrise <= 3 && nbAllumettesPrise <= nbAllumettesRestantes));

                Console.WriteLine("Vous avez retiré "+nbAllumettesPrise+" allumette(s)");

                nbAllumettesRestantes -= nbAllumettesPrise; //On retire le nombre d'allumettes prise au nombre d'allumettes restante
                afficheBarres(nbAllumettesRestantes, nbAllumettes);

                if (nbAllumettesRestantes == 0) {
                    Console.WriteLine("Vous avez perdu");
                    break;
                }

                int choixOrdi = 0;
                if (nbAllumettesRestantes <= 4 && nbAllumettesRestantes > 1) {
                    choixOrdi = nbAllumettesRestantes-1;
                } else if (nbAllumettesRestantes == 1) {
                    choixOrdi = 1;
                } else {
                    choixOrdi = rand.Next(1, 3);
                }

                Console.WriteLine("L'ordinateur a retiré "+choixOrdi+" allumette(s)");
                nbAllumettesRestantes -= choixOrdi; //On retire le nombre d'allumettes prisent par l'ordi au nombre d'allumettes restant
                afficheBarres(nbAllumettesRestantes, nbAllumettes);

                if (nbAllumettesRestantes == 0) {
                    Console.WriteLine("Vous avez gagné ! L’ordinateur a retiré la dernière allumette");
                    break;
                }
            }

        }

        static void afficheBarres(int restant, int nbBase) {
            string espace = string.Join("",Enumerable.Repeat(' ', nbBase-restant).ToList());
            string barres = string.Join("",Enumerable.Repeat('|', restant).ToList());
            Console.WriteLine(espace + barres);
        }
    }
}
