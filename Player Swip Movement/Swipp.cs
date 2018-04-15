using UnityEngine;
using System.Collections;

public class Swipp : MonoBehaviour {

	public Swip swipeControls;
	public Transform Player;
	private Vector3 desiredPosition;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (swipeControls.SwipLeft)
			desiredPosition += Vector3.left;
		if (swipeControls.SwipRight)
			desiredPosition += Vector3.right;
		if (swipeControls.SwipUp)
			desiredPosition += Vector3.forward;
		if (swipeControls.SwipDown)
			desiredPosition += Vector3.back;
	
Player.transform.position = Vector3.MoveTowards (Player.transform.position, desiredPosition, 3f * Time.deltaTime);

	}
}
