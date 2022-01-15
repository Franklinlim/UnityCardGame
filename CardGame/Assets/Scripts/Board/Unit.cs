using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Unit : ScriptableObject
{
    public string unitName;
    public int manaCost;
    public int attack;
    public int health;
    public int range;
    public int movement;
    public GameObject model;
    public Material icon;
    public AudioClip attackSFX;
}
