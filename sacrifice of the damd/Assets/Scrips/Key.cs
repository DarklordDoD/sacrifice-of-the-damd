using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    GameObject lockedDoor;
    [SerializeField]
    bool remuveKey;
    Animator aabenDoor;

    void Start()
    {
        aabenDoor = this.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            lockedDoor.GetComponent<Door>().isLock = false;
            aabenDoor.SetBool("Aktiv", true);

            if (remuveKey)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
