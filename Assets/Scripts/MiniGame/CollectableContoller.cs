using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableContoller : MonoBehaviour
{
    private CartController cartController;

    // Start is called before the first frame update
    void Start()
    {
        cartController = GameObject.FindObjectOfType<CartController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Final")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Player" && collision.tag != "CartLeft" && collision.tag != "CartRight")
        {            
            if (gameObject.tag == "Banana")
            {
                cartController.calcularPuntuacio(1);
            } else if (gameObject.tag == "Duck")
            {
                cartController.calcularPuntuacio(-1);
            }

            Destroy(gameObject);
        }
    }    
}
