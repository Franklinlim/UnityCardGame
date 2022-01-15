using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    int cardsToDraw = 4;
    int maxMana = 3;
    int currMana;
    public List<Unit> unitsInHand = new List<Unit>();
    public List<GameObject> unitsInHandDisplay = new List<GameObject>();
    public List<GameObject> lanesToPlace = new List<GameObject>();
    public GameObject baseCard;
    public AudioClip errorSFX;
    Deck deckMan;
    BoardManager boardMan;

    public GameObject manaHandler;

    int selectedCard = -1;
    // Start is called before the first frame update
    void Start()
    {
        deckMan = GetComponent<Deck>();
        boardMan = GetComponent<BoardManager>();
        EndTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boardMan.GetDoneTurn())
            return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Handle select and playing of cards
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    if (selectedCard == -1)
                    {
                        for (int i = 0; i < unitsInHandDisplay.Count; ++i)
                        {
                            //Select Card
                            if (hit.transform.gameObject == unitsInHandDisplay[i])
                            {
                                //Checking for manacost
                                if (currMana >= unitsInHand[i].manaCost)
                                {
                                    HideCards();
                                    selectedCard = i;
                                    return;
                                }
                                else {
                                    GetComponent<AudioSource>().PlayOneShot(errorSFX);
                                }
                            }
                        }
                        ShowCards();
                    }
                    else
                    {
                        //Placing Card
                        for (int i = 0; i < lanesToPlace.Count; ++i)
                        {
                            if (hit.transform.gameObject == lanesToPlace[i])
                            {
                                //Play Card
                                if(boardMan.AddUnitToBoard(i, unitsInHand[selectedCard], true)) {

                                    currMana -= unitsInHand[selectedCard].manaCost;
                                    UpdateManaUI();
                                    GameObject.Destroy(unitsInHandDisplay[selectedCard]);
                                    unitsInHandDisplay.RemoveAt(selectedCard);
                                    unitsInHand.RemoveAt(selectedCard);
                                    ShowCards();
                                    return;
                                }
                            }
                        }
                        //If lane not clicked after selecting card
                        ShowCards();
                        GetComponent<AudioSource>().PlayOneShot(errorSFX);
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
        //Push cards down to show more of map
        if (selectedCard != -1)
            return;
        for (int i = 0; i < unitsInHandDisplay.Count; ++i)
        {
            unitsInHandDisplay[i].transform.Translate(new Vector3(0, 0, 1.5f));
        }

    }
    void ShowCards()
    {
        //Bring cards back up to select
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
        //Reset and draw cards
        currMana = maxMana;
        UpdateManaUI();
        for (int i = 0; i < unitsInHandDisplay.Count; ++i) {
            GameObject.Destroy(unitsInHandDisplay[i]);
        }
        unitsInHandDisplay.Clear();
        unitsInHand.Clear();
        for (int i = 0; i < cardsToDraw; ++i)
        {
            Unit unit = deckMan.unitsInDeck[i];
            unitsInHand.Add(unit);
            GameObject go = GameObject.Instantiate(baseCard, new Vector3(2 - i * 1.5f, 6.3f, 8.7f), Quaternion.Euler(new Vector3(152, 180, 180)), this.transform);
            go.GetComponent<Card>().unit = unit;
            go.GetComponent<Card>().Init();
            unitsInHandDisplay.Add(go);
        }

    }


    void UpdateManaUI()
    {
        //Update UI
        for (int i = 0; i < maxMana; ++i)
        {
            manaHandler.transform.GetChild(i + 1).gameObject.SetActive(false);
        }
        for (int i = 0; i < currMana; ++i) 
        {
            manaHandler.transform.GetChild(i + 1).gameObject.SetActive(true);
        }

    }
}
