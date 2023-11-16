using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int linePosition;
  

    [SerializeField, TextArea(4, 6)]
    private string[] dialogueLines;

    [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField]
    private TMP_Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {      

    }

    // Update is called once per frame
    void Update()
    {
        AbuelaController objectes = FindObjectOfType<AbuelaController>();
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F) && !objectes.firstTime)
        {
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
        AbuelaController objectes = FindObjectOfType<AbuelaController>();
        isPlayerInRange = true;
        if (collision.CompareTag("Player") && !objectes.firstTime)
        {
            isPlayerInRange = true;
            if (objectes != null)
            {
                objectes.CollectObject();
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


}
