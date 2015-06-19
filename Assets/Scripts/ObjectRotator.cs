using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour
{
	[System.Serializable]
	public class RotationAxes
	{
		public bool x;
		public bool y;
		public bool z;
	}
	public RotationAxes rotationAxes;
	public float speed = 30f;

	void Update()
	{
		float xRotation = (rotationAxes.x) ? 1 : 0;
		float yRotation = (rotationAxes.y) ? 1 : 0;
		float zRotation = (rotationAxes.z) ? 1 : 0;

		Vector3 rotationVector = new Vector3(xRotation, yRotation, zRotation);

		transform.Rotate(rotationVector * speed * Time.deltaTime);
	}
}