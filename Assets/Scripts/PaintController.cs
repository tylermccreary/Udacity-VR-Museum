using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintController : MonoBehaviour {

	public MaterialController materialController;
	public LayerMask layermask;

	private Renderer renderer;
	private Texture texture;
	private bool painting;
	public Material material;
	private LineRenderer currLine;
	private int count = -1;
	public AudioSource audioSource;
	public AudioClip buttonClick;
	public AudioClip paintClip;


	// Use this for initialization
	void Start () {
//		renderer = gameObject.GetComponent<Renderer> ();
//		texture = renderer.material.mainTexture;
		painting = false;
	}

	// Update is called once per frame
	void Update () {
		if (painting) {
			Ray ray = new Ray ();
			ray.direction = Camera.main.transform.forward;
			ray.origin = Camera.main.transform.position;
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 20.0f, layermask)) {
				if (!audioSource.isPlaying) {
					audioSource.Play ();
				}
				if (audioSource.time > 0.8f) {
					audioSource.time = 0.4f;
					audioSource.Play ();
				}
				currLine.SetVertexCount (count + 1);
				Debug.Log (count);
				Debug.Log (hit.point.x + ", " + hit.point.y + ", " + (hit.point.z + 0.1f));
				currLine.SetPosition (count, new Vector3 (hit.point.x, hit.point.y, hit.point.z + 0.1f));
				count++;
			} else {
				audioSource.Stop ();
				audioSource.time = 0.4f;
			}
		}
	}

	public void PaintOn() {
		Debug.Log ("on");
		count = 0;
		GameObject go = new GameObject ();
		currLine = go.AddComponent<LineRenderer> ();
		currLine.material = material;
		painting = true;
		currLine.startWidth = 0.1f;
		currLine.endWidth = 0.1f;
		audioSource.clip = paintClip;
		audioSource.time = 0.4f;
		audioSource.Play ();
	}

	public void PaintOff() {
		Debug.Log ("off");
		painting = false;
		audioSource.Stop ();
	}

	public void SetMaterial(MaterialController matController, Material material) {
		this.material = material;
		audioSource.clip = buttonClick;
		audioSource.Play ();
		if (materialController != null) {
			materialController.ResetMaterial ();
		}
		materialController = matController;
	}
}
