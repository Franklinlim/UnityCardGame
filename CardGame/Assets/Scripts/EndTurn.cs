using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainCam.GetComponent<BoardManager>().GetDoneTurn())
            return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.gameObject == this.gameObject)
                {
                    mainCam.GetComponent<AI>().EndTurn();
                    mainCam.GetComponent<BoardManager>().EndTurn();
                    mainCam.GetComponent<Deck>().EndTurn();
                    mainCam.GetComponent<Hand>().EndTurn();
                }
            }


        }
    }
}