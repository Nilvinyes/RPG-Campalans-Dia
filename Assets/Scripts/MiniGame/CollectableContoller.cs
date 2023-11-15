using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableContoller : MonoBehaviour
{
    private int puntuacio;

    // Start is called before the first frame update
    void Start()
    {
        //CartController cartController = GetComponent<CartController>();

        //cartController.puntuacioTotal = puntuacio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Final")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Player" && collision.tag != "CartLeft" && collision.tag != "CartRight")
        {
            Destroy(gameObject);
            if (gameObject.tag == "Banana")
            {                
                puntuacio++;
            } else if (gameObject.tag == "Duck")
            {
                puntuacio--;
            }

            Debug.Log(puntuacio);
        }
    }    
}
