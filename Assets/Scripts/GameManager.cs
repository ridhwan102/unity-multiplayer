using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject menu;

    public bool isPlaying = true;

    void Start(){
        menu = GameObject.Find("Canvas").transform.Find("Webinar").gameObject;
    }

    void Update(){
        if (Input.GetKeyDown("escape")){
            XPauseUnpause();
        }
    }

    public void XPauseUnpause() {
        if(isPlaying){
            menu.SetActive(true);
            isPlaying = false;
        }else{
            menu.SetActive(false);
            isPlaying = true;
        }
    }
}
