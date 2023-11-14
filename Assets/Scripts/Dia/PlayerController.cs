using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //la velocitat del moviment del jugador
    public float moveSpeed;
    //l'animador de l'sprite del jugador

    //aquí guardarem UNA i només UNA referencia al jugador,
    // com que és estàtic serà accesible per tots els objectes
    public static PlayerController instance;

    //el punt d'unió entre dues àrees. És com un teletransportador, un punt que 
    // existeix a les dues àrees i que farem servir per canviar d'una a una altra.

    //per controlar la darrera escena quan transitem cap un Screen, la que deixem enrera
    private Rigidbody2D playerRB;

    // Use this for initialization
    void Start () {
        //si no existeix el PlayerController
        
        //assignem el rigidbody
        playerRB = this.GetComponent<Rigidbody2D>();

       
    }
	
	// Update is called once per frame
	void Update () {
        //podem la velocitat del rigidbody a on indica l'input
        playerRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;

       
    }
   
}
