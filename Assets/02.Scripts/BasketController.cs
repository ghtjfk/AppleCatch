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
            RaycastHit hit;     // 충돌한 곳에 대한 정보를 담는 구조체

            // out => 빼내라, hit한 곳의 정보를 out해라.   Math.Infinity를 통해 충돌할 때까지 무한히 광선을 쏨.
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
