using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();   
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ãæµ¹ with : " + other.gameObject.name);
        if(other.gameObject.name == "Player")
            other.gameObject.SetActive(false);
    }
}
