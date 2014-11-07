using UnityEngine;
using System.Collections;

public class en3Brains : MonoBehaviour {
	
	float targetDelay = 0;
	public float targetDelayLimit;//time between attempts to shoot at the player
	public float projectileLifetime;

	public GameObject projectileReference;
	public Transform playerReference;


	void Start ()
	{

	}

	void Update ()
	{
		targetDelay += Time.deltaTime;
		if(targetDelay > targetDelayLimit)
		{
			targetDelay = 0;

			Vector3 start = this.transform.position;
			Vector3 end = playerReference.position;
			RaycastHit hit;

			if(Physics.Linecast(start, end, out hit))
			{
				if(hit.transform == playerReference && HumanAbilities.invisibility == false)
				{
					GameObject g = GameObject.Instantiate(projectileReference) as GameObject;
					g.GetComponent<projectileScript>().direction = (end-start).normalized;
					g.transform.position = transform.position;
					GameObject.Destroy(g, projectileLifetime);
				}
			}
		}
	}
}
