using System;
using System.Collections.Generic;
using System.Linq;

class Druid : IPersonnage
{
    public Druid()
        : base(4, 1,
        "Grâce à votre magie, vous gelerez l'adversaire au prochain tour",
        "Vous invoquez une magie infligeant 1 dégâts à l'adversaire",
        "Vous créer un mur, bloquant ainsi l'attaque adverse") { }

    /// <summary>
    /// Booléen indiquant l'actiation ou non de son spécial
    /// </summary>
    private bool specialActive = false;

    /// <summary>
    /// Personnage à qui changer le booléen de specialDruid
    /// </summary>
    private IPersonnage specialPerso;

    public override void Special(IPersonnage ennemi)
    {
        this.specialActive = true;
        this.specialPerso = ennemi;
    }

    public override void EndRound()
    {
        Console.WriteLine(this.specialPerso.isDefense);
        this.specialPerso.specialDruid = specialActive;
        specialActive = false;
        base.EndRound();
    }
}