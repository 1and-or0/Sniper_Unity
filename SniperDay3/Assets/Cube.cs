using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MySpawner spawner;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("MySpawner").GetComponent<MySpawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.back * moveSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BackObjFool"))
        {
            gameObject.transform.position = spawner.transform.position;
            gameObject.SetActive(false);
        }
    }
}
