using System;
using System.Collections.Generic;
using System.Linq;
// using System.Text;

class Program //TODO Description des actions
{
    static Type[] personnagesArray = new Type[] {new Druid().GetType(), new Healer().GetType(), new Damager().GetType(), new Tank().GetType()};

    static void Main(string[] args)
    { 
        // affichage debut jeu
        Screen screen = new Screen(80, 20);

        screen.Add(new Coordinates(30, 8), "jeu Tour par Tour RPG", 1);
        screen.Add(new Coordinates(35, 9), "crée par :", 1);
        screen.Add(new Coordinates(34, 10), "PELE Camille", 1);
        screen.Add(new Coordinates(33, 11), "DIDIER Mathias", 1);
        screen.Add(new Coordinates(34, 12), "PINEDA Joris", 1);

        screen.Display();
        screen.DeleteLayer(1);

        //System.Threading.Thread.Sleep(3000);

        // Choix du mode de jeu IA contre IA (équilibrage) ou IA contre Joueur.
        //int modeDeJeu = ()


        // choix personnage joueur
        screen.Add(new Coordinates(30, 5), "Choix du Personnage :", 2);
        int space = screen.width / (personnagesArray.Length+1); 
        for(int i = 0; i < personnagesArray.Length; i++)
        {
            screen.Add(new Coordinates(space * (i+1) - personnagesArray[i].ToString().Length/2, 10), personnagesArray[i].ToString(), 2);
        }
        screen.Display();

        Coordinates selectorCoordinates = new Coordinates(screen.width / (personnagesArray.Length+1) - personnagesArray[0].ToString().Length/2, 11);
        string selectorIndicator = new String('^', personnagesArray[0].ToString().Length);
        screen.Add(selectorCoordinates, selectorIndicator, 1);
        screen.Display();
        int selected = 0;
        while(Console.ReadKey().Key != ConsoleKey.Enter)
        {
            if (Console.ReadKey().Key == ConsoleKey.RightArrow) {
                selected++;
            } else if (Console.ReadKey().Key == ConsoleKey.LeftArrow) {
                selected--;
            }

            if (selected < 0) selected = personnagesArray.Length-1;
            selected = selected%personnagesArray.Length;
            selectorCoordinates.x = (screen.width / (personnagesArray.Length+1))*(selected+1) - personnagesArray[selected].ToString().Length/2;
            selectorIndicator = new String('^', personnagesArray[selected%personnagesArray.Length].ToString().Length);
            screen.Display();
        }
        IPersonnage persoJ = (IPersonnage)Activator.CreateInstance(personnagesArray[selected]); // initialisation peronnage du Joueur
        screen.Clear();
        // TOCHANGE
        Console.WriteLine("Vous avez choisi la classe {0}", persoJ.GetType().ToString());

        // choix personnage Ordinateur
        screen.Add(new Coordinates(30, 5), "L'ordinateur choisi :", 1);
        for (int i = 0; i < 8; i++) // attente Fake
        {
            screen.Add(new Coordinates(screen.width/2-1, screen.height/2), new String('.', (i%4)), 2);
            screen.Display();
            screen.DeleteLayer(2);
            System.Threading.Thread.Sleep(500);
        }

        Random rand = new Random();
        int numPersoO = rand.Next(0, personnagesArray.Length); // on choisit le personnage de l'ordinateur aléatoirement
        IPersonnage persoO = (IPersonnage)Activator.CreateInstance(personnagesArray[numPersoO]); // initialisation personnage Ordinateur
        
        screen.Add(new Coordinates(screen.width/2 - personnagesArray[numPersoO].ToString().Length/2, screen.height/2), personnagesArray[numPersoO].ToString());
        screen.Display();
        System.Threading.Thread.Sleep(1000);
        screen.Clear();

        //ROUND

        //boucle fin de partie
        bool partie = true; 
        while (partie)
        {
            persoJ.StartRound();
            persoO.StartRound();

            // affichage vie et rôle
            screen.Add(new Coordinates(1, 0), $"Joueur : {new String('♥', persoJ.pv)} PV");
            screen.Add(new Coordinates(1, 1), $"Rôle : {persoJ.GetType().ToString()}");
            screen.Add(new Coordinates(screen.width - persoO.pv -19, 0), $"Ordinateur : {new String('♥', persoO.pv)} PV");
            screen.Add(new Coordinates(screen.width - persoO.pv - 19, 1), $"Rôle : {persoO.GetType().ToString()}");

            List<KeyValuePair<int,  (IPersonnage, IPersonnage)>> actions = new(); // liste permettant d'effectuer les actions dans le bon ordre

            // affichage texte si immobilisé
            if (persoJ.specialDruid) {
                screen.Add(new Coordinates(screen.width/2 - 25, screen.height/2), "Tu es immobilisé par les racines de ton adversaire", 1);
                screen.Add(new Coordinates(screen.width/2 - 12, screen.height/2+1), "tu ne peux rien faire ...", 1);
            }

            if (persoO.specialDruid) {
                screen.Add(new Coordinates(screen.width/2 - 26, screen.height/2), "Ton adversaire ne peut plus bouger grace à ta magie !", 1);
            }

            screen.Display();
            screen.DeleteLayer(1);
            System.Threading.Thread.Sleep(1000);

            //Tour du joueur
            if (!persoJ.specialDruid)
            {
                actions.Add(new KeyValuePair<int, (IPersonnage, IPersonnage)>(ChooseAction(persoJ, persoO, screen), (persoJ, persoO)));
            }
            //Tour du robot
            if (!persoO.specialDruid)
            {
                screen.Add(new Coordinates(30, 5), "L'ordinateur choisi :", 1);
                for (int i = 0; i < 4; i++) // attente Fake
                {
                    screen.Add(new Coordinates(screen.width/2-1, screen.height/2), new String('.', (i%4)), 2);
                    screen.Display();
                    screen.DeleteLayer(2);
                    System.Threading.Thread.Sleep(300);
                }

                int choixRobot = rand.Next(0, 3); // on choisit l'action du personnage de l'ordinateur aléatoirement
                List<string> actionsList = new List<string>(){"Défense", "Attaque", "Spécial"};
                screen.Add(new Coordinates(screen.width/2 - actionsList[choixRobot].Length/2, screen.height/2), actionsList[choixRobot]);
                screen.Display();
                System.Threading.Thread.Sleep(1000);


                actions.Add(new KeyValuePair<int, (IPersonnage, IPersonnage)>(choixRobot, (persoO, persoJ)));
            
            }

            screen.Display();
            screen.Clear();

            ApplyAction(actions);

            //Fin du tour
            persoJ.EndRound();
            persoO.EndRound();
            

            
            if (persoJ.pv <= 0 && persoO.pv <=0)
            {
                screen.Add(new Coordinates(screen.width/2 - 16, screen.height/2), "Vos coups portent au même moment");
                screen.Add(new Coordinates(screen.width/2 - 18, screen.height/2-1), "vos vie s'éteignent en même temps.");
                partie = false;
            }
            else if (persoJ.pv <= 0)
            {
                screen.Add(new Coordinates(screen.width/2 - 17, screen.height/2), "Vous avez succombé à vos blessures.");
                screen.Add(new Coordinates(screen.width/2 - 11, screen.height/2-1), "Votre ennemi à gagner.");
                partie = false;
            }
            else if (persoO.pv <= 0)
            {
                screen.Add(new Coordinates(screen.width / 2 - 21, screen.height / 2), "Votre ennemi meurt sous vos assaut répétés");
                screen.Add(new Coordinates(screen.width / 2 - 11, screen.height / 2-1), "la victoire est vôtre.");
                partie = false;
            }

            screen.Clear();
        }

    }

    /// <summary>
    /// Permet d'effectuer toutes les actions dans l'ordre suivant : défense, attaque, spécial; ainsi que dans le sous-ordre : Healer, Tank, Damager
    /// </summary>
    /// <param name="actions">Liste de clé/valeur, la clé représente l'action a éfféctuer, la valeur est un tuple du joueur et de l'ennemi</param>
    public static void ApplyAction(List<KeyValuePair<int,  (IPersonnage, IPersonnage)>> actions)
    {
        //Trier par la clé
        actions = actions.AsEnumerable().OrderBy(x => x.Key)
                              .ThenBy(x => Array.IndexOf(personnagesArray, x.Value.Item1.GetType()))
                              .ToList();


        foreach (KeyValuePair<int, (IPersonnage, IPersonnage)> action in actions)
        {
            switch (action.Key)
            {
                case 1:
                    action.Value.Item1.Defense();
                    break;
                case 2:
                    action.Value.Item1.Attack(action.Value.Item2);
                    break;
                case 3:
                    action.Value.Item1.Special(action.Value.Item2);
                    break;
            }
        }
    }

    /// <summary>
    /// Fonctione qui fais faire un choix au joueur
    /// </summary>
    /// <param name="joueur">joueur qui choisi</param>
    /// <param name="ennemi">l'ennemi du joueur</param>
    public static int ChooseAction(IPersonnage joueur, IPersonnage ennemi, Screen screen) {
        //TODO affichage dans screen
        List<string> actions = new List<string>(){"Défense", "Attaque", "Spécial"};
        int space = screen.width / (actions.Count + 1);
        for (int i = 0; i < actions.Count; i++)
        {
            screen.Add(new Coordinates(space * (i + 1) - actions[i].ToString().Length / 2, 10), actions[i].ToString(), 2);
        }

        // ? Surement moyen de pas faire en réccurcif (ca sera plus opti)
        // return VerifyAction(int.Parse(Console.ReadLine()), joueur, ennemi);

        screen.Add(new Coordinates(30, 5), "Choisir une action :", 2);
        Coordinates selectorCoordinates = new Coordinates(screen.width / (actions.Count+1) - actions[0].ToString().Length/2, 11);
        string selectorIndicator = new String('^', actions[0].ToString().Length);
        screen.Add(selectorCoordinates, selectorIndicator, 2);
        screen.Add(new Coordinates(screen.width/2 - joueur.descDefense.Length/2, 15), joueur.descDefense, 3);
        screen.Display();
        int selected = 0;
        while(Console.ReadKey().Key != ConsoleKey.Enter)
        {
            if (Console.ReadKey().Key == ConsoleKey.RightArrow) {
                selected++;
            } else if (Console.ReadKey().Key == ConsoleKey.LeftArrow) {
                selected--;
            }

            if (selected < 0) selected = actions.Count-1;
            selected = selected%actions.Count;
            selectorCoordinates.x = (screen.width / (actions.Count+1))*(selected+1) - actions[selected].Length / 2;
            selectorIndicator = new String('^', actions[selected%actions.Count].Length);

            string text = "";
            switch (selected){
                case 0:
                    text = joueur.descDefense;
                    break;
                case 1:
                    text = joueur.descAttaque;
                    break;
                case 2:
                    text = joueur.descSpecial;
                    break;
            }
            screen.Add(new Coordinates(screen.width/2 - text.Length/2, 15), text, 3);
            screen.Display();
            screen.DeleteLayer(3);
        }
        screen.Clear();
        return selected+1;
    }
}