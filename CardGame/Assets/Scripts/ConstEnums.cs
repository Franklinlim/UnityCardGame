
public enum AllEffects
{
    None = 0,
    Calvary = 1, //Able to move twice as far
    Trebuchet = 2, // Unable to attack directly in front of it
    Horse = 3 //Unable to attack. Moves twice as far. Upon reaching foot soldiers, transform them into a mounted unit
}
public enum UnitType
{
    Swordman = 0,
    Archer,
    Spearman,

    MountedSwordman,
    MountedArcher,
    MountedSpearman,

    Trebuchet,
    Horse

};