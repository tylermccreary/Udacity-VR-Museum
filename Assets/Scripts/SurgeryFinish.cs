using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgeryFinish : MonoBehaviour {

	public SurgeryController surgeryController;
	public Material finishMaterial;
	public GameObject topBoundary;
	public GameObject bottomBoundary;

	private Renderer topRenderer;
	private Renderer bottomRenderer;

	void Start() {
		topRenderer = topBoundary.GetComponent<Renderer> ();
		bottomRenderer = bottomBoundary.GetComponent<Renderer> ();
	}

	void OnTriggerEnter(Collider other) {
		topRenderer.material = finishMaterial;
		bottomRenderer.material = finishMaterial;
		surgeryController.RightAnswer ();
		Invoke("Reset", 1);
	}

	void Reset() {
		surgeryController.ResetCube ();
	}
}
