using UnityEngine;
using System.Collections;

public class Warper : MonoBehaviour
{
	public float speed;

	private Targeter targeter;
	private Collider collider;

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
		if (Input.GetKey(KeyCode.LeftShift)) {
			if (targeter.lastHit.collider.gameObject.GetComponent<WarpTarget>()) {
				collider.enabled = false;
				float step = speed * Time.deltaTime;
				Vector3 warpTarget = targeter.lastHit.collider.transform.position;
				transform.position = Vector3.MoveTowards(transform.position, warpTarget, step);
			}
		} else {
			collider.enabled = true;
		}
	}
}
