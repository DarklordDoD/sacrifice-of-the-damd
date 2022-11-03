using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    [SerializeField]
    float rotationOffset;
    Rigidbody2D rb;
    Transform playerInfo;
    Camera cam;
    [SerializeField]
    float attackForce;
    [SerializeField]
    float attackDelay;
    [SerializeField]
    float returnSpeed;
    [SerializeField]
    float returnDelay;
    [SerializeField]
    int knivDamage;
    public float attackReddy;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerInfo = player.GetComponent<Transform>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        this.GetComponent<Damage>().damage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackReddy >= 0)
        {
            attackReddy -= Time.deltaTime;
        } 
    }

    private void FixedUpdate()
    {

        if (attackReddy <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                FindObjectOfType<AudioManager>().PlaySound("KnivAttack", false, 0f, 0f);

                this.GetComponent<Damage>().damage = knivDamage;
                transform.position = Vector2.MoveTowards(transform.position, cam.ScreenToWorldPoint(Input.mousePosition), attackForce * Time.deltaTime);
                attackReddy = attackDelay;
            }
        }

        if (attackReddy <= returnDelay)
        {
            this.GetComponent<Damage>().damage = 0;
            transform.position = Vector2.MoveTowards(transform.position, playerInfo.position, returnSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.rotation = player.GetComponent<PlayerMuvment>().weaponDiraktion - rotationOffset;
        }
    }

}
