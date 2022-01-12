using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public Unit unit;
    int currHealth;
    int currAttack;
    int currMovement;

    public bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        ResetMovement();
        currHealth = unit.health;
        currAttack = unit.attack;
        gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = currAttack.ToString();
        gameObject.transform.GetChild(1).GetComponent<TextMesh>().text = currHealth.ToString();
        gameObject.transform.GetChild(2).GetComponent<TextMesh>().text = unit.name;
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
        gameObject.transform.GetChild(1).GetComponent<TextMesh>().text = currHealth.ToString();
    }
    public int GetAttack()
    {
        return currAttack;
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
