using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiButton : MonoBehaviour
{
    public GameObject openTarget, closeTarget;

    public void XOpenTarget(){
        if (closeTarget != null){
            closeTarget.SetActive(false);
        }
        if (openTarget != null){
            openTarget.SetActive(true);
        }
    }
}
