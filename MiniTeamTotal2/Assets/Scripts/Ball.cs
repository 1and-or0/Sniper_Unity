using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float power = 20.0f;
    private bool isDragging = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Collider _collider;
    private float ignoreTime = 3f;
    private float timer = 0f;
    void Start()
    {
        _collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (BallManager.Instance.isTurn && timer >= ignoreTime)
        {
            // �巡�� ����
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == this.gameObject)
                {
                    isDragging = true;
                    startPosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
                }
            }

            // �����
            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                endPosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
                LaunchBall();
                isDragging = false;
                BallManager.Instance.isTurn = false;
            }
        }
        else
        {
            Debug.Log(gameObject.name + "���� ��: ���� �����̰� �־��!");
        }

    }

    void LaunchBall()
    {
        Vector3 direction = startPosition - endPosition;
        Debug.Log(direction);
        rb.AddForce(direction * power * Time.deltaTime, ForceMode.Impulse);
    }
}
