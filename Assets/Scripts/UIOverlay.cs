using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOverlay : MonoBehaviour {

    Scrubber scrubber;
    ControlAnimation controlAnimation;

    public Text scrubberDirectionText;
    public Text animationTimeText;
    public Slider horizontalSlider;
    public Slider verticalSlider;
    public Dropdown dropdown;
    public Dropdown loopCount;

    // Use this for initialization
    void Start ()
    {
        controlAnimation = FindObjectOfType<ControlAnimation>();
        scrubber = FindObjectOfType<Scrubber>();
        scrubberDirectionText.text = "Scrubber Direction: " + scrubber.scrubberDirection.ToString();
        StartCoroutine(SetDropdown());
	}

    //Sets the dropdown menu with all our animation names
    IEnumerator SetDropdown()
    {
        yield return new WaitForEndOfFrame();
        List<string> animationNames = new List<string>();
        foreach (AnimationClip clip in controlAnimation.allAnimations)
        {
            animationNames.Add(clip.name);
        }
        dropdown.AddOptions(animationNames);
    }

    //Changes the animation name to be that of the dropdown menu item
    public void ChangeAnimation()
    {
        int dropdownValue = dropdown.value;
        int loopValue = loopCount.value;
        //controlAnimation.currentAnimationName = dropdown.options[dropdownValue].text;
        controlAnimation.UpdateAnimationTime(dropdown.options[dropdownValue].text, loopCount.value + 1);
    }
    

    void Update()
    {
        if (scrubber.scrubberDirection == ScrubberDirection.HORIZONTAL)
            horizontalSlider.value = scrubber.normalizedValue;
        else
            verticalSlider.value = scrubber.normalizedValue;

        animationTimeText.text = "Animation Time: " + scrubber.value.ToString("F2") + " / " + scrubber.maxAnimTime.ToString("F2");
    }

    //Changes our scrubber to horizontal orientation
    public void ChangeScrubberHorizontal()
    {
        scrubber.scrubberDirection = ScrubberDirection.HORIZONTAL;
        scrubberDirectionText.text = "Scrubber Direction: " + scrubber.scrubberDirection.ToString();
    }

    //Changes our scrubber to vertical orientation
    public void ChangeScrubberVertical()
    {
        scrubber.scrubberDirection = ScrubberDirection.VERTICAL;
        scrubberDirectionText.text = "Scrubber Direction: " + scrubber.scrubberDirection.ToString();
    }
}
