using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

	public Animator animator;
	public GameObject cannonBall;
	public Transform cannonBallPosition;
	public GameObject cannon;
	public ParticleSystem particle;
	public AudioSource audioSource;
	public AudioClip shootClip;
	public AudioClip activateClip;

	private bool activated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	public void OnClick() {
		if (activated) {
			Shoot ();
		} else {
			Activate ();
		}
	}

	void Activate() {
		animator.SetTrigger("activate");
		activated = true;
		audioSource.clip = activateClip;

		audioSource.time = 0.5f;
		audioSource.Play ();
	}

	void Shoot() {
		animator.SetTrigger ("shoot");
		StartCoroutine (ShootCannonBall());
	}

	IEnumerator ShootCannonBall() {
		yield return new WaitForSeconds (0.25f);
		particle.Play ();
		audioSource.clip = shootClip;
		audioSource.Play ();
		GameObject ball = Instantiate (cannonBall, cannonBallPosition.transform);
		Rigidbody rb = ball.GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (0, 15, 15);
	}
}
