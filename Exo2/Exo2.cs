using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        /*1. Déclarer et initialiser une liste Fruits contenant les éléments "Banane", "Pomme",
         *   "Kiwi", "Orange", "Melon","Poire","Mangue".
         */
        List<string> Fruits = new List<string> {"Banane", "Pomme", "Kiwi", "Orange", "Melon","Poire","Mangue"};
        Affichage(Fruits);

        /*2. Déclarer et initialiser à vide un dictionnaire CorbeilleFruits qui acceptera comme
         *clés des chaînes de caractères et comme valeurs des entiers.
         */
        Dictionary<string, int> CorbeilleFruits = new Dictionary<string, int>();

        //3. Déclarer et initialiser un objet Random.
        Random rand = new Random();

        /*4. Pour chaque élément de la liste Fruits, ajouter un élément dans CorbeilleFruits ayant
         *   pour clé l’élément de la liste Fruits considéré et comme valeur un nombre aléatoire
         *   entre 0 et 10.
         */
        foreach (string fruit in Fruits) {
            CorbeilleFruits.Add(fruit, rand.Next(101));
        }

        /*5. Afficher pour chaque élément de CorbeilleFruits "J’ai X Y" avec Y le fruit et X la
         *   quantité associée
         */
        foreach (KeyValuePair<string, int> entry in CorbeilleFruits) {
            Console.WriteLine("J'ai "+entry.Value+" "+entry.Key);
        }

        //6. Afficher le nombre total de fruits de CorbeilleFruits. pour toutes les clés
        int sum = 0;
        foreach (KeyValuePair<string, int> entry in CorbeilleFruits) {
            sum += entry.Value;
        }
        Console.WriteLine(sum);

        //7. Afficher "J’ai X pomme(s)" avec X la valeur associée à la clé "Pomme" dans CorbeilleFruits.
        Console.WriteLine("J'ai "+ CorbeilleFruits["Pomme"] +" pommes");

        //8. Déclarer et initialiser une liste d’entiers NbLettres qui contient le nombre de lettres de chaque élément de Fruits
        List<int> NbLettres = Fruits.AsEnumerable().Select(x => x.Length).ToList();
        Console.WriteLine(string.Join(", ", NbLettres));

        /*9. Ajouter à chaque valeur de CorbeilleFruits le nombre de lettres de sa clé. 
         *Exemple : Pour la clé Banane, ajouter 6 à la valeur associée.
         */
        foreach (KeyValuePair<string, int> entry in CorbeilleFruits) {
            CorbeilleFruits[entry.Key] += entry.Key.Length;
        }

        //10. Supprimer de CorbeilleFruits les informations relatives à la clé "Mangue".
        CorbeilleFruits.Remove("Mangue");

        //11. Afficher "Il y a X fruits dans la Corbeille de fruits" avec X le nombre de clés de CorbeilleFruits.
        sum = 0;
        foreach (KeyValuePair<string, int> entry in CorbeilleFruits) {
            sum += entry.Value;
        }
        Console.WriteLine("Il y a "+sum+" dans la corbeille de fruits");

        //12. Ajouter à CorbeilleFruits un nouvel élément de clé "Ananas" et de valeur 6.
        CorbeilleFruits.Add("Ananas", 6);

        //13. Afficher uniquement les clés de CorbeilleFruits pour lesquelles la valeur associée est supérieure ou égale à 15.
        foreach (KeyValuePair<string, int> entry in CorbeilleFruits) {
            if (entry.Value > 15) {
                Console.WriteLine(entry.Key);
            }
        }
    }

    static void Affichage(List<string> Liste) {
        Console.WriteLine(string.Join(", ", Liste));
    }
}
