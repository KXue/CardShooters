using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class MovementController : MonoBehaviour {
	private const float EPSILON = 0.02f;
	public float m_walkSpeed = 5;
	public float m_jumpSpeed = 10;
	public float m_gravityMultiplier = 2;
	public float m_stickToGroundForce = 10;
	bool m_isJumping;
	Vector2 m_inputPlane;
	Vector3 m_worldVelocity;
	bool m_onSlope;

	private CharacterController m_characterController;

	// Use this for initialization
	void Start () {
		m_inputPlane = new Vector2();
		m_worldVelocity = new Vector3();
		m_characterController = GetComponent<CharacterController>();
	}
	void Update(){
		if(!m_isJumping && m_characterController.isGrounded){
			m_isJumping = Input.GetButtonDown("Jump");
		}
	}
	void FixedUpdate () {
		UpdateVelocity();
        m_characterController.Move(m_worldVelocity * Time.fixedDeltaTime);
    }
	void UpdateVelocity(){
		GetInput();
		UpdateXZVelocity();
		UpdateYVelocity();
	}
	void GetInput(){
        m_inputPlane = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if(m_inputPlane.sqrMagnitude > 1){
            m_inputPlane.Normalize();
		}
	}
	void UpdateXZVelocity(){
        Vector3 desiredMove = transform.forward * m_inputPlane.y + transform.right * m_inputPlane.x;

        m_worldVelocity.x = desiredMove.x * m_walkSpeed;
        m_worldVelocity.z = desiredMove.z * m_walkSpeed;

        
	}
	void UpdateYVelocity(){
		if (m_isJumping && m_characterController.isGrounded)
        {
            m_worldVelocity.y = m_jumpSpeed;
            m_isJumping = false;
        }
		else if(m_characterController.isGrounded){
            m_worldVelocity.y = -m_stickToGroundForce;
        }
		else{
			m_worldVelocity += Physics.gravity * m_gravityMultiplier * Time.fixedDeltaTime;
		}
    }
}
