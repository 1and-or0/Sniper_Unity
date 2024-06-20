using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUI : MonoBehaviour
{
    private LineRenderer lineRenderer = new LineRenderer();
    private Vector3 dragStart = new Vector3();

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // ȭ��ǥ�� �������� ������
        lineRenderer.enabled = false; // �ʱ⿡�� ȭ��ǥ�� ��Ȱ��ȭ
    }

    private void Update()
    {
        if (BallManager.Instance.isTurn)
        {
            // ���콺 ��ư�� ������ �巡�� ����
            if (Input.GetMouseButtonDown(0))
            {
                dragStart = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f)); // z���� �����Ͽ� ȭ��ǥ�� ���̸� ����
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, dragStart);
            }

            // �巡�� ���� �� ȭ��ǥ ������Ʈ
            if (Input.GetMouseButton(0))
            {
                Vector3 dragEnd = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f));
                lineRenderer.SetPosition(1, dragStart - dragEnd + dragStart);
            }

            
        }
        // ���콺 ��ư�� ������ �巡�� ����
        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }
    }
}
