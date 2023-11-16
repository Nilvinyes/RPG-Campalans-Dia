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
                icon.SetActive(false);
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
        // Puedes agregar lógica adicional aquí según el tipo de objeto
        // Por ejemplo, mostrar mensajes específicos para cada objeto.
    }


}
