using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    GameObject gameManager;
    AudioSource audioSource;
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.GetComponent<GameManager>().score += 1;
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("gameManager가 없어요");
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }
}
