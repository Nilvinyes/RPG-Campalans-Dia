using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicialitzarDia : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
