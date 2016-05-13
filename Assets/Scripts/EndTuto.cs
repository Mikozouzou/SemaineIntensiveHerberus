using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndTuto : MonoBehaviour {

    public Dictionary<GameObject, bool> entityBoard;
    public GameObject mainDoor;
    public bool isTheEnd = false;


    void Start()
    {
        entityBoard = new Dictionary<GameObject, bool>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in players)
        {
            entityBoard.Add(go, false);
        }

        entityBoard.Add(GameObject.FindGameObjectWithTag("Trophy"), false);
    }

    void endTuto()
    {
        SceneManager.LoadScene("Main");
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
        endTuto();
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
