E.P. USRS45 : C# Le CNAM

# USRS45 - TD

## Réalisation d’une version C# du jeu des allumettes

Le but de cet exercice est de mettre en place une version du jeu des allumettes. Vous
réaliserez ce travailen groupe de 2. Pensez à tester et à sauvegarder votre programme
à chaque étape. Commencez par lire toutes les étapes pour avoir une vision d’ensemble du
programme et de ses fonctionnalités. Essayez de toujours garder en tête la fonctionnalité
attendue et de comprendre l’intérêt de chaque étape au regard du but global visé.

1. Demander à l’utilisateurle nombre d’allumettes avec lequel il souhaite jouer et
    l’enregistrerdans une variablenbAllumettes.
2. Créer une variablenbAllumettesRestanteségale à la variablenbAllumettes.
3. Afficherautant de barre "|" que le nombre enregistré dans la variablenbAllumettes.
    Exemple :"||||||||||" sinbAllumettes= 10

### TOUR DU JOUEUR :

4. Demander à l’utilisateurcombien d’allumettes est-ce qu’il souhaite prendre (1,2 ou
    3) et l’enregistrerdans une variablechoixJoueur.
5. SilechoixJoueurest supérieur à 0etsi lechoixJoueurest inférieur à 4etsi le
    choixJoueurest inférieur ou égal ànbAllumettesRestantes alors:

```
(a) Retirer de la variablenbAllumettesRestanteslechoixJoueur.
(b)Afficher"Vous avez retiré X allumette(s)" avecX lechoixJoueur.
(c) Afficherautant d’espaces que d’allumettes retirées (nbAllumettes-nbAllu-
mettesRestantes) et autant de barres "|" que d’allumettes restantes
(nbAllumettesRestantes).
Exemple : " |||||||" si 3 allumettes sur 10 ont été retirées.
```
6. Sinon afficher"Veuillez choisir un nombre valide d’allumettes".
7. SilenbAllumettesRestantesest égale à 0alors afficher"Vous avez perdu !".

```
TOUR DE L’ORDINATEUR :
```
8. SilenbAllumettesRestantesest inférieur ou égal à 4etque lenbAllumettesRes-
    tantesest strictement supérieur à 1alorscréer une variablechoixOrdinateuret lui
    assignerla valeurnbAllumettesRestantes- 1.
9. Sinon silenbAllumettesRestantesest égal à 1alorscréer une variablechoixOr-
    dinateuret luiassignerla valeur 1


10. Sinoncréer une variablechoixOrdinateuret lui assigner un nombre aléatoire entre
    1 et 3.
11. Afficher"L’ordinateur a retiré X allumette(s)" avecXlechoixOrdinateur.
12. Retirer de la variablenbAllumettesRestanteslechoixOrdinateur.
13. Afficherautant d’espaces que d’allumettes retirées (nbAllumettes-nbAllumet-
    tesRestantes) et autant de barres "|" que d’allumettes restantes
    (nbAllumettesRestantes).
14. SilenbAllumettesRestantesest égale à 0alors afficher"Vous avez gagné! L’or-
    dinateur a retiré la dernière allumette".
15. Mettre en place uneboucle, tant que nbAllumettesRestantesest supérieur à 0,
    qui répète les instructions correspondant à un tour de joueur et un tour d’ordinateur,
    c’est-à-dire les instructions des questions 4 à 14. Ajouter l’instructioncontinueà la
    question 6 et l’instructionbreakà la question 7 et 14.