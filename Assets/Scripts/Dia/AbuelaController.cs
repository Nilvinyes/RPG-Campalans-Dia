using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuelaController : MonoBehaviour
{
    public int requiredObjectsCount = 3;
    private int collectedObjectsCount = 0;
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
            if (collectedObjectsCount == requiredObjectsCount)
            {
                Debug.Log("�Has recollit todos els aliments! Gracias.");
            }
            else
            {
                Debug.Log("Necesito m�s aliments. Et falten " + (requiredObjectsCount - collectedObjectsCount) + " m�s.");
            }
        }
    }

    public void CollectObject(string itemName)
    {
        collectedObjectsCount++;
        Debug.Log("Objeto recollit: " + itemName + ". Total: " + collectedObjectsCount);

        // Puedes agregar l�gica adicional aqu� seg�n el tipo de objeto
        // Por ejemplo, mostrar mensajes espec�ficos para cada objeto.
    }


}
