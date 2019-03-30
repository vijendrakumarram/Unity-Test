using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UIManager : NetworkBehaviour {

    public Button clickButton;

    [SyncVar]
    Color updatedColor;

	void Start () {
        updatedColor = Color.green;
        clickButton.onClick.AddListener(ButtonClick);
	}

    private void ButtonClick() {
        CmdButtonUI();
    }

    [Command]
    private void CmdButtonUI() {
      
    }
}
