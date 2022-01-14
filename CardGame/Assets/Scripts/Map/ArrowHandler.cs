using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour
{
    public GameObject target;
    public GameObject MapManager;

    // Update is called once per frame
    void Update()
    {
        if (!transform.parent.GetComponent<EventHandler>().IsCleared())
            return;
        if (MapManager.GetComponent<MapManager>().currentPos != transform.parent.gameObject)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.gameObject == this.gameObject)
                {
                    MapManager.GetComponent<MapManager>().currentPos = target;
                    MapManager.GetComponent<MapManager>().UpdateCurrentPosMarker();
                    target.GetComponent<EventHandler>().StartEvent();
                }
            }


        }
    }
}
