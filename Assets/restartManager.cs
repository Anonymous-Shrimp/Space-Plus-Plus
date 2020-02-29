using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartManager : MonoBehaviour
{
    

    public void restart()
    {
        Debug.Log("Restarting...");
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }

   
}
