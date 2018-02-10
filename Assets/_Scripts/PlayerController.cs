using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public Text winText;
	private int count;
	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * 10);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up Yellow")){
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Pick Up Orange")){
			other.gameObject.SetActive (false);
			count = count + 2;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Pick Up Pink")){
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

