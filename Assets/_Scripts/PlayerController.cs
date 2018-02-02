using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed; 
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText();
		winText.text = ""; //text property starts empty
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up Yellow")){
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}

		else if (other.gameObject.CompareTag ("Pick Up Orange")){
			other.gameObject.SetActive (false);
			count = count + 2;
			SetCountText ();
		}

		else if (other.gameObject.CompareTag ("Pick Up Pink")){
			other.gameObject.SetActive (false);
			count = count + 5;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Score: " + count.ToString ();
		if (count >= 32) {
			winText.text = "You Win!";
		}
	}
}

//2.a) Two ways to design the pickups would be either to create them all individually or 
//create them using a prefab which acts as a blueprint and applies to each pickup object of 
//the same type. Evidentely, using the prefab method is more efficient.