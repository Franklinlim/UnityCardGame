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

    public bool atBoss = false;

    private void Start()
    {
        GetComponent<AudioSource>().playOnAwake = true;
        if (PlayerPrefs.HasKey("Health"))
        {
            boardManager.GetComponent<BoardManager>().LoadHealth();
            SetCurrentPos(PlayerPrefs.GetInt("BoardPos"));
        }
    }
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
        //Copy deck over and active board
        AI.GetComponent<Deck>().unitsInDeck = deck;
        canvas.SetActive(true);
        boardManager.SetActive(true);
        gameObject.SetActive(false);
        if (currentPos == bossPos)
        {
            atBoss = true;
        }
    }
    IEnumerator Waiter(GameObject go)
    {
        //Hide heal and card events
        yield return new WaitForSeconds(1.5f);
        go.SetActive(false);
    }
    public void SaveMapPos()
    {
        int mapPos = 0;
        for (; mapPos < transform.childCount; ++mapPos)
        {
            if (currentPos.transform == transform.GetChild(mapPos))
            {
                break;
            }
        }
        PlayerPrefs.SetInt("BoardPos", mapPos);
    }
    public void SetCurrentPos(int pos)
    {
        currentPos = transform.GetChild(pos).gameObject;
        for (int i = 0; i <= pos; ++i) {
            transform.GetChild(i).GetComponent<EventHandler>().isCleared = true;
        }
        UpdateCurrentPosMarker();
    }
    public void SaveGame() {

        boardManager.GetComponent<BoardManager>().SaveHealth();
        SaveMapPos();
    }
}