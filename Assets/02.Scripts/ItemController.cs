using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -3.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, Time.deltaTime * dropSpeed, 0);

        if (transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }
}
