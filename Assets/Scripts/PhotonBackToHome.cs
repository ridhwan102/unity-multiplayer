using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonBackToHome : MonoBehaviourPunCallbacks
{
    public void XXBackToMainmenu(){
        // Debug.Log("Leaving Room..");
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom(){
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Start Menu");
    }
}
