using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    GameObject lockedDoor;
    [SerializeField]
    bool remuveKey;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            lockedDoor.GetComponent<Door>().isLock = false;

            if (remuveKey)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
