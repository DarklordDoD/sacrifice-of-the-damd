using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAnimation : MonoBehaviour
{

    Animator walkAround;

    void Start()
    {
        walkAround = this.GetComponent<Animator>();
    }

    public void SpriteDiraktion(float lookDiraktion, Vector2 muvment)
    {

        if (muvment.x == 0f && muvment.y == 0f)
        {
            walkAround.SetBool("isMuving", false);
        }
        else
        {
            walkAround.SetBool("isMuving", true);
        }

        if (45f < lookDiraktion && lookDiraktion < 135f)
        {
            walkAround.SetInteger("walkDiraktion", 2);
        }

        if (-45f > lookDiraktion && lookDiraktion > -135f)
        {
            walkAround.SetInteger("walkDiraktion", 0);
        }

        if (135f < lookDiraktion || lookDiraktion < -135f)
        {
            walkAround.SetInteger("walkDiraktion", 1);
        }

        if (45f > lookDiraktion && lookDiraktion > -45f)
        {
            walkAround.SetInteger("walkDiraktion", 3);
        }
    }
}
