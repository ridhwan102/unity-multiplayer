using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public GameObject LoadingScreen;
    string RoomName;

    public void XXCustomJoin(string input){
        LoadingScreen.SetActive(true);
        RoomName = input;
        // Debug.Log("Starting connection...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        // Debug.Log("Connected");
        if (RoomName != null ){
            // Debug.Log("Creating Or Joining room...");
            PhotonNetwork.JoinOrCreateRoom(RoomName, null, null);
        }
    }

    public override void OnJoinedRoom(){
        // Debug.Log("loading room...");
        PhotonNetwork.LoadLevel(RoomName);
    }

    public override void OnCreatedRoom(){
        // Debug.Log("Room Created");
    }
}
