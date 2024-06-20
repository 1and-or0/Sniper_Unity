using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static GameObject gmInstance;
    public static GameObject canvasInstance;
    private int gmCount;
    private int canvasCount;
    

    private void Start()
    {
        Debug.Log(this.gameObject.name);
        DontDestroyOnLoad(this.gameObject);

        gmCount = GameObject.FindGameObjectsWithTag("GameManager").Length;
        canvasCount = GameObject.FindGameObjectsWithTag("Canvas").Length;

        while (gmCount > 2)
        {
            Debug.Log("ÆÄ±« °ÔÀÓ ¸Þ´ÏÀú");
            // Destroy(GameObject.FindGameObjectsWithTag("GameManager")[gmCount - 1]);
        }
        while (canvasCount > 2)
        {
            Debug.Log("ÆÄ±« Äµ¹ö½º");
            // Destroy(GameObject.FindGameObjectsWithTag("Canvas")[canvasCount - 1]);
        }
        if(gmCount == 2)
        {
            // Destroy(GameObject.FindGameObjectsWithTag("GameManager")[gmCount - 1]);
        }
        if(canvasCount == 2)
        {
            // Destroy(GameObject.FindGameObjectsWithTag("Canvas")[gmCount - 1]);
        }
        if (gmCount == 1)
        {
            gmInstance = GameObject.FindGameObjectWithTag("GameManager");
            DontDestroyOnLoad(gmInstance);
        }
        if (canvasCount == 1)
        {
            canvasInstance = GameObject.FindGameObjectWithTag("Canvas");    
            DontDestroyOnLoad(canvasInstance);
        }

    }

    private void Update()
    {
        gmCount = GameObject.FindGameObjectsWithTag("GameManager").Length;
        canvasCount = GameObject.FindGameObjectsWithTag("Canvas").Length;
    }
}
