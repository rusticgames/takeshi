using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
	public Vector3 moveToPosition;
	public float speed = 1f;
	public bool loop;

	private Vector3 initialPosition;
	private Vector3 targetPosition;

	void Start ()
	{
		initialPosition = transform.position;
		targetPosition = moveToPosition;
	}

	void Update()
	{
		float step = speed * Time.deltaTime;

		if (transform.position == initialPosition)
			targetPosition = moveToPosition;
		else if (transform.position == moveToPosition && loop)
			targetPosition = initialPosition;

		transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
	}
}
