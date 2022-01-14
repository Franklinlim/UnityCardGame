using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public enum EventTypes { 
        Heal,
        Card,
        Fight
    
    }
    public EventTypes eventType;
    bool isCleared = false;

    // Update is called once per frame
    void Update()
    {
        if (isCleared)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.gameObject == this.gameObject)
                {
                    if (eventType == EventTypes.Heal)
                    {
                        transform.parent.GetComponent<MapManager>().HealEvent();
                    }
                    else if (eventType == EventTypes.Card)
                    {
                        transform.parent.GetComponent<MapManager>().CardEvent();
                    }
                    else
                    {
                        transform.parent.GetComponent<MapManager>().FightEvent(ref GetComponent<Deck>().unitsInDeck);
                    }
                    isCleared = true;
                }
            }


        }

    }
    public bool IsCleared() {
        return isCleared;
    }
    public void StartEvent()
    {
        if (eventType == EventTypes.Heal)
        {
            transform.parent.GetComponent<MapManager>().HealEvent();
        }
        else if (eventType == EventTypes.Card)
        {
            transform.parent.GetComponent<MapManager>().CardEvent();
        }
        else
        {
            transform.parent.GetComponent<MapManager>().FightEvent(ref GetComponent<Deck>().unitsInDeck);
        }
        isCleared = true;
    }
}
