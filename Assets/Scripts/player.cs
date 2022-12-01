using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class player : MonoBehaviour
{
    private float moveSpeed = 2f, mouseSensitivity = 90f;
    private TextMeshPro nameText;
    private CharacterController controller;
    private float xRotation, gravity;
    private Camera mainCamera;
    private PhotonView view;
    
    void Start(){
        controller = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
        mainCamera = transform.Find("Main Camera").GetComponent<Camera>();
        nameText = transform.Find("Text (TMP)").GetComponent<TextMeshPro>();
        nameText.text = "Player " + view.CreatorActorNr;

        if (view.IsMine){
            mainCamera.gameObject.tag = "MainCamera";
            mainCamera.gameObject.SetActive(true);
            nameText.gameObject.SetActive(false);
        }
    }

    void Update(){
        if (view.IsMine){
            gravity -= 9.81f * Time.deltaTime;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;        
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 70f);
            mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

            // movement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x  + transform.forward * z + transform.up * gravity;
            controller.Move(move * moveSpeed * Time.deltaTime);
            if(controller.isGrounded) gravity = 0;
        }
    }
}
