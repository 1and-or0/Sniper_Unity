using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHighSet : MonoBehaviour
{
    Vector3 startPos = new Vector3();

    void Awake()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // ���� ���� ���� �ö󰡴� ���� ����
        if (transform.position.y > startPos.y)
        {
            transform.position = startPos;
        }
    }
}
