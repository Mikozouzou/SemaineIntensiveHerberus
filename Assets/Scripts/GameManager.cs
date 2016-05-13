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
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        
    }

    void OnLevelWasLoaded(int level)
    {
        if (level==1||level==2)
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
