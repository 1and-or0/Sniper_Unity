using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;
    private Animator animator;
    private AudioSource univoice;

    // 모션 스테이트의 ID 얻기
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false);

        // 재생 중인 동작이 대기 동작인지 검사
        if(animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol ) 
        {
            animator.SetBool("Motion_Idle", true);
        }
        else
        {
            animator.SetBool("Motion_Idle", false);
        }


        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                //hit는 RaycastHit자료형이므로 GameObject자료형으로 바꿔 가져온다
                GameObject hitObj = hit.collider.gameObject;
                Debug.Log("Hit!");
                if(hitObj.tag == "Head") 
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                }
                else if(hitObj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    univoice.clip = voice2;
                    univoice.Play();
                }
            }
        }
    }
}
