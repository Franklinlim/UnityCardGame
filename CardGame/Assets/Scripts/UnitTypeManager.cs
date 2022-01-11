using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTypeManager : MonoBehaviour
{
    enum AllEffects
    {
        None = 0,
        Calvary = 1, //Able to move twice as far
        Trebuchet = 2, // Unable to attack directly in front of it
        Horse = 3 //Unable to attack. Moves twice as far. Upon reaching foot soldiers, transform them into a mounted unit
    }

    public class Unit
    {
        public Unit(string _unitName, int _manaCost, int _attack, int _health, int _range, int _effect)
        {
            unitName = _unitName;
            manaCost = _manaCost; 
            attack = _attack;
            health = _health; 
            range = _range;
            effect = _effect;

        }
        public string unitName;
        public int manaCost;
        public int attack;
        public int health;
        public int range;
        public int effect;
    };
    public List<Unit> allUnitTypes = new List<Unit>();



    // Start is called before the first frame update
    void Start()
    {
        allUnitTypes.Add(new Unit("Warrior", 1, 1, 3, 1, 0));
        allUnitTypes.Add(new Unit("Archer", 1, 1, 2, 2, 0));
        allUnitTypes.Add(new Unit("Spearmen", 2, 2, 3, 1, 0));

        allUnitTypes.Add(new Unit("Mounted Warrior", 3, 2, 4, 1, 1));
        allUnitTypes.Add(new Unit("Mounted Archer", 3, 2, 3, 2, 1));
        allUnitTypes.Add(new Unit("Mounted Spearmen", 4, 3, 4, 1, 1));

        allUnitTypes.Add(new Unit("Trebuchet", 3, 3, 4, 3, 2));
        allUnitTypes.Add(new Unit("Horse", 1, 0, 1, 0, 2));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
