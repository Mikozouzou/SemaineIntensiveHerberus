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
        if (isWin)
        {
            SceneManager.LoadScene("Victory");
        }
        else
        {
            SceneManager.LoadScene("Defeat");
        }
        
    }

    void OnLevelWasLoaded(int level)
    {
        if (level==3||level==4)
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
