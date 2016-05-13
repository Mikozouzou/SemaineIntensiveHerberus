using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExitManager : MonoBehaviour {
    public GameObject winUI;
    public Dictionary<GameObject, bool> entityBoard;
    public bool isTheEnd = false;
	void Start () {
        entityBoard = new Dictionary<GameObject, bool>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in players)
        {
            entityBoard.Add(go, false);
        }
        
        entityBoard.Add(GameObject.FindGameObjectWithTag("Trophy"), false);
    }

    void endRoom()
    {
        if (isTheEnd)
        {
            Debug.Log("Players Win");
            if (winUI)
            {
                winUI.SetActive(true);
            }
            GameManager.instance.EndTheGame(true);
        }
        else
        {
            //moveNextRoom
            CameraScrolling.instance.moveNextRoom();
        }
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
        endRoom();
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
