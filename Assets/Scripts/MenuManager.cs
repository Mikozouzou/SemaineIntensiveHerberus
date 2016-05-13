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
        SceneManager.LoadScene("Menu");
    }

    public void credit()
    {
        SceneManager.LoadScene("Credits");
    }
}
