using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
