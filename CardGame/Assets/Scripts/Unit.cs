using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
   
    public Unit(string _unitName, int _manaCost, int _attack, int _health, int _range, AllEffects _effect)
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
    public AllEffects effect;
}
