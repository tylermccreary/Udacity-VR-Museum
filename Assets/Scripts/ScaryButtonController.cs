using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryButtonController : MonoBehaviour {

	public GameObject monster;
	public GameObject gargoyle;
	public Material interactive;
	public Light directionalLight;
	public AudioSource audioSource;

	private bool scary;
	private Color origColor;
	private Vector3 origRotation;

	void Start() {
		scary = false;
		origColor = interactive.color;
		origRotation = directionalLight.transform.eulerAngles;
	}

	public void Toggle() {
		audioSource.Play ();
		if (scary) {
			MakeNormal ();
		} else {
			MakeScary ();
		}
	}

	private void MakeScary() {
		scary = true;
		monster.SetActive (true);
		gargoyle.SetActive (true);
		interactive.color = new Color (255, 0, 0);
		directionalLight.transform.rotation = Quaternion.Euler (-90, directionalLight.transform.eulerAngles.y, directionalLight.transform.eulerAngles.z);
	}

	private void MakeNormal() {
		scary = false;
		monster.SetActive (false);
		gargoyle.SetActive (false);
		interactive.color = origColor;
		directionalLight.transform.rotation = Quaternion.Euler (origRotation);
	}
}
