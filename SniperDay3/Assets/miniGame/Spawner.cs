using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab;
    public GameObject dropPrefab;
    public float interval = 1.5f; // 일정 시간마다
    float term;
    public float range = 3;
    // Start is called before the first frame update
    void Start()
    {
        term = interval; // 시작부터 벽이 하나 나오기 위해
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        if (term >= interval)  // 일정 시간이 지나면
        {
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            int wallType = Random.Range(0, wallPrefab.Length);
            Instantiate(wallPrefab[wallType], pos, transform.rotation);
            if(Random.Range(0, 2) == 0)
            {
                Instantiate(dropPrefab, new Vector3 (dropPrefab.transform.position.x + Random.Range(-2, 3),
                    dropPrefab.transform.position.y, dropPrefab.transform.position.z),
                    dropPrefab.transform.rotation);
            }
            
            term -= interval;
        }
    }
}
