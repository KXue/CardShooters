using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float m_mouseSensitivity;
	public Vector3 m_cameraOffset;
	private Transform m_cameraTransform;
	// Use this for initialization
	void Start () {
		m_cameraTransform = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        float yRot = Input.GetAxis("Mouse X") * m_mouseSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * m_mouseSensitivity;

        transform.rotation *= Quaternion.Euler(0f, yRot, 0f);
        m_cameraTransform.rotation *= Quaternion.Euler(-xRot, 0f, 0f);

		MoveCamera();
	}

	void MoveCamera(){
		m_cameraTransform.position = transform.position + transform.TransformDirection(m_cameraOffset);
	}
}
