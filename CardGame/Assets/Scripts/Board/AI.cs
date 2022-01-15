using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject board;
    BoardManager boardMan;
    // Start is called before the first frame update
    void Start()
    {
        boardMan = board.GetComponent<BoardManager>();

    }

    public void EndTurn() {
        //Add the first card from their deck then shuffle it
        boardMan.AddUnitToBoard(Random.Range(0, 4), GetComponent<Deck>().unitsInDeck[0], false);
        GetComponent<Deck>().EndTurn();
    }
}
