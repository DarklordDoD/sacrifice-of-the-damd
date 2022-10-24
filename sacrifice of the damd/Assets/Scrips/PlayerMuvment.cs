using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuvment : MonoBehaviour
{
    [Header("Muvment")]
    [SerializeField]
    float muvmentSpeed;


    Rigidbody2D rb;
    Vector2 muvment;

    //[Header("Weapon")]
    Camera cam;
    Vector2 mus;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        muvment.y = Input.GetAxisRaw("Vertical");
        muvment.x = Input.GetAxisRaw("Horizontal");

        mus = cam.ScreenToWorldPoint(Input.mousePosition);

        Kniv();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + muvment * muvmentSpeed);

        Vector2 look = mus - rb.position;
        rb.rotation = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
    }

    void Kniv()
    {
        
    }
}
