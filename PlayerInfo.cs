using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	public GameObject player;
	public static int healthLimit = 100;
	int damageCount = 0;
	public static int currentHealth;
	bool playerFighting;
	public GUIText healthbar;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
		currentHealth = healthLimit;
	
	}
	
	// Update is called once per frame
	void Update () {

		//print ("Player in combat? " + playerFighting);
		if (!playerFighting) {
						if (currentHealth < 100) {
								timer = timer + Time.deltaTime;
								if (timer > 1.0f) {
										currentHealth = currentHealth + 1;
										timer = 0.0f;
								}
						}
				}
		if (currentHealth <= 0) 
		{
			player.transform.position = new Vector3 (0, 0, 0);					
			currentHealth = 100;
		}

		healthbar.text = "Health : " + currentHealth + " / 100";
	}

	public void ApplyDamage (int damage) 
	{
				if (!playerFighting)
						damageCount = damageCount + damage;
				else
						damageCount = 0;
				if (damageCount == 10) {
						currentHealth = currentHealth - 1;
						healthbar.text = "Health : " + currentHealth + " / 100";
						damageCount = 0;
				}
		}
	public void PlayerInCombat (int combat)
	{
				if (combat == 1 && HumanAbilities.invisibility == false) {
						playerFighting = true;

				} else {
						playerFighting = false;
				}
		}

}
