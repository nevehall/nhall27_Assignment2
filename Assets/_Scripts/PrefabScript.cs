using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScript : MonoBehaviour {
	int numObjects = 12;
	public GameObject prefab;
	private GameObject myNewObject;

	// Use this for initialization
	void Start () {
		Vector3 center = transform.position;
		for (int i = 0; i < (numObjects/3); i++) {
			int a = i * 90;
			Vector3 pos = RandomCircle(center, 7.0f ,a);
			myNewObject = Instantiate(prefab, pos, Quaternion.identity);
			myNewObject.GetComponent<Renderer> ().material.color = Color.yellow;
			myNewObject.tag = "Pick Up Yellow";
		}
		for (int i = 0; i < (numObjects/3); i++) {
			int a = i * 90 + 30;
			Vector3 pos = RandomCircle(center, 7.0f ,a);
			myNewObject = Instantiate(prefab, pos, Quaternion.identity);
			Color color = new Color(255/255F, 0/255F, 255/255F,1F);
			myNewObject.GetComponent<Renderer> ().material.color = color;
			myNewObject.tag = "Pick Up Pink";
		}
		for (int i = 0; i < (numObjects/3); i++) {
			int a = i * 90 + 60;
			Vector3 pos = RandomCircle(center, 7.0f ,a);
			myNewObject = Instantiate(prefab, pos, Quaternion.identity);
			Color color = new Color(255/255F,140/255F,0/255F,1F);
			myNewObject.GetComponent<Renderer> ().material.color = color;
			myNewObject.tag = "Pick Up Orange";
		}
	}

	Vector3 RandomCircle(Vector3 center, float radius,int a) {
		Debug.Log(a);
		float ang = a;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		return pos;
	}
}
