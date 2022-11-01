using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMuvment : MonoBehaviour
{
    [SerializeField]
    float muvmentSpeed;

    Rigidbody2D rb;
    Vector2 muvment;

    Camera cam;
    Vector2 mus;
    float lookDiraktion;
    HumanAnimation animationControler;

    [HideInInspector]
    public float weaponDiraktion;  
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        animationControler = this.GetComponent<HumanAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        muvment.y = Input.GetAxisRaw("Vertical");
        muvment.x = Input.GetAxisRaw("Horizontal");

        mus = cam.ScreenToWorldPoint(Input.mousePosition);

        animationControler.SpriteDiraktion(lookDiraktion, muvment);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + muvment.normalized * muvmentSpeed * Time.deltaTime);

        Vector2 look = mus - rb.position;
        lookDiraktion = (Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg);
        weaponDiraktion = lookDiraktion;
    }
}
