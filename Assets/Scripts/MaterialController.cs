using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour {

	public PaintController paintController;
	public Material mainMaterial;
	public Material outlinedMaterial;

	private Renderer renderer;

	void Start() {
		renderer = gameObject.GetComponent<Renderer> ();
	}

	public void ResetMaterial() {
		renderer.material = mainMaterial;
	}

	public void SetMaterial() {
		paintController.SetMaterial (this, mainMaterial);
		renderer.material = outlinedMaterial;
	}
}
