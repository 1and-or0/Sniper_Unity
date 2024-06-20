using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public MySpawner spawner;
    Rigidbody rb;
    public float logPushPower = 20;
    public Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawner = GameObject.Find("MySpawner").GetComponent<MySpawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y , -logPushPower);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BackObjFool"))
        {
            gameObject.transform.position = spawner.transform.position;
            gameObject.SetActive(false);
        }
    }
}
