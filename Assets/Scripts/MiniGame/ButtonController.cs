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
        Time.timeScale = 1;
        SceneManager.LoadScene(1);      //Reiniciar el joc
    }
}
