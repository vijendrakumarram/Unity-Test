using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controls : NetworkBehaviour {

    public Transform bulletSpawnPosition;
    private float moveSpeed = 3f;
    private float rotateSpeed = 20f;

    [SyncVar]
    private Color mycolor;
    private Material material;

	void Start () {
        material = gameObject.GetComponent<MeshRenderer>().material;
	}
	
	void Update () {
        if (isLocalPlayer) {
            Move();
            HandleColor();
            HandleFire();
        }
        material.color = mycolor;
	}

    private void Move() {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(0f, 0f, z);
        transform.Rotate(0f, x, 0f);
    }

    private void HandleColor() {
        if (Input.GetKeyUp(KeyCode.C)) {
            Color color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            CmdChangeColor(color);
        }
    }

    [Command]
    private void CmdChangeColor(Color color) {
        mycolor = color;
    }

    private void HandleFire() {
        if (Input.GetKeyUp(KeyCode.F)) {
            CmdFire();
        }
    }

    [Command]
    private void CmdFire() {
        GameObject bullet = Instantiate(Resources.Load("bullet"), bulletSpawnPosition.position, bulletSpawnPosition.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6f;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2f);
    }
}
