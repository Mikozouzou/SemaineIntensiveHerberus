using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    bool isVictory;
	void Awake () {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
	}

    public void EndTheGame(bool isWin)
    {
        isVictory = isWin;
        SceneManager.LoadScene(1);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level==1)
        {
            if (isVictory)
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Victory";
            }
            else
            {
                GameObject.Find("Title").GetComponent<Text>().text = "Defeat";
            }
            
        }
    }
	
}
