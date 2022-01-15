using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public Unit unit;
    int currHealth;
    int currAttack;
    int currMovement;
    int damageTaken;
    bool hasAttacked;

    public bool isPlayer;

    public void Init()
    {
        //Init all stats and facing direction
        hasAttacked = false;
        ResetMovement();
        currHealth = unit.health;
        currAttack = unit.attack;
        gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = currAttack.ToString();
        gameObject.transform.GetChild(1).GetComponent<TextMesh>().text = currHealth.ToString();
        gameObject.transform.GetChild(2).GetComponent<TextMesh>().text = unit.name;
        if (isPlayer)
        {
            gameObject.transform.GetChild(3).transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            gameObject.transform.GetChild(1).GetComponent<TextMesh>().color = Color.red;
        }
        GetComponent<AudioSource>().clip = unit.attackSFX;
    }

    public void DamageUnit(int damage)
    {
        currHealth -= damage;
        damageTaken = damage;
        if (currHealth < 0)
            currHealth = 0;
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
    public bool GetHasAttacked()
    {
        return hasAttacked;
    }
    public void SetHasAttacked(bool att) {
        hasAttacked = att;
    }
    public void ReduceMovement()
    {
        currMovement--;
    }
    public void ZeroMovement()
    {
        currMovement = 0;
    }
    public void ResetMovement() {
        currMovement = unit.movement;
    }
    public void UpdateHealth() {
        //Update health shown later so that it coincides with attacking animation
        gameObject.transform.GetChild(1).GetComponent<TextMesh>().text = currHealth.ToString();
        if (damageTaken != 0)
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
            gameObject.transform.GetChild(4).GetComponent<TextMesh>().text = "-"+damageTaken.ToString();
            StartCoroutine(SetInactiveWait());
        }
    }
    public IEnumerator SetInactiveWait()
    {
        //Hide damage taken number
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        damageTaken = 0;
    }
}

