using UnityEngine;
using System.Collections;

public class Warper : MonoBehaviour
{
	public float speed = 60;

	private Targeter targeter;
	private Collider collider;
	private Vector3 warpPosition;
	private bool warping;

	void Awake()
	{
		targeter = GetComponent<Targeter>();
		collider = GetComponent<Collider>();
		if (targeter == null) {
			enabled = false;
			Debug.Log("This component will not work without a Targeter.");
		}
	}

	void Update()
	{
		if (warping) {
			collider.enabled = false;
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, warpPosition, step);
			if (transform.position == warpPosition) warping = false;
		} else {
			collider.enabled = true;
		}

		if (Input.GetKeyDown(KeyCode.LeftShift) && !warping) {
			if (targeter.lastHit.collider.gameObject.GetComponent<WarpTarget>()) {
				warpPosition = targeter.lastHit.collider.transform.position;
				warping = true;
			}
		}
	}
}