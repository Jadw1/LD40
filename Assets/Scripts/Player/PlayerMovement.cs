using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float verticalRotationLimit = 45.0f;

    private CharacterController controller;
    private float verticalRotation = 0.0f;

	void Awake () {
        controller = GetComponent<CharacterController>();
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
        float horizontalRotation = FakeControls.GetMouseX();
        transform.Rotate(0.0f, horizontalRotation * rotationSpeed, 0.0f);

		verticalRotation -= FakeControls.GetMouseY();
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation * rotationSpeed, 0.0f, 0.0f);

        Vector3 movement = new Vector3(FakeControls.GetHorizontal(), 0.0f, FakeControls.GetVertical());
        controller.Move(transform.TransformDirection(movement) * Time.deltaTime * speed);
	}
}
