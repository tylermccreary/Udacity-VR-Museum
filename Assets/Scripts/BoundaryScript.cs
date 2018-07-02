using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour {

	public SurgeryController surgeryController;
	public Material boundaryMaterial;
	public Material faultMaterial;

	private Renderer renderer;

	void Start() {
		renderer = gameObject.GetComponent<Renderer> ();
	}

	void OnTriggerEnter(Collider other) {
		renderer.material = faultMaterial;
		surgeryController.WrongAnswer ();
		Invoke("Reset", 1);
	}

	void Reset() {
		renderer.material = boundaryMaterial;
		surgeryController.ResetCube ();
	}
}
