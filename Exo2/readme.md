E.P. USRS45 : C# Le CNAM

# USRS45 - Exercices de manipulation des structures de

# données principales en C#

## Exercice 2 : Manipulation des dictionnaires

1. Déclarer et initialiserune listeFruitscontenant les éléments "Banane", "Pomme",
    "Kiwi", "Orange", "Melon","Poire","Mangue".
2. Déclarer et initialiser à videun dictionnaireCorbeilleFruitsqui acceptera comme
    clés des chaînes de caractères et comme valeurs des entiers.
3. Déclarer et initialiserun objetRandom.
    Random rand = new Random();
4. Pour chaque élément de la listeFruits,ajouterun élément dansCorbeilleFruitsayant
    pour clé l’élément de la liste Fruits considéré et comme valeur un nombre aléatoire
    entre 0 et 10.
5. Afficherpour chaque élément deCorbeilleFruits"J’ai X Y" avec Y le fruit et X la
    quantité associée.
6. Afficherle nombre total de fruits deCorbeilleFruits. pour toutes les clés.
7. Afficher"J’ai X pomme(s)" avec X la valeur associée à la clé "Pomme" dansCor-
    beilleFruits.
8. Déclarer et initialiserune liste d’entiersNbLettresqui contient le nombre de lettres
    de chaque élément deFruits.
9. Ajouterà chaque valeur deCorbeilleFruitsle nombre de lettres de sa clé.
    Exemple : Pour la clé Banane, ajouter 6 à la valeur associée.
10. SupprimerdeCorbeilleFruitsles informations relatives à la clé "Mangue".
11. Afficher "Il y a X fruits dans la Corbeille de fruits" avec X le nombre de clés de
CorbeilleFruits.
12. AjouteràCorbeilleFruitsun nouvel élément de clé "Ananas" et de valeur 6.
13. Afficheruniquement les clés deCorbeilleFruits pour lesquelles la valeur associée est
supérieure ou égale à 15.