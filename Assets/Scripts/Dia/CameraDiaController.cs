using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDiaController : MonoBehaviour
{
    [SerializeField]
    Transform targetbird;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetbird.position.x, //La camera es igual a la posicó del ocell
                                         targetbird.position.y,
                                         transform.position.z);
    }
}
