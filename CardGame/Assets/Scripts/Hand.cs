using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    int cardsToDraw = 4;
    public List<Unit> unitsInHand = new List<Unit>();
    public List<GameObject> unitsInHandDisplay = new List<GameObject>();
    public List<GameObject> lanesToPlace = new List<GameObject>();
    public GameObject baseCard;
    Deck deckMan;
    BoardManager boardMan;

    int selectedCard = -1;
    // Start is called before the first frame update
    void Start()
    {
        deckMan = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Deck>();
        boardMan = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BoardManager>();
        EndTurn();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    if (selectedCard == -1)
                    {
                        for (int i = 0; i < unitsInHandDisplay.Count; ++i)
                        {
                            if (hit.transform.gameObject == unitsInHandDisplay[i])
                            {
                                HideCards();
                                selectedCard = i;
                                return;
                            }
                        }
                        ShowCards();
                    }
                    else
                    {
                        for (int i = 0; i < lanesToPlace.Count; ++i)
                        {
                            if (hit.transform.gameObject == lanesToPlace[i])
                            {
                                if(boardMan.AddUnitToBoard(i, unitsInHand[selectedCard], true)) { 

                                    GameObject.Destroy(unitsInHandDisplay[selectedCard]);
                                    unitsInHandDisplay.RemoveAt(selectedCard);
                                    unitsInHand.RemoveAt(selectedCard);
                                    ShowCards();
                                    return;
                                }
                            }
                        }
                        ShowCards();
                    }
                }
                else
                {
                    ShowCards();
                }
            }
            else
            {
                ShowCards();
            }
        }
    }

    void HideCards() 
    {
        if (selectedCard != -1)
            return;
        for (int i = 0; i < unitsInHandDisplay.Count; ++i)
        {
            unitsInHandDisplay[i].transform.Translate(new Vector3(0, 0, 1.5f));
        }

    }
    void ShowCards()
    {
        if (selectedCard == -1)
            return;
        for (int i = 0; i < unitsInHandDisplay.Count; ++i)
        {
            unitsInHandDisplay[i].transform.Translate(new Vector3(0, 0, -1.5f));
        }
        selectedCard = -1;

    }
    public void EndTurn() 
    {

        for (int i = 0; i < unitsInHandDisplay.Count; ++i) {
            GameObject.Destroy(unitsInHandDisplay[i]);
        }
        unitsInHandDisplay.Clear();
        unitsInHand.Clear();
        for (int i = 0; i < cardsToDraw; ++i)
        {
            unitsInHand.Add(deckMan.unitsInDeck[i]);
            unitsInHandDisplay.Add(GameObject.Instantiate(baseCard,new Vector3(2 - i * 1.5f ,3, 7),Quaternion.Euler(new Vector3(152,180,180)), this.transform));
        }

    }
}
