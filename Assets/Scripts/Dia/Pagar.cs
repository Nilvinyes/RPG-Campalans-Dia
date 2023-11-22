using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pagar : MonoBehaviour
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

    [SerializeField]
    private GameObject bananas;

    [SerializeField]
    private SpriteRenderer spriteBanana;

    [SerializeField]
    private TMP_Text monedes;

    [SerializeField]
    private GameObject textFinal;

    private static Pagar instance;



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
        if ((isPlayerInRange && Input.GetKeyDown(KeyCode.F)))
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("Se acabo");
        }

    }

    private void StartDialogue()
    {

        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        linePosition = 0;

        PlayerController player = FindAnyObjectByType<PlayerController>();
        player.moveSpeed = 0;
        monedes.text = "0";

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
            StartCoroutine(Banana());

            
        }
    }

    private IEnumerator Banana()
    {
        spriteBanana.sortingOrder = 5;
        yield return new WaitForSeconds(1f);
        bananas.transform.position = new Vector3(bananas.transform.position.x,
                                                 bananas.transform.position.y - 0.7f,
                                                 bananas.transform.position.z);
        yield return new WaitForSeconds(2f);

        spriteBanana.sortingOrder = 0;

        yield return new WaitForSeconds(0.5f);

        textFinal.SetActive(true);

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
