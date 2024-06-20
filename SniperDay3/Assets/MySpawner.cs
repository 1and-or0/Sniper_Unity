using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySpawner : MonoBehaviour
{
    public static MySpawner mySpawner;
    public GameObject[] prefabs;

    public List<GameObject> objPool;
    public int amountOfPool = 1;

    float timer = 0;

    private void Awake()
    {
        mySpawner = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        objPool = new List<GameObject>();
        for (int i = 0; i < amountOfPool; ++ i) 
        {
            GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            obj.SetActive(false); objPool.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        float spawnTime = Random.Range(1, 5.5f);
        if (timer > spawnTime)
        {
            timer = 0;
            //Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            SetObj();
        }
    }

    void SetObj()
    {
        GameObject obj = objPool[Random.Range(0, objPool.Count)];
        if(!obj.activeInHierarchy)
        {
            obj.SetActive(true);
        }
    }
}
