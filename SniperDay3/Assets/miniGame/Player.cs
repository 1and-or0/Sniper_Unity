using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpPower = 5;
    TextMesh scoreOutput;
    int score = 0;
    public float lowWarn = -3.8f;
    public float moveSpeed = 0.01f;
    Rigidbody rb;
    public CameraChanger cameraChanger;

    // Start is called before the first frame update
    void Start()
    {   // 이름으로 게임 오브젝트를 찾고, 그 중 TextMesh 컴포넌트를 가져옴 
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>();
        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
            rb.velocity = Vector3.up * jumpPower;

        SetJumpPower();

        if(cameraChanger.cameraMode == "Third")
        {
            if (Input.GetButton("Horizontal"))
            {
                float h = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
        }
        else if(cameraChanger.cameraMode == "First")
        {
            if (Input.GetButton("Vertical"))
            {
                float v = Input.GetAxisRaw("Vertical");
                rb.velocity = new Vector2(rb.velocity.x, v * moveSpeed);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
        }
        

        //transform.localScale += Vector3.up * Time.deltaTime * 0.2f;
        //rb.velocity = new vector3(movespeed, rb.velocity.y, rb.velocity.z);
        //debug.log(rb.velocity);
    }

    void SetJumpPower()
    {
        if (transform.position.y < lowWarn)
        {
            jumpPower = 10;
        }
        else
        {
            jumpPower = 5;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 점수 더하기
    public void addScore(int a)
    {
        Debug.Log("점수 up");
        score += a;
        scoreOutput.text = "점수: " + score;
    }
}
