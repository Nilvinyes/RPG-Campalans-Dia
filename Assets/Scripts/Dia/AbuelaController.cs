using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbuelaController : MonoBehaviour
{
    public int requiredObjectsCount = 3;
    private int collectedObjectsCount = 0;


    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int linePosition;

    public bool firstTime = true;

    [SerializeField]
    private GameObject icon;

    [SerializeField, TextArea(4, 6)]
    private string[] dialogueLines1;

    [SerializeField, TextArea(4, 6)]
    private string[] dialogueLines2;

    [SerializeField, TextArea(4, 6)]
    private string[] dialogueLines3;


    string[] actualDialogue;

    [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private GameObject textMenjar;

    [SerializeField]
    private GameObject panelMenjar;

    [SerializeField]
    private TextMeshProUGUI monedes;

    [SerializeField]
    private GameObject deteccioPlatan;

    [SerializeField]
    private GameObject coin;

    // Start is called before the first frame update
    void Start()
    {              
        actualDialogue = dialogueLines1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == actualDialogue[linePosition])
            {
                NextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = actualDialogue[linePosition];          
            }
        }
    }

    private void StartDialogue()
    {

        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        linePosition = 0;       

        PlayerController player = FindAnyObjectByType<PlayerController>();
        player.moveSpeed = 0;

        StartCoroutine(ShowLine());
    }

    private void NextDialogue()
    {
        linePosition++;
        if (linePosition < actualDialogue.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {           
            didDialogueStart = false;
            dialoguePanel.SetActive(false);

            PlayerController player = FindAnyObjectByType<PlayerController>();
            player.moveSpeed = 5;
            GestionarCanvas();           
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = "";

        foreach (var character in actualDialogue[linePosition])
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(0.05f);
        }
    }


    private void GestionarCanvas()
    {
        if (collectedObjectsCount == requiredObjectsCount)
        {
            icon.SetActive(false);
            textMenjar.SetActive(false);
            panelMenjar.SetActive(false);
            monedes.text = "2";
            deteccioPlatan.SetActive(true);
            StartCoroutine(Coin());
        }
        else if (!firstTime)
        {
            textMenjar.SetActive(true);
            panelMenjar.SetActive(true);
        }
    }

    private IEnumerator Coin()
    {
        coin.SetActive(true);
        yield return new WaitForSeconds(2f);
        coin.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (firstTime)
            {
                Debug.Log(firstTime);
                actualDialogue = dialogueLines1;
                firstTime = false;

            }
            else if(collectedObjectsCount == requiredObjectsCount) 
            {
                Debug.Log(firstTime);
                Debug.Log(collectedObjectsCount);
                actualDialogue = dialogueLines3;
            }
            else
            {
                Debug.Log(firstTime);
                Debug.Log(collectedObjectsCount);
                actualDialogue = dialogueLines2;
                
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }


    //________________________________________________________________________________________________
    public void CollectObject()
    {
        collectedObjectsCount++;   
       
    }


}
