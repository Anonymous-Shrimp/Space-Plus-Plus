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

    public void menu()
    {
        Debug.Log("Returning to menu...;");
        SceneManager.LoadScene(0);
    }

   
}
