using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {
    
    public void retry()
    {
        SceneManager.LoadScene("Main");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void credit()
    {
        SceneManager.LoadScene("Credits");
    }
}
