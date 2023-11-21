using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    PlayerController playerController;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void Tornar()
    {
        //string lastArea = playerController.GetLastArea();
        //Debug.Log(lastArea);
        //SceneManager.LoadScene(lastArea);
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        //SceneManager.GetSceneByName("MiniGame");   //Reiniciar el joc
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
