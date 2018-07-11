using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOverlay : MonoBehaviour {

    Scrubber scrubber;

    public Text scrubberDirectionText;
    public Text animationTimeText;
    public Slider horizontalSlider;
    public Slider verticalSlider;

    // Use this for initialization
    void Start ()
    {
        scrubber = FindObjectOfType<Scrubber>();
        scrubberDirectionText.text = "Scrubber Direction: " + scrubber.scrubberDirection.ToString();
	}

    void Update()
    {
        if (scrubber.scrubberDirection == ScrubberDirection.HORIZONTAL)
            horizontalSlider.value = scrubber.normalizedValue;
        else
            verticalSlider.value = scrubber.normalizedValue;

        animationTimeText.text = "Animation Time: " + scrubber.value.ToString("F2");
    }

    public void ChangeScrubberHorizontal()
    {
        scrubber.scrubberDirection = ScrubberDirection.HORIZONTAL;
        scrubberDirectionText.text = "Scrubber Direction: " + scrubber.scrubberDirection.ToString();
    }
    public void ChangeScrubberVertical()
    {
        scrubber.scrubberDirection = ScrubberDirection.VERTICAL;
        scrubberDirectionText.text = "Scrubber Direction: " + scrubber.scrubberDirection.ToString();
    }
}
