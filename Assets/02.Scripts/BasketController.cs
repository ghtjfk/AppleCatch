using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    public GameObject gameManager;

    void Start()
    {
        aud = GetComponent<AudioSource>();   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;     // �浹�� ���� ���� ������ ��� ����ü

            // out => ������, hit�� ���� ������ out�ض�.   Math.Infinity�� ���� �浹�� ������ ������ ������ ��.
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);

                transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tag_apple"))
        {
            Destroy(other.gameObject);
            aud.PlayOneShot(appleSE);
            gameManager.GetComponent<GameManager>().PlusPoint();
        }

        if (other.CompareTag("tag_bomb"))
        {
            Destroy(other.gameObject);
            aud.PlayOneShot(bombSE);
            gameManager.GetComponent<GameManager>().MinusPoint();
        }
    }
}
