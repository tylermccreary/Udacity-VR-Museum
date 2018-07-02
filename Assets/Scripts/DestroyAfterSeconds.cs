using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 3.0f) {
			Destroy (gameObject);
		}
	}
}
