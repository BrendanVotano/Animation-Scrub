using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrubberDirection
{
    HORIZONTAL,
    VERTICAL
}
public class Scrubber : MonoBehaviour
{
    #region private variables
    Vector3 mousePos;
	Vector3 deltaMousePos;
	Vector3 prevMousePos;
	Vector3 dragDist;
	Vector3 dragInertia;
	bool isDrag = false;
	bool isPress = false;
    bool fingerDown = false;
	float min = 0f;
	float maxVel = 0.1f;                 //The min velocity of the mouse drag
	float minVel = -0.1f;                //The max velocity of the mouse drag
    #endregion

    public ScrubberDirection scrubberDirection; //The screen direction we want to scrub
    public float max = 100f;            //The length of the animation
    public float sensitivity = 0.01f;   //How sensitive the movement is
	public float friction = 1.06f;      //The amount of slide 
    [HideInInspector]
    public float value;                 //The time of the animation
    [HideInInspector]
    public float normalizedValue;       //The normalized value of value

    void Update ()
    {
        mousePos = Input.mousePosition; //Gets our mouse input

		if (Input.GetMouseButton(0) && Input.touchCount <= 1)
        { // On Mouse Down
            if (!isPress)
            { // On Starting Press, prevents initial value jumping
                if (mousePos != prevMousePos)
                {
                    isPress = true;
                }
                prevMousePos = mousePos;
            }
            deltaMousePos = mousePos - prevMousePos;


            isDrag = false;
            if (deltaMousePos != Vector3.zero)
            { // is Dragging
                isDrag = true;

                dragDist = new Vector3(0, deltaMousePos.y * sensitivity, 0);

                // switch between horizontal and vertical drag
                if (Mathf.Abs (deltaMousePos.y) > Mathf.Abs (deltaMousePos.x)) {
					dragDist = new Vector3(0, deltaMousePos.y * sensitivity, 0);
				} else {
					dragDist = new Vector3(deltaMousePos.x * sensitivity, 0 , 0);
				}
				//dragDist = new Vector3(deltaMousePos.x * rotateSensitivity, deltaMousePos.y * sensitivity, 0);
				if (dragDist.y != 0 || dragDist.x != 0)
                {
                    dragInertia = dragDist;
                }
            }
            prevMousePos = mousePos;
        }
        else
        {
            isPress = false;
        }

        fingerDown = isPress;

        //Splitting into horizontal and vertical options. Could be slightly optimised
        if (scrubberDirection == ScrubberDirection.HORIZONTAL)
        {
            dragInertia = new Vector3(dragInertia.x / friction, 0, 0); // Apply friction to slow down movement
            if (isDrag)
            {
                value += Mathf.Clamp(dragInertia.x, minVel, maxVel);
                value = Mathf.Clamp(value, min, max);
                float range = max - min;
                normalizedValue = (value - min) / range;
            }
        }
        else
        {
            dragInertia = new Vector3(0, dragInertia.y / friction, 0); // Apply friction to slow down movement
            if (isDrag)
            {
                value += Mathf.Clamp(dragInertia.y, minVel, maxVel);
                value = Mathf.Clamp(value, min, max);
                float range = max - min;
                normalizedValue = (value - min) / range;
            }
        }
	}

}
