using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject currentPos;
    public GameObject currentPosMarker;

    public GameObject boardManager;
    public GameObject AI;
    public GameObject canvas;

    public GameObject healObject;
    public Unit DogWarrior;
    public GameObject cardObject;

    public GameObject bossPos;
    public GameObject victoryObject;
    public void UpdateCurrentPosMarker()
    {
        currentPosMarker.transform.position = new Vector3(currentPos.transform.position.x, 2, currentPos.transform.position.z);
    }
    public void HealEvent()
    {

        healObject.SetActive(true);
        boardManager.GetComponent<BoardManager>().HealPlayer(2);
        StartCoroutine(Waiter(healObject));
    }
    public void CardEvent()
    {
        cardObject.SetActive(true);
        boardManager.GetComponent<Deck>().AddCard(DogWarrior);
        StartCoroutine(Waiter(cardObject));
    }
    public void FightEvent(ref List<Unit> deck)
    {
        AI.GetComponent<Deck>().unitsInDeck = deck;
        canvas.SetActive(true);
        boardManager.SetActive(true);
        gameObject.SetActive(false);
        if (currentPos == bossPos)
            victoryObject.SetActive(true);
    }
    IEnumerator Waiter(GameObject go)
    {
        yield return new WaitForSeconds(1.5f);
        go.SetActive(false);
    }
}