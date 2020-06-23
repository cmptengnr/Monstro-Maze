using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void quitbutton() {
        Debug.Log ("has quit game");
        Application.Quit();
    }
}
