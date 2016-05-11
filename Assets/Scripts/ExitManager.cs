using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExitManager : MonoBehaviour {
    public GameObject winUI;
    public Dictionary<GameObject, bool> entityBoard;
	
	void Start () {
        entityBoard = new Dictionary<GameObject, bool>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in players)
        {
            entityBoard.Add(go, false);
        }
        
        entityBoard.Add(GameObject.FindGameObjectWithTag("Trophy"), false);
    }

    void endGame()
    {
        Debug.Log("Players Win");
        if (winUI)
        {
            winUI.SetActive(true);
        }
        Time.timeScale = 0;
    }

    void checkBoard()
    {
        foreach (KeyValuePair<GameObject, bool> pair in entityBoard)
        {
            if (pair.Value == false)
            {
                return;
            }
        }
        endGame();
    }

    void OnTriggerEnter(Collider col)
    {
        if (entityBoard.ContainsKey(col.gameObject))
        {
            entityBoard[col.gameObject] = true;
            checkBoard();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (entityBoard.ContainsKey(col.gameObject))
        {
            entityBoard[col.gameObject] = false;
        }
    }
}
