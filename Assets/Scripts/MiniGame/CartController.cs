using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CartController : MonoBehaviour
{
    //Canvas elements
    [SerializeField]
    TextMeshProUGUI marcador;
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    GameObject panelFinal;
    [SerializeField]
    GameObject panelMsgFinal;
    [SerializeField]
    Image bananaImg;
    [SerializeField]
    TextMeshProUGUI msgFinalWin;
    [SerializeField]
    Image duckImg;
    [SerializeField]
    TextMeshProUGUI msgFinalOver;
    [SerializeField]
    GameObject btnTornar;
    [SerializeField]
    GameObject btnReiniciar;
    [SerializeField]
    TextMeshProUGUI msgInici;
    [SerializeField]
    TextMeshProUGUI msgTecles;
    [SerializeField]
    Image teclesImg;
    [SerializeField]
    GameObject btnComencar;

    PlayerController playerController;

    private Rigidbody2D cart;   //Jugador
    public Camera mainCamera;
    public float margin = 0.1f; //Marge per controlar la distància amb les cantonades (equerra i dreta)
    private bool edgeRight = false;
    private bool edgeLeft = false;
    public float speed;    //Velocitat amb la que es mou el jugador    
    public int puntuacioTotal;
    [SerializeField]
    public int total = 15;  //Puntuació total per acabar el joc
    public GameObject collectableBanana;
    public GameObject collectableDuck;

    private double timerCollectable;
    private double timerCollectableDuck;

    //Les variables per crear el timer
    float secondsCount = 0;

    public float totalTime = 30.0f; // Total time in seconds

    private bool timerZero = false;

    private Vector3 posicioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        posicioPlayer = playerController.gameObject.transform.position;
        playerController.gameObject.transform.position = Vector3.right * 20;

        Time.timeScale = 0;

        panelMsgFinal.SetActive(true);
        msgInici.gameObject.SetActive(true);
        msgTecles.gameObject.SetActive(true);
        teclesImg.gameObject.SetActive(true);
        btnComencar.SetActive(true);

        cart = GetComponent<Rigidbody2D>();
        secondsCount = totalTime;
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
        UpdateTimerUI();

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
            timerCollectable = 0.8f;
        }

        if (timerCollectableDuck <= 0f)    //Collectable Duck
        {
            Instantiate(collectableDuck, new Vector3(Random.Range(-8, 8), 10 + transform.position.y, 0), Quaternion.identity);     //Instanciem el col·leccionable
            timerCollectableDuck = 1.1f;
        }

        marcador.text = puntuacioTotal.ToString();
        
        //El joc para quan et quedes sense temps o quan aconsegueixes 15 plàtans
        if (timerZero)  //S'ha acabat el temps
        {
            Time.timeScale = 0;
            panelFinal.SetActive(true);
            panelMsgFinal.SetActive(true);
            duckImg.gameObject.SetActive(true);
            msgFinalOver.gameObject.SetActive(true);
            btnReiniciar.gameObject.SetActive(true);
        }

        if (puntuacioTotal == total && !timerZero)   //Has acabat el joc (15 punts)
        {
            playerController.gameObject.transform.position = posicioPlayer;
            Time.timeScale = 0;
            panelFinal.SetActive(true);
            panelMsgFinal.SetActive(true);
            bananaImg.gameObject.SetActive(true);
            msgFinalWin.gameObject.SetActive(true);
            btnTornar.gameObject.SetActive(true);
        }
    }

    public void calcularPuntuacio(int punt) //Funció per sumar punts (els punts li pasen els collectables des del script CollectableController.cs)
    {
        puntuacioTotal = puntuacioTotal + punt;
    }

    public void UpdateTimerUI() //Es tracta d'una funció per afegir un comptador al videojoc
    {
        secondsCount -= Time.deltaTime;

        if (secondsCount <= 0)
        {
            secondsCount = 0;
            // Handle timer reaching zero (e.g., end the game or perform some action)
            timerZero = true;
        }

        int seconds = Mathf.FloorToInt(secondsCount);

        timerText.text = string.Format("{00:00}", seconds);
    }

    public void comencar()
    {
        msgInici.gameObject.SetActive(false);
        msgTecles.gameObject.SetActive(false);
        teclesImg.gameObject.SetActive(false);
        btnComencar.SetActive(false);
        panelMsgFinal.SetActive(false);

        Time.timeScale = 1;
    }
}