using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SlabMovement : NetworkBehaviour {

    private float speed = 0.5f;
    private Vector3 targetPosition;
    private bool canMove = false;
    private void Start() {
        targetPosition = new Vector3(5f, transform.position.y, transform.position.z);
    }

    private void OnMouseOver() {
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            canMove = true; 
        } 
    }

    private void Update() {
        if (canMove) {
            CmdMove();
        }  
    }

    [Command]
    private void CmdMove() {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }

}
