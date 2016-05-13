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
    
	
}
