using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource jumpAudioSource;
    public MyPlayer myPlayer;
    Animator myPlayerAnim;
    // Start is called before the first frame update
    void Start()
    {
        myPlayerAnim = myPlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myPlayerAnim.GetBool("isJumping"))
        {
            jumpAudioSource.Play();
        }
    }
}
