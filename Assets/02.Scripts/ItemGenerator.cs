using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 1.0f;
    float delta = 0;
    int ratio = 2;  // ÆøÅºÀÌ ³ª¿Ã È®·ü
    float speed = -3.0f;   // ¶³¾îÁö´Â ¼Óµµ

    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    void Update()
    {
        delta += Time.deltaTime;
        GameObject item;
        if (delta > span)
        {
            delta = 0;
            int randomItem = Random.Range(1, 11);
            if (randomItem <= ratio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }
            int pointX = Random.Range(-1, 2);
            int pointZ = Random.Range(-1, 2);
            item.transform.position = new Vector3(pointX, 4, pointZ);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }    
    }
}
