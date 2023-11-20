using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void Tornar()
    {
        
    }

    public void Restart()
    {
        //SceneManager.GetSceneByName("MiniGame");   //Reiniciar el joc
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
