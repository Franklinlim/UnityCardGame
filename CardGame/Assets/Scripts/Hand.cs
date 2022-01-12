using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    int cardsToDraw = 4;
    public List<Unit> unitsInHand = new List<Unit>();
    Deck deckMan;
    // Start is called before the first frame update
    void Start()
    {
        deckMan = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Deck>();
        EndTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTurn() {

        unitsInHand.Clear();
        for (int i = 0; i < cardsToDraw; ++i)
        {
            unitsInHand.Add(deckMan.unitsInDeck[i]);
        }

    }
}
