using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public Unit unit;
    int currMovement;

    public bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        ResetMovement();                  
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamageUnit(int damage)
    {
        unit.health -= damage;
        if (unit.health < 0)
            unit.health = 0;
    }
    public int GetAttack()
    {
        return unit.attack;
    }
    public int GetHealth()
    {
        return unit.health;
    }
    public int GetMovement()
    {
        return currMovement;
    }
    public void ReduceMovement()
    {
        currMovement--;
    }
    public void ResetMovement() {
        if(unit.effect == AllEffects.Calvary || unit.effect == AllEffects.Horse)
        {
            currMovement = 2;
        }
        else
        {
            currMovement = 1;
        }
    }
}
