using UnityEngine;
using System.Collections;

public class Swip : MonoBehaviour 

    {
	private bool tap,swipLeft,swipRight,swipUp,swipDown;
	private bool isDraging = false;
	private Vector3 startTouch, swipDelta;


	private void Update()
	{
		tap = swipLeft = swipRight = swipUp = swipDown = false;

		#region Standalone Inputs
		if(Input.GetMouseButtonDown(0))
		{
			isDraging = true;
			tap = true;
			startTouch = Input.mousePosition;
		}
		else if(Input.GetMouseButtonUp(0))
		{
			isDraging = false;
			Reset();
		
		}
		#endregion

#region Mobile Inputs

		if(Input.touches.Length > 0)
		{
			if(Input.touches[0].phase == TouchPhase.Began)
			{
				tap= true;
				isDraging = true;
				startTouch = Input.touches[0].position;
			}
			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				isDraging = false;
				Reset();
			}
		}

#endregion

		//calculate the distance 

		swipDelta = Vector3.zero;
		if(isDraging)
		{
			if(Input.touches.Length >0)
			
				swipDelta = (Vector3)Input.touches[0].position - startTouch;
				else if(Input.GetMouseButton(0))
				swipDelta = (Vector3)Input.mousePosition - startTouch;
		}

		// Dis we Cross The deadZone
		if(swipDelta.magnitude > 125)
		{
			//Which Direction 
			float x = swipDelta.x;
			float y = swipDelta.y;
			if(Mathf.Abs(x) > Mathf.Abs(y))
			{
				//Left or Right
				if(x < 0)
					swipLeft = true;
				else
					swipRight = true;
			}
			else
			{
				// up or Down1
				if(x < 0)
					swipDown = true;
				else
					swipUp = true;
			}
			Reset();
		}

	}
	private void Reset()
	{
		startTouch = swipDelta = Vector3.zero;
		isDraging = false;
	}
	public Vector3 SwipDelta{get{return swipDelta;}}
	public bool SwipLeft{get{return swipLeft;}}
	public bool SwipRight{get{return swipRight;}}
	public bool SwipUp{get{return swipUp;}}
	public bool SwipDown{get{return swipDown;}}

}

