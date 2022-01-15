using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Unit unit;
    int health;
    int attack;
    int mana;
    public void Init()
    {
        //Init Card details
        attack = unit.attack;
        health = unit.health;
        mana = unit.manaCost;

        gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = attack.ToString();
        gameObject.transform.GetChild(1).GetComponent<TextMesh>().text = health.ToString();
        gameObject.transform.GetChild(2).GetComponent<TextMesh>().text = unit.name;
        gameObject.transform.GetChild(3).GetComponent<MeshRenderer>().material = unit.icon;

        //Mana
        for (int i = 0; i < 3; ++i)
        {
            gameObject.transform.GetChild(4).GetChild(i).gameObject.SetActive(false);
        }
        if (mana == 1)
            gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(true);
        else if (mana == 2)
        {
            gameObject.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            for (int i = 0; i < 3; ++i)
            {
                gameObject.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
            }
        }

    }
}

