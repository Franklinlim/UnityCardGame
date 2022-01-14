using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public GameObject board;
    public GameObject AI;


    // Update is called once per frame
    void Update()
    {
        if (!board.GetComponent<BoardManager>().GetDoneTurn())
            return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.gameObject == this.gameObject)
                {
                    AI.GetComponent<AI>().EndTurn();
                    board.GetComponent<BoardManager>().EndTurn();
                    board.GetComponent<Deck>().EndTurn();
                    board.GetComponent<Hand>().EndTurn();
                }
            }


        }
    }
}