using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Collectable>()) {
			
		}
	}
}
