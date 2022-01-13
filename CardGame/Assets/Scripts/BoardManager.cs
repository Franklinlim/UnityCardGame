using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[,] board = new GameObject[4, 6];

    bool doneTurn = true;
    public GameObject playerHealthHandler;
    public GameObject enemyHealthHandler;

    float timeForAttack = 0;
    int playerCastleHealth = 10;
    int enemyCastleHealth = 10;

    public bool AddUnitToBoard(int lane, Unit unitType, bool isPlayer) {

        if (isPlayer)
        {
            if (board[lane, 0] == null)
            {
                board[lane, 0] = GameObject.Instantiate(unitType.model, new Vector3(3 - lane * 2, 0, 5), Quaternion.identity, null);
                board[lane, 0].GetComponent<UnitScript>().unit = unitType;
                board[lane, 0].GetComponent<UnitScript>().isPlayer = true;
                return true;
            }
            return false;
        }
        else
        {
            if (board[lane, 5] == null)
            {
                board[lane, 5] = GameObject.Instantiate(unitType.model, new Vector3(3 - lane * 2, 0, -5), Quaternion.identity, null);
                board[lane, 5].GetComponent<UnitScript>().unit = unitType;
                board[lane, 5].GetComponent<UnitScript>().isPlayer = false;
                return true;
            }
            return false;
        }
    }
    public void EndTurn()
    {
        doneTurn = false;
        StartCoroutine(Waiter());
    }
    IEnumerator Waiter()
    {
        //Attacking
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 6; ++j)
            {
                if (board[i, j] != null)
                {
                    board[i, j].GetComponent<UnitScript>().ResetMovement();
                    Attack(i, j);
                }
            }
        }
        if (timeForAttack > 0)
        {
            yield return new WaitForSeconds(timeForAttack);
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 6; ++j)
                    if (board[i, j] != null)
                    {
                        board[i, j].GetComponentInChildren<Animator>().SetBool("Attack", false);
                        board[i, j].GetComponent<UnitScript>().UpdateHealth();
                    }   

            yield return new WaitForSeconds(timeForAttack);

            //Killing off if 0 hp
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 6; ++j)
                {
                    if (board[i, j] != null)
                    {
                        if (board[i, j].GetComponent<UnitScript>().GetHealth() <= 0)
                        {
                            board[i, j].GetComponentInChildren<Animator>().SetBool("Die", true);
                            board[i, j] = null;
                        }
                    }
                }
            }
            timeForAttack = 0;
            yield return new WaitForSeconds(2);
        }


        //Movement
        bool unitMoved;
        do
        {
            unitMoved = false;
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 6; ++j)
                {
                    if (board[i, j] != null)
                    {
                        if (Move(i, j))
                            unitMoved = true;
                    }
                }
            }
        } while (unitMoved);
        
        yield return new WaitForSeconds(2);
        //Damage Castle if unit at last row
        for (int i = 0; i < 4; ++i)
        {
            if (board[i, 0] != null && !board[i, 0].GetComponent<UnitScript>().isPlayer) { 
                playerCastleHealth -= board[i, 0].GetComponent<UnitScript>().unit.manaCost;
                GameObject.Destroy(board[i, 0]);
                board[i, 0] = null;
            }
            if (board[i, 5] != null && board[i, 5].GetComponent<UnitScript>().isPlayer)
            {
                enemyCastleHealth -= board[i, 5].GetComponent<UnitScript>().unit.manaCost;
                GameObject.Destroy(board[i, 5]);
                board[i, 5] = null;
            }
        }
        UpdateHealthUI();
       doneTurn = true;
    }
    bool Move(int i, int j)
    {
        bool unitMoved = false;
        while (board[i, j].GetComponent<UnitScript>().GetMovement() > 0)
        {
            int newJ = j;
            bool isPlayer = board[i, j].GetComponent<UnitScript>().isPlayer;
            if (isPlayer)
            {
                if (newJ != 5)
                    newJ++;
            }
            else
            {
                if (newJ != 0)
                    newJ--;
            }
            if (newJ != j && board[i, newJ] == null)
            {
                board[i, j].GetComponent<UnitScript>().ReduceMovement();
                board[i, j].GetComponentInChildren<Animator>().SetBool("Run", true);
                if (isPlayer)
                    StartCoroutine(MoveAnimated(board[i, j], board[i, j].transform.position + new Vector3(0, 0, -2), 2f));
                else
                    StartCoroutine(MoveAnimated(board[i, j], board[i, j].transform.position + new Vector3(0, 0, 2), 2f));
                board[i, newJ] = board[i, j];
                board[i, j] = null;
                j = newJ;
                unitMoved = true;
            }
            else
            {
                return false ;
            }
        }
        return unitMoved;
    }
    public IEnumerator MoveAnimated(GameObject go, Vector3 tgt, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = go.transform.position;
        while (elapsedTime < time)
        {
            go.transform.position = Vector3.Lerp(startingPos, tgt, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        go.transform.position = tgt;
        go.GetComponentInChildren<Animator>().SetBool("Run", false);
    }

    void Attack(int i, int j)
    {
        //Set starting/min range
        int tempRange = 0;
        //Check if has enemy and increase until max range
        while (tempRange++ < board[i, j].GetComponent<UnitScript>().unit.range)
        {
            int newJ = j;
            if (board[i, j].GetComponent<UnitScript>().isPlayer)
            {
                newJ += tempRange;
                if (newJ > 5)
                    newJ = 5;
            }
            else
            {
                newJ -= tempRange;
                if (newJ < 0)
                    newJ = 0;
            }
            //If attacking square has unit and is of diff player
            if (board[i, newJ] != null && (board[i, newJ].GetComponent<UnitScript>().isPlayer != board[i, j].GetComponent<UnitScript>().isPlayer))
            {
                board[i, j].GetComponentInChildren<Animator>().SetBool("Attack",true);
                board[i, newJ].GetComponent<UnitScript>().DamageUnit(board[i, j].GetComponent<UnitScript>().GetAttack());
                board[i, j].GetComponent<UnitScript>().ZeroMovement();
                //If there are attacks
                timeForAttack = 1;
                return;
            }
        }
    }

    public bool GetDoneTurn() {
        return doneTurn;
    }
    void UpdateHealthUI()
    {
        for (int i = 0; i < 10; ++i)
        {
            playerHealthHandler.transform.GetChild(i + 1).gameObject.SetActive(false);
            enemyHealthHandler.transform.GetChild(i + 1).gameObject.SetActive(false);
        }
        for (int i = 0; i < playerCastleHealth; ++i)
        {
            playerHealthHandler.transform.GetChild(i + 1).gameObject.SetActive(true);
        }
        for (int i = 0; i < enemyCastleHealth; ++i)
        {
            enemyHealthHandler.transform.GetChild(i + 1).gameObject.SetActive(true);
        }

    }
}
