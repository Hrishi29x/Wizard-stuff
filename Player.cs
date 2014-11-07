using UnityEngine;
using System.Collections;

public class Player : Entity {
	private PlayerPhysics playerPhysics;
	 Camera camera;
	 Vector2 velocity;
	public KeyCode left = KeyCode.A;
	public KeyCode right = KeyCode.D;
	public KeyCode jump = KeyCode.W;
	public Vector2 amountToMove;

	public float gravity = 20;
	public float moveSpeed = 5;
	public float acceleration = 30;
	public float jumpHeight = 12;

	public int floorsTouching = 0;
	public bool grounded;

	// Use this for initialization
	public override void StartingActions () 
	{
		playerPhysics = GetComponent<PlayerPhysics>();
		camera = Camera.main;
	}
	// Update is called once per frame
	public override void UpdateActions () 
	{
		grounded = (floorsTouching > 0);
		CheckPlayerMovement();
	}
	
	void CheckPlayerMovement()
	{
		if (Input.GetKey (right))
		{
			transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));	
		}
		
		else if (Input.GetKey (left))
		{
			transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));	
		}
		if(grounded)
		{
			amountToMove.y = 0;
			if(Input.GetKey(jump))
			{
				amountToMove.y = jumpHeight;
			}
		}
		else{
			amountToMove.y -= gravity * Time.deltaTime;
		}
		playerPhysics.Move(amountToMove * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		floorsTouching++;
	}

	void OnTriggerExit(Collider other){
		floorsTouching--;
	}
}
/*

using UnityEngine;
using System.Collections;


[RequireComponent (typeof(PlayerPhysics))]
public class Player : MonoBehaviour {
	
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30;
	public float jumpHeight = 12;
	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;
	
	
	
	// Use this for initialization
	public void Start () 
	{
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	// Update is called once per frame
	public void Update () 
	{
		CheckPlayerMovement();
	}
	public void CheckPlayerMovement()
	{
		if(playerPhysics.movementStopped)
		{
			targetSpeed = 0;
			currentSpeed = 0;
		}
		if(playerPhysics.grounded)
		{
			amountToMove.y = 0;
			speed = 8;
			if(Input.GetButtonDown("Jump"))
			{
				amountToMove.y = jumpHeight;
			}
		}
		else 
		{
			speed = 4;
		}
		
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);
		
		
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);
		
	}
	
	private float IncrementTowards(float n, float target, float a)
	{
		if(n == target)
		{
			return n;
		}
		else
		{
			float dir = Mathf.Sign(target -n);
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n)) ? n: target;
		}
		
	}
}
*/