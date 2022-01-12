using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    int currHealth;
    int currAttack;
    UnitType unitType;
    int currMovement;

    public bool isPlayer;

    UnitTypeManager unitMan;


    // Start is called before the first frame update
    void Start()
    {
        unitMan = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnitTypeManager>();
        currHealth = unitMan.allUnitTypes[(int)unitType].health;
        currAttack = unitMan.allUnitTypes[(int)unitType].attack;
        ResetMovement();                  
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamageUnit(int damage)
    {
        currHealth -= damage;
        if (currHealth < 0)
            currHealth = 0;
    }
    public int GetAttack()
    {
        return currAttack;
    }
    public UnitType GetUnitType()
    {
        return unitType;
    }
    public int GetHealth()
    {
        return currHealth;
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
        if(unitMan.allUnitTypes[(int)unitType].effect == AllEffects.Calvary || unitMan.allUnitTypes[(int)unitType].effect == AllEffects.Horse)
        {
            currMovement = 2;
        }
        else
        {
            currMovement = 1;
        }
    }
}
