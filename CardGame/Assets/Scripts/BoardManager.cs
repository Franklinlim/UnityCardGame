using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[,] board = new GameObject[4, 6];
    public GameObject a;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        board[0, 0] = a;
        board[0, 5] = b;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void EndTurn()
    {
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

        //Killing off if 0 hp
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 6; ++j)
            {
                if (board[i, j] != null)
                {
                    if (board[i, j].GetComponent<UnitScript>().GetHealth() <= 0)
                    {
                        GameObject.Destroy(board[i, j]);
                        board[i, j] = null;
                    }
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
        int newJ = j;
        if (board[i, j].GetComponent<UnitScript>().isPlayer)
        {
            if (newJ != 5)
                newJ++;
        }
        else
        {
            if (newJ != 0)
                newJ--;
        }
        //If attacking square has unit and is of diff player
        if (board[i, newJ] != null && (board[i, newJ].GetComponent<UnitScript>().isPlayer != board[i, j].GetComponent<UnitScript>().isPlayer))
        {
            board[i, newJ].GetComponent<UnitScript>().DamageUnit(board[i, j].GetComponent<UnitScript>().GetAttack());
        }

    }
}
