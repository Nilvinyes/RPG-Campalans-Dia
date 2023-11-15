using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeliaController : MonoBehaviour
{
    
    public float speed = 1.1f; //Velocitat de l'obstacle

    //El temps per fer al reves
    public float timeBetweenReverse = 5;

    Rigidbody2D amelia;
    SpriteRenderer spriteRenderer;
    BoxCollider2D ameliaCollider;
    [SerializeField]
    SpriteRenderer shoppingCart;

    [SerializeField]
    Transform shoppinCartTransform;


    // Start is called before the first frame update
    void Start()
    {
        amelia = GetComponent<Rigidbody2D>();
        amelia.velocity = Vector2.left * speed;

        InvokeRepeating("Reverse", 3, timeBetweenReverse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reverse()
    {
        amelia = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ameliaCollider = GetComponent<BoxCollider2D>();
        amelia.velocity *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        shoppingCart.flipX = !shoppingCart.flipX;

        if (shoppingCart.flipX)
        {
            shoppinCartTransform.position = new Vector3(shoppinCartTransform.position.x + 2,
                                                    shoppinCartTransform.position.y,
                                                    shoppinCartTransform.position.z);

            ameliaCollider.offset = new Vector2(ameliaCollider.offset.x + 1,
                                                ameliaCollider.offset.y);                                        
                                                

        }
        else
        {
            shoppinCartTransform.position = new Vector3(shoppinCartTransform.position.x - 2,
                                                    shoppinCartTransform.position.y,
                                                    shoppinCartTransform.position.z);

            ameliaCollider.offset = new Vector2(ameliaCollider.offset.x - 1,
                                                ameliaCollider.offset.y);

        }
        
    }

}
