using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    public int currHealth;
    public int currAttack;
    public int unitType;

    public bool isPlayer;
    public bool moved;

    UnitTypeManager unitMan;


    // Start is called before the first frame update
    void Start()
    {
        unitMan = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnitTypeManager>();
        currHealth = unitMan.allUnitTypes[unitType].health;
        currAttack = unitMan.allUnitTypes[unitType].attack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
