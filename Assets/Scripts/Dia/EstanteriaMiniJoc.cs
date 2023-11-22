using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstanteriaMiniJoc : MonoBehaviour
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

    PlayerController player;

    [SerializeField]
    public string areaToLoad;

    [SerializeField]
    public string areaJointPoint;

    [SerializeField]
    private GameObject caixer;

    public AreaEntrance entranceAssociatedToExit;

    private static EstanteriaMiniJoc instance;

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
        entranceAssociatedToExit.areaJointPoint = areaJointPoint;

        player = FindAnyObjectByType<PlayerController>();
        player.moveSpeed = 5;


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

    }

    private void StartDialogue()
    {

        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        linePosition = 0;

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

            
            player.moveSpeed = 5;
            caixer.SetActive(true);
            //guardem al jugador el punt on el voldrem posar
            //player.SetLastArea(SceneManager.GetActiveScene().name);

            //carreguem l'escena
            PlayerController.instance.areaJointPoint = areaJointPoint;
            PlayerController.instance.SetLastArea(SceneManager.GetActiveScene().name);
            //carreguem l'escena
            SceneManager.LoadScene(areaToLoad);

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
