using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField]
    string nextScene;
    public bool isLock;
    [SerializeField]
    GameObject sceneManeger;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(!isLock)
            {
                sceneManeger.GetComponent<SceneManeger>().NextLevel(nextScene);
            } else
            {
                print("LockedDoor");
            }   
        }
    }

}
