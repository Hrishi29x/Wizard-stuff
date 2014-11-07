using UnityEngine;
using System.Collections;

public class projectileScript : MonoBehaviour
{

	public Vector3 direction;

	void Update()
	{
		transform.position += direction * Time.deltaTime;
	}
}
