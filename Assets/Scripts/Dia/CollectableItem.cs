using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    DialogueController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<DialogueController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AbuelaController objectes = FindObjectOfType<AbuelaController>();


        if (collision.CompareTag("Player") && !objectes.firstTime && Input.GetKeyDown(KeyCode.F))
        {    
            controller.enabled = true;
            if (objectes != null)
            {
                objectes.CollectObject();
                Destroy(gameObject);
            }
        }
    }
}
