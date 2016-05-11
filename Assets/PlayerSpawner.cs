﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerSpawner : MonoBehaviour {
    
    public GameObject playerPrefab;

    void Awake () {
        for (int i = 0; i < 4; ++i)
        {
            PlayerIndex testPlayerIndex = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected)
            {
                Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                Vector3 pos = transform.position;
                pos.x += i;
                GameObject player = (GameObject)Instantiate(playerPrefab, pos, playerPrefab.transform.rotation);
                player.GetComponent<Movement>().playerID = i+1;
            }
        }
        
    }
}
