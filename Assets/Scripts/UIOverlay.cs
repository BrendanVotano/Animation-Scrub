using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOverlay : MonoBehaviour {

    Scrubber scrubber;

    public Text scrubberDirectionText;

	// Use this for initialization
	void Start ()
    {
        scrubber = FindObjectOfType<Scrubber>();
        scrubberDirectionText.text = "Scrubber Direction: " + scrubber.scrubberDirection.ToString();
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
