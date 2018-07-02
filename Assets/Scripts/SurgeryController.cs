using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryController : MonoBehaviour {

	public GameObject camera;
	public LayerMask mask;
	public GameObject topBoundary;
	public GameObject bottomBoundary;
	public Material boundaryMaterial;
	public AudioSource audioSource;
	public AudioClip wrongSound;
	public AudioClip rightSound;
	public Material cubeNormal;
	public Material cubeActive;

	private Vector3 origPosition;
	private bool attached;
	private Renderer topRenderer;
	private Renderer bottomRenderer;
	private Renderer cubeRenderer;

	// Use this for initialization
	void Start () {
		origPosition = transform.position;
		attached = false;
		topRenderer = topBoundary.GetComponent<Renderer> ();
		bottomRenderer = bottomBoundary.GetComponent<Renderer> ();
		cubeRenderer = gameObject.GetComponent<Renderer> ();
		cubeRenderer.material = cubeNormal;
	}
	
	// Update is called once per frame
	void Update () {
		if (attached) {
			Ray ray = new Ray();
			ray.direction = camera.transform.forward;
			ray.origin = camera.transform.position;
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 20f, mask))
			{
				transform.position = new Vector3 (transform.position.x, hit.point.y, hit.point.z);
			}
		}
	}

	public void AttachCube() {
		if (!attached) {
			attached = true;
			cubeRenderer.material = cubeActive;
		}
		Debug.Log ("attached");
	}

	public void ResetCube() {
		cubeRenderer.material = cubeNormal;
		attached = false;
		transform.position = origPosition;
		topRenderer.material = boundaryMaterial;
		bottomRenderer.material = boundaryMaterial;
	}

	public void WrongAnswer() {
		audioSource.clip = wrongSound;
		audioSource.volume = 0.2f;
		audioSource.Play ();
	}

	public void RightAnswer() {
		audioSource.clip = rightSound;
		audioSource.volume = 0.4f;
		audioSource.Play ();
	}
}
