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

    
    [Header("Sprite Rotation")]
    [SerializeField]
    GameObject playerSprit;
    [SerializeField]
    Sprite lookOp;
    [SerializeField]
    Sprite LookDown;
    [SerializeField]
    Sprite lookLeft;
    [SerializeField]
    Sprite lookRight;

    Camera cam;
    Vector2 mus;
    float lookDiraktion;
    SpriteRenderer playerSpritSR;

    [Header("Weapon")]
    public float weaponDiraktion;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerSpritSR = playerSprit.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        muvment.y = Input.GetAxisRaw("Vertical");
        muvment.x = Input.GetAxisRaw("Horizontal");

        SpriteDiraktion();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + muvment.normalized * muvmentSpeed * Time.deltaTime);

        Vector2 look = mus - rb.position;
        lookDiraktion = (Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg);
        weaponDiraktion = lookDiraktion;
    }

    void SpriteDiraktion()
    {
        mus = cam.ScreenToWorldPoint(Input.mousePosition);
        //print(lookDiraktion);

        if (45f < lookDiraktion && lookDiraktion < 135f)
        {
            //print("up");
            playerSpritSR.sprite = lookOp;
        }

        if (-45f > lookDiraktion && lookDiraktion > -135f)
        {
            //print("down");
            playerSpritSR.sprite = LookDown;
        }

        if (135f < lookDiraktion || lookDiraktion < -135f)
        {
            //print("left");
            playerSpritSR.sprite = lookLeft;
        }

        if (45f > lookDiraktion && lookDiraktion > -45f)
        {
            //print("right");
            playerSpritSR.sprite = lookRight;
        }
    }
}
