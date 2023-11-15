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
                Debug.Log("¡Has recollit todos els aliments! Gracias.");
            }
            else
            {
                Debug.Log("Necesito mès aliments. Et falten " + (requiredObjectsCount - collectedObjectsCount) + " mès.");
            }
        }
    }

    public void CollectObject(string itemName)
    {
        collectedObjectsCount++;
        Debug.Log("Objeto recollit: " + itemName + ". Total: " + collectedObjectsCount);

        // Puedes agregar lógica adicional aquí según el tipo de objeto
        // Por ejemplo, mostrar mensajes específicos para cada objeto.
    }


}
