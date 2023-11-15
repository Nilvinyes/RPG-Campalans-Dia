using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CartController : MonoBehaviour
{
    private Rigidbody2D cart;   //Jugador
    public Camera mainCamera;
    public float margin = 0.1f; //Marge per controlar la distància amb les cantonades (equerra i dreta)
    private bool edgeRight = false;
    private bool edgeLeft = false;
    public float speed;    //Veloccitat amb la que es mou el jugador
    internal int puntuacioTotal;
    public GameObject collectableBanana;
    public GameObject collectableDuck;

    private double timerCollectable = 1f;
    private double timerCollectableDuck = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        cart = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");

        if(xMovement > 0 && !edgeLeft)
        {
            cart.velocity = Vector2.right * speed;
        } else if (xMovement < 0 && !edgeRight)
        {
            cart.velocity = Vector2.left * speed;
        }
        else {
            cart.velocity = Vector2.zero;
        }
    }

    void Update()
    {
        timerCollectable -= Time.deltaTime;
        timerCollectableDuck -= Time.deltaTime;

        //Obtenim la posició del jugador en la pantalla
        Vector3 playerScreenPos = mainCamera.WorldToViewportPoint(transform.position);

        //Comprova quan el jugador està a punt de sortir de la càmara
        if (playerScreenPos.x < margin) //El jugador està al marge dret de la càmera
        {
            cart.velocity = Vector2.zero;
            edgeRight = true;

        } else if(playerScreenPos.x > 1 - margin)   //El jugador està al marge esquerra de la càmera
        {
            cart.velocity = Vector2.zero;
            edgeLeft = true;
        }
        else
        {
            edgeRight = false;
            edgeLeft = false;
        }

        if (timerCollectable <= 0f)    //Collectable Banana
        {
            Instantiate(collectableBanana, new Vector3(Random.Range(-8, 8), 10 + transform.position.y, 0), Quaternion.identity);     //Instanciem el col·leccionable
            timerCollectable = 1f;
            //Debug.Log(puntuacioTotal);
        }

        if (timerCollectableDuck <= 0f)    //Collectable Duck
        {
            Instantiate(collectableDuck, new Vector3(Random.Range(-8, 8), 10 + transform.position.y, 0), Quaternion.identity);     //Instanciem el col·leccionable
            timerCollectableDuck = 1.3f;
            //Debug.Log(puntuacioTotal);
        }
    }
}
