using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
 
 public class ControlAnimation : MonoBehaviour
{
    public Animator anim;       //The Animator we wish to control
    public bool automatic;

    AnimatorStateInfo animationState;
    AnimatorClipInfo[] myAnimatorClip;
    public float animationTime;
    

    public float animationTotalLength = 30;

    public float currentAnimationTime;
	public float currentAnimationRealtime;

    Scrubber scrubber;

    void Start()
    {
        scrubber = GetComponent<Scrubber>();
        animationTime = 0;
        ManualPlay();
    }

    void Update()
    {
        anim.Play("HumanoidWalk", -1, scrubber.value / animationTotalLength);
        animationTime = scrubber.value / animationTotalLength;
    }
    
    public void AutoPlay()
    {
        anim.StopPlayback();
        automatic = true;
        anim.speed = 1f;
        anim.Play("HumanoidWalk");
    }

    public void ManualPlay()
    {
        automatic = false;
        anim.speed = 0;
    }
    
}

