using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AbuelaController objectes = FindObjectOfType<AbuelaController>();

            if (objectes != null)
            {
                objectes.CollectObject(itemName);
                Destroy(gameObject);
            }
        }
    }
}
