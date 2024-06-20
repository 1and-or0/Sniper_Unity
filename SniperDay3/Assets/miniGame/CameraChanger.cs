using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.SceneView;

public class CameraChanger : MonoBehaviour
{
    public string cameraMode = "Third";
    public Camera camera1;
    public Camera camera3;
    public Spawner spawner;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int timer = 0;
    private void FixedUpdate()
    {
        timer += 1;
        if(timer > 120)
        {
            int flag = Random.Range(1, 4);
            ChangeCamera(flag);
            timer = 0;
        }
        
    }

    void ChangeCamera(int flag)
    {
        if (flag == 1) 
        {
            cameraMode = "First";
        }
        else if(flag == 3) 
        {
            cameraMode = "Third";
        }

        if(cameraMode == "First")
        {
            camera1.gameObject.SetActive(true);
            camera3.gameObject.SetActive(false);
        }
        if(cameraMode == "Third")
        {
            camera1.gameObject.SetActive(false);
            camera3.gameObject.SetActive(true);
        }
    }
}
