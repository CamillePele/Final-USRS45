using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Joueur {
        public string name;
        public List<string> cartes = new List<string>();
        public bool dealer = false;

        public Joueur(string name) {
            this.name = name;
        }
        public Joueur(string name, bool dealer) {
            this.name = name;
            this.dealer = dealer;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Initialisation

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("1", 1);
            dict.Add("2", 2);
            dict.Add("3", 3);
            dict.Add("4", 4);
            dict.Add("5", 5);
            dict.Add("6", 6);
            dict.Add("7", 7);
            dict.Add("8", 8);
            dict.Add("9", 9);
            dict.Add("10", 10);
            dict.Add("R", 10);
            dict.Add("D", 10);
            dict.Add("V", 10);
            dict.Add("A", 0);

            Console.WriteLine("Comment vous appelez-vous ?");
            string nom = Console.ReadLine();

            Joueur joueurH = new Joueur(nom);
            Joueur joueurO = new Joueur("Ordinateur", true);

            //Générer le paquet de cartes

            Console.WriteLine("Avec combien de paquets voulez-vous jouer ?");
            int nbPaquets = int.Parse(Console.ReadLine());

            List<string> paquet = new List<string>();
            for (int i = 0; i < nbPaquets*4; i++)
            {
                paquet.AddRange(dict.Keys);
            }
            paquet = paquet.OrderBy(x => Guid.NewGuid()).ToList();

            dict.Add("A-", 1);
            dict.Add("A+", 11);

            //Distribution des cartes
            for (int i = 0; i < 2; i++)
            {
                foreach (Joueur joueur in new List<Joueur>{joueurH, joueurO}) 
                {
                    DistributionJoueur(joueur, paquet);
                }
            }

            //Affichage du jeu
            AffichePartie(new List<Joueur>{joueurH, joueurO}, dict);

            //Déroulement d’un tour
            bool stopJoueur = false;
            bool stopOrdinateur = false;
            bool finPartie = false;

            while (!finPartie) {
                //Décision du joueur
                if (!stopJoueur) {
                    Console.WriteLine("Voulez-vous piocher une nouvelle carte ? \n o - Oui \n n - Non");
                    string choixJoueur = Console.ReadLine();

                    if (choixJoueur == "o") {
                        Console.WriteLine("{0} : Je pioche", joueurH.name);
                        DistributionJoueur(joueurH, paquet);
                    } else {
                        Console.WriteLine("Humain : Je m'arrête là.");
                        stopJoueur = true;
                    }
                }

                if (!stopOrdinateur) {
                    if (SommeJoueur(joueurO, dict) >= 15) {
                        Console.WriteLine("{0} : Je pioche", joueurO.name);
                        DistributionJoueur(joueurO, paquet);
                    } else {
                        Console.WriteLine("Ordinateur : Je m’arrête là.");
                        stopOrdinateur = true;
                    }
                }

                //Affichage du jeu
                AffichePartie(new List<Joueur>{joueurH, joueurO}, dict);

                if (stopJoueur && stopOrdinateur) {
                    finPartie = true;
                }
                if (SommeJoueur(joueurH, dict) >= 21 || SommeJoueur(joueurO, dict) >= 21) {
                    finPartie = true;
                }
            }
            if (SommeJoueur(joueurH, dict) == 21) {
                Console.WriteLine("Félicitation, vous avez 21 points !");
            } if (SommeJoueur(joueurH, dict) > 21) {
                Console.WriteLine("Dommage, vous avez dépassé les 21 points");
            } else if (SommeJoueur(joueurO, dict) == 21) {
                Console.WriteLine("Dommage, l'ordinateur a 21 points !");
            } else if (SommeJoueur(joueurO, dict) > 21) {
                Console.WriteLine("Bravo, l'ordinateur a dépassé les 21 points");
            } else if (SommeJoueur(joueurH, dict) > SommeJoueur(joueurO, dict)) {
                Console.WriteLine("Bravo, vous avez gagné avec {0}, l'ordinateur avait {1}", SommeJoueur(joueurH, dict), SommeJoueur(joueurO, dict));
            } else if (SommeJoueur(joueurH, dict) < SommeJoueur(joueurO, dict)) {
                Console.WriteLine("Dommage, vous avez perdu avec {0}, l'ordinateur avait {1}", SommeJoueur(joueurH, dict), SommeJoueur(joueurO, dict));
            } else if (SommeJoueur(joueurH, dict) == SommeJoueur(joueurO, dict)) {
                Console.WriteLine("Exaequo, vous le même score que l'ordinatuer : {0}", SommeJoueur(joueurH, dict));
            }
        }

        static int SommeJoueur(Joueur joueur, Dictionary<string, int> dict) {
            int sum = 0;
            foreach (string carte in joueur.cartes) {
                sum += dict[carte];
            }
            return sum;
        }

        static void DistributionJoueur(Joueur joueur, List<string> paquet) {
            joueur.cartes.Add(paquet[paquet.Count-1]);
            paquet.RemoveAt(paquet.Count-1);

            if (!joueur.dealer && joueur.cartes.Last() == "A") {
                joueur.cartes.RemoveAt(joueur.cartes.Count-1);

                int choix = 0;
                do {
                    Console.WriteLine("Vous venez de piocher un As, voulez-vous qu'il compte pour 1 ou 11");
                    choix = int.Parse(Console.ReadLine());
                    Console.WriteLine(choix == 1 || choix == 11);
                } while(!(choix == 1 || choix == 11));

                if (choix == 1)
                    joueur.cartes.Add("A-");
                if (choix == 11)
                    joueur.cartes.Add("A+");
            }
        }

        static void AffichePartie(List<Joueur> joueurs, Dictionary<string, int> dict) {
            foreach (Joueur joueur in joueurs) {
                if (!joueur.dealer)
                    Console.WriteLine("({0} pts) {1} : {2}", SommeJoueur(joueur, dict), joueur.name, string.Join(", ", joueur.cartes));
                else
                    Console.WriteLine("({0} pts) {1} : {2}", SommeJoueur(joueur, dict), joueur.name, string.Join(", ", joueur.cartes.Skip(1)));
            }
        }
    }
}