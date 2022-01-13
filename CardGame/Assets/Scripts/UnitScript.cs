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
        if (isPlayer)
            gameObject.transform.GetChild(3).transform.Rotate(new Vector3(0, 180, 0));
        else
            gameObject.transform.GetChild(1).GetComponent<TextMesh>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

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
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        damageTaken = 0;
    }
}

