using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class playerSpawner : MonoBehaviour
{
    public float minX, maxX, minZ, maxZ;
    public GameObject[] playerPrefabs;
    private GameObject character;

    void Start(){
        int randomChar = Random.Range(0, playerPrefabs.Length);
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 1f,Random.Range(minZ, maxZ));
        character = PhotonNetwork.Instantiate(playerPrefabs[randomChar].name, randomPosition, Quaternion.identity);
    }
}
