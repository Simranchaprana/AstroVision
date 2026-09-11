using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationHandler : MonoBehaviour
{
    private Animation Anim;
    bool CurrentAnimationState;
    public string AnimationName;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animation>();
        CurrentAnimationState = false;
    }

    private void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.G)) 
        {
            PlayAnimationClip();
        } */
    }

    public void PlayAnimationClip()
    {
        if (CurrentAnimationState == false)
        {
            Anim[AnimationName].speed = 1;
            Anim.Play();
            CurrentAnimationState = true;

        }         
    }

    public void ReverseAnimationClip()
    {
        if (CurrentAnimationState == true)
        {
            Anim[AnimationName].speed = -1;
            Anim[AnimationName].time = Anim[AnimationName].length;
            Anim.Play();
            CurrentAnimationState = false;
        }       
    }
}
