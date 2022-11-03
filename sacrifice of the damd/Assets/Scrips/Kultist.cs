using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Kultist : MonoBehaviour
{
    [Header("Muvment")]
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float pointClosness;
    [SerializeField]
    int loopFrom;
    [SerializeField]
    int loopPauseFrom;
    [SerializeField]
    List<Transform> walkPoints;
    [SerializeField]
    List<Vector2> walkPath;
    [SerializeField]
    List<float> pause;

    Rigidbody2D rb;
    int nextPoint = 0;
    float pointDistance;
    int nextPause = 0;
    float pauseEnd;

    float soundTime;
    [SerializeField]
    float soundDelay;

    HumanAnimation animationControler;
    float lookDiraktion;
    Vector2 animetWalk;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < walkPoints.Count; i++)
        {
            if (walkPoints[i] != null)
            {
                if (i < walkPath.Count)
                {    
                    walkPath[i] = walkPoints[i].position;
                }
                else
                {
                    walkPath.Add(walkPoints[i].position);
                }
            }
        }
        walkPath.Add(transform.position);
        pause.Add(0);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DistanceToPoint(transform.position, walkPath[nextPoint]);
        animationControler = this.GetComponent<HumanAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 look = walkPath[nextPoint] - rb.position;
        lookDiraktion = (Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg);

        animationControler.SpriteDiraktion(lookDiraktion, animetWalk);

        PathWalk();
    }

    void PathWalk()
    {
        DistanceToPoint(transform.position, walkPath[nextPoint]);
        if (walkPath.Count - 1 > nextPoint)
        {        
            if (pointDistance < pointClosness)
            {
                nextPoint += 1;
                if (nextPause < pause.Count - 2)
                {
                    nextPause += 1;
                }
                else
                {
                    nextPause = loopPauseFrom;
                }              
                pauseEnd = pause[nextPause];
            } 
            else
            {
                if (pauseEnd > 0f)
                {
                    pauseEnd -= 1 * Time.deltaTime;
                    animetWalk.x = 0;
                }
                else
                {
                    if (soundTime <= 0f)
                    {
                        soundTime = soundDelay;
                        FindObjectOfType<AudioManager>().PlaySound("KultistWalk", true, Random.Range(0.2f, 0.4f), Random.Range(0.8f, 1.2f));
                    }
                    else if (soundTime > 0f)
                    {
                        soundTime -= Time.deltaTime;
                    }
                    
                    rb.position = Vector2.MoveTowards(transform.position, walkPath[nextPoint], walkSpeed * Time.deltaTime);
                    animetWalk.x = 1;
                }
            }

        } else if (loopFrom < walkPath.Count)
        {
            nextPoint = loopFrom;
        } 
        else
        {
            animetWalk.x = 0;
        }
    }

    void DistanceToPoint(Vector2 p1, Vector2 p2)
    {
        pointDistance = Mathf.Sqrt(Mathf.Pow(p1[0] - p2[0], 2) + Mathf.Pow(p1[1] - p2[1], 2));
    }

}
