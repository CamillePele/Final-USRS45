using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        //1. Déclarer et initialiser une liste ListeImpairs qui contient tous les nombres entiers impairs entre 0 et 100
        List<int> listeImpairs = Enumerable.Range(1, 50).Select(x => x*2-1).ToList();
        Console.WriteLine(string.Join(", ", listeImpairs));

        //2. Déclarer et initialiser une liste ListeCarres qui contient les carrés de tous les éléments de ListeImpairs.
        List<int> listeCarres = listeImpairs.AsEnumerable().Select(x => x*x).ToList();
        Console.WriteLine(string.Join(", ", listeCarres));

        //3. Afficher le nombre d’éléments de ListeImpairs et le nombre d’éléments de ListeCarres.
        Console.WriteLine(listeImpairs.Count +" éléments dans listeImpairs, "+ listeCarres.Count+ " éléments dans listeCarres.");

        //4. Afficher le premier élément de ListeCarres.
        Console.WriteLine(listeCarres.First());

        //5. Afficher le dernier élément de ListeImpairs et le dernier élément de ListeCarres
        Console.WriteLine(listeImpairs.Last() +" est le dernier élément de listImpairs, "+ listeCarres.Last() +" est le dernier élément de listCarres");

        //6. Afficher uniquement les éléments de ListeCarres supérieurs à 100.
        List<int> supCent = listeCarres.AsEnumerable().Where(x => x>100).ToList();
        Console.WriteLine(string.Join(", ", supCent));

        //7. Afficher uniquement les éléments de ListeCarres qui commencent par un 9.
        List<int> startBy9 = listeCarres.AsEnumerable().Where(x => x.ToString().First() == '9').ToList();
        Console.WriteLine(string.Join(", ", startBy9));

        //8. Afficher les 8 premiers éléments de ListeCarres.
        Console.WriteLine(string.Join(", ", listeCarres.Take(8)));

        //9. Afficher les 8 derniers éléments de ListeCarres.
        Console.WriteLine(string.Join(", ", listeCarres.Skip(listeCarres.Count - 8)));

        //10. Déclarer et initialiser une liste MultiplesDe3 qui contient tous les éléments de ListeCarres qui sont des multiples de trois.
        List<int> multiplesDe3 = listeCarres.AsEnumerable().Where(x => x%3 == 0).ToList();
        Console.WriteLine(string.Join(", ", multiplesDe3));

        //11. Supprimer de ListeCarres tous les multiples de 3.
        List<int> pasMultiplesDe3 = listeCarres.AsEnumerable().Where(x => x%3 != 0).ToList();
        Console.WriteLine(string.Join(", ", pasMultiplesDe3));

        //12. Ajouter de nouveaux les multiples de 3 à la fin de ListeCarres.
        Console.WriteLine(string.Join(", ", listeCarres));

    }

    /*13. Définir une fonction static void Affichage(List<int> Liste), qui prend en paramètre
     *une liste d’entiers. Cette fonction permet d’afficher tous les éléments de la liste reçue
     *en les séparant par des virgules.
     */
    static void Affichage(List<int> Liste) {
        Console.WriteLine(string.Join(", ", Liste));
    }
}
