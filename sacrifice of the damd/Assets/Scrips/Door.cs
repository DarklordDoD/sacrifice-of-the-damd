using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    string nextScene;
    [SerializeField]
    public bool isLock;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(!isLock)
            {
                //SceneManager.LoadScene(nextScene);
                print("nextScene");
            } else
            {
                print("LockedDoor");
            }   
        }
    }

}
