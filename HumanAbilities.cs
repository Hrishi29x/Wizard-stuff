using UnityEngine;
using System.Collections;

public class HumanAbilities : MonoBehaviour {

	public GameObject player;
	public KeyCode invis = KeyCode.I;
	public KeyCode rock = KeyCode.R;
	public static bool invisibility = false;
	public GUIText notify;
	public GameObject projectileReference;
	public float projectileLifetime;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (invis)) 
		{
			if (invisibility ==  true)
			{
				invisibility = false;
				notify.text = "Invisibility OFF";
			}
			else if (invisibility == false)
			{
				invisibility = true;
				notify.text = "Invisibility ON";
			}
		} 
		else if (Input.GetKey (rock)) 
		{
			notify.text = "Rock Throw";
			RaycastHit hit;
			Vector3 start = this.transform.position;
			Vector3 end = this.transform.position;
			end.x = end.x + 20;
			if(Physics.Linecast(start, end, out hit))
			{
				GameObject g = GameObject.Instantiate(projectileReference) as GameObject;
				g.GetComponent<projectileScript>().direction = (end-start).normalized;
				g.transform.position = transform.position;
				GameObject.Destroy(g, projectileLifetime);
			}
		}
		//CheckInvisibility ();
	
	}
	//public void CheckInvisibility()
	//{
			
}
