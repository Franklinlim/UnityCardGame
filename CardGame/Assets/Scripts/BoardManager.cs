using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[,] board = new GameObject[4, 6];
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

        //Attacking
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 6; ++j)
            {
                if (board[i, j] != null)
                {
                    board[i, j].GetComponent<UnitScript>().ResetMovement();
                    Attack(i, j);
                    board[i, j].GetComponentInChildren<Animator>().SetBool("Attack", false);
                }
            }
        }

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
                        //GameObject.Destroy(board[i, j]);
                        board[i, j] = null;
                    }
                }
            }
        }

        //Movement
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 6; ++j)
            {
                if (board[i, j] != null)
                {
                    Move(i, j);
                }
            }
        }
    }

    void Move(int i, int j)
    {
        while (board[i, j].GetComponent<UnitScript>().GetMovement() > 0)
        {
            int newJ = j;
            bool isPlayer = board[i, j].GetComponent<UnitScript>().isPlayer;
            if (isPlayer)
            {
                if (newJ != 4)
                    newJ++;
            }
            else
            {
                if (newJ != 1)
                    newJ--;
            }
            if (newJ != j && board[i, newJ] == null)
            {
                board[i, j].GetComponent<UnitScript>().ReduceMovement();
                if (isPlayer)
                    board[i, j].transform.Translate(new Vector3(0, 0, -2));
                else
                    board[i, j].transform.Translate(new Vector3(0, 0, 2));
                board[i, newJ] = board[i, j];
                board[i, j] = null;
                j = newJ;
            }
            else {
                return;
            }
        }
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
                return;
            }
        }
    }
}
