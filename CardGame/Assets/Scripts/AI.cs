using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    BoardManager boardMan;
    // Start is called before the first frame update
    void Start()
    {
        boardMan = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BoardManager>();

    }

    public void EndTurn() {
        boardMan.AddUnitToBoard(Random.Range(0, 4), GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Deck>().unitsInDeck[0], false);
    }
}
