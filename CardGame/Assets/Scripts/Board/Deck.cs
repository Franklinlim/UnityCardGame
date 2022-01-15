using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Unit> unitsInDeck = new List<Unit>();
    // Start is called before the first frame update
    void Start()
    {
        EndTurn();
    }

    void Swap(ref List<Unit> d, int i, int j) {
        //Swap cards in deck
        Unit temp = d[i];
        d[i] = d[j];
        d[j] = temp;
    }
    public void EndTurn() {

        //Shuffle Deck
        for (int i = 0; i < unitsInDeck.Count - 2; ++i)
        {
            Swap(ref unitsInDeck, i, Random.Range(i + 1, unitsInDeck.Count));
        }
    }
    public void AddCard(Unit unit)
    {
        //Add unit to Deck
        unitsInDeck.Add(unit);
        EndTurn();
    }
}
