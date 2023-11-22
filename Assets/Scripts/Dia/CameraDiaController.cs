using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDiaController : MonoBehaviour
{
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        target = playerController.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicioPlayer = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = posicioPlayer;
    }
}
