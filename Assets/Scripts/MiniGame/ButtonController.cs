using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private CartController cartController;
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        cartController = GameObject.FindObjectOfType<CartController>();
    }

    public void Tornar()
    {
        //string lastArea = playerController.GetLastArea();
        //Debug.Log(lastArea);
        //SceneManager.LoadScene(lastArea);
        //playerController.gameObject.SetActive(true);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }


    public void Restart()
    {
        //SceneManager.GetSceneByName("MiniGame");   //Reiniciar el joc
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Comencar()
    {
        cartController.comencar();
    }
}
