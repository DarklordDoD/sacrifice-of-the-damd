using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    [SerializeField]
    bool playerWeapon;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player" && !playerWeapon)
        {
            collision.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !playerWeapon)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        } 
        
        if (collision.gameObject.tag == "Enemy" && playerWeapon)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

}
