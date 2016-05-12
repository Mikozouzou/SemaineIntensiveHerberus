using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerSpawner : MonoBehaviour {
    
    public GameObject playerPrefab;
    public GameObject[] animationPrefab;

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

                GameObject anim = (GameObject)Instantiate(animationPrefab[i], pos, playerPrefab.transform.rotation);
                anim.transform.Rotate(new Vector3(0,180,0));
                anim.transform.position = new Vector3(pos.x, pos.y - 1, pos.z);
                anim.transform.parent = player.transform.FindChild("Player_Graphics").transform;
            }
        }
        
    }
}
