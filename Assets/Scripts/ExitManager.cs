using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExitManager : MonoBehaviour {
    public Dictionary<GameObject, bool> entityBoard;
    public GameObject mainDoor;
    public bool isTheEnd = false;


	void Start () 
	{
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
            GameManager.instance.EndTheGame(true);
        }
        else
        {
            //moveNextRoom
            CameraScrolling.instance.moveNextRoom();
            if(mainDoor)
            mainDoor.GetComponent<Door>().closeDoor();
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

    void closeTheDoorBehind()
    {

    }
}
