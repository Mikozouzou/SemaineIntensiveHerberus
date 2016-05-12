using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {
    
    public GameObject playerPrefab;
    public GameObject[] animationPrefab;
    public Texture[] texturePrefab;

    void Awake () {

        for (int i = 0; i < 4; ++i)
        {
            PlayerIndex testPlayerIndex = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected)
            {
                Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                Vector3 pos = transform.position;
                pos.x += i*2;
                GameObject player = (GameObject)Instantiate(playerPrefab, pos, playerPrefab.transform.rotation);
                player.GetComponent<Movement>().playerID = i+1;

                GameObject anim = (GameObject)Instantiate(animationPrefab[i], pos, playerPrefab.transform.rotation);
                anim.transform.Rotate(new Vector3(0,180,0));
                anim.transform.position = new Vector3(pos.x, pos.y - 1, pos.z);
                anim.transform.parent = player.transform.FindChild("Player_Graphics").transform;

                anim.transform.FindChild("body").GetComponent<SkinnedMeshRenderer>().materials[0].mainTexture = texturePrefab[i];
                anim.transform.FindChild("body").GetComponent<SkinnedMeshRenderer>().materials[1].mainTexture = texturePrefab[i];
            }
        }
        
    }
}
