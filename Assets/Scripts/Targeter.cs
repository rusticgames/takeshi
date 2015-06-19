using UnityEngine;
using System.Collections;

public class Targeter : MonoBehaviour
{
	public GameObject cursorPrefab;

	private GameObject cursor;
	private Renderer[] renderers;

	void Start()
	{
		cursor = GameObject.Instantiate(cursorPrefab, transform.position, Quaternion.identity) as GameObject;
		renderers = cursor.GetComponentsInChildren<Renderer>();
	}

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, Mathf.Infinity));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
			Debug.DrawLine(ray.origin, hit.point);

		if (hit.collider != null) {
			cursor.transform.position = hit.point;
			cursor.transform.forward = hit.normal;
			foreach (Renderer r in renderers)
				r.enabled = true;
		} else {
			foreach (Renderer r in renderers)
				r.enabled = false;
		}
	}
}
