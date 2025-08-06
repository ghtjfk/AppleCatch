using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text pointText;
    float time = 30.0f;
    int totalPoint = 0;

    public GameObject itemGenerator;

    public void PlusPoint()
    {
        totalPoint += 100;
    }

    public void MinusPoint()
    {
        totalPoint /= 2;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            itemGenerator.GetComponent<ItemGenerator>().SetParameter(10000000.0f, 0, 0);
        }
        if (0 < time && time <= 5f)
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParameter(0.7f, -4.0f, 3);
        }
        if (5f <= time && time <= 12f)
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParameter(0.5f, -5.0f, 6);
        }
        if (12f <= time && time <= 23f)
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParameter(0.8f, -4.0f, 4);
        }
        if (23f <= time && time <= 30f)
        {
            itemGenerator.GetComponent<ItemGenerator>().SetParameter(1.0f, -3.0f, 2);
        }

        timerText.text = time.ToString();
        pointText.text = totalPoint.ToString();
    }
}
