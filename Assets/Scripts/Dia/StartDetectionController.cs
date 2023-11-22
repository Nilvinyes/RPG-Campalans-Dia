using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;

public class StartDetectionController : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int linePosition;
    private bool automaticActivation = true;

    [SerializeField, TextArea(4, 6)]
    private string[] dialogueLines;

    [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField]
    private TMP_Text dialogueText;

    private static StartDetectionController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((isPlayerInRange && Input.GetKeyDown(KeyCode.F)) || (isPlayerInRange && automaticActivation))
        {
            automaticActivation = false;
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[linePosition])
            {
                NextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[linePosition];                
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
        if (linePosition < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);

            PlayerController player = FindAnyObjectByType<PlayerController>();
            player.moveSpeed = 5;
            BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
            collider.enabled = false;
                       
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = "";

        foreach (var character in dialogueLines[linePosition])
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }


}
