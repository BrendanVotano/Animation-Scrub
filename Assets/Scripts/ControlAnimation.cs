using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
 
 public class ControlAnimation : MonoBehaviour
{
    Scrubber scrubber;
    [HideInInspector]
    public float animationTime;        //The current time of this animation
    [HideInInspector]
    public float animationTotalLength; //The total length of this animation
    [HideInInspector]
    public List<AnimationClip> allAnimations = new List<AnimationClip>();
    [HideInInspector]
    public string currentAnimationName;

    public Animator anim;       //The Animator we wish to control
    [Range(1, 5)]
    public int loopCount = 1;   //The amount of loops we want this animation to play
    public bool automatic;      //TODO for auto play
    
    void Start()
    {
        scrubber = GetComponent<Scrubber>();
        animationTime = 0;
        ManualPlay();
        foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
        {
            allAnimations.Add(clip);
        }
        currentAnimationName = allAnimations[0].name;
        scrubber.UpdateMaxAnimTime(allAnimations[0].length);
    }

    void Update()
    {
        //anim.Play("AnimationName", -1, scrubber.value / animationTotalLength);    //We can just use the animation name for a single specific animation
        anim.Play(currentAnimationName, -1, scrubber.value / animationTotalLength);
        animationTime = scrubber.value / animationTotalLength;
    }

    public void UpdateAnimationTime(string newName)
    {
        currentAnimationName = newName;
        foreach (AnimationClip clip in allAnimations)
        {
            if (clip.name == currentAnimationName)
            {
                animationTotalLength = clip.length;
                scrubber.UpdateMaxAnimTime(animationTotalLength);
            }
        }
    }
    
    //TODO
    public void AutoPlay()
    {
        anim.StopPlayback();
        automatic = true;
        anim.speed = 1f;
        anim.Play(currentAnimationName);
    }
    //TODO
    public void ManualPlay()
    {
        automatic = false;
        anim.speed = 0;
    }
    
}

