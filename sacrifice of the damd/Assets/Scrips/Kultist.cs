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
    bool loopWalk;
    [SerializeField]
    List<Transform> walkPoints;
    [SerializeField]
    List<Vector2> walkPath;
    [SerializeField]
    List<float> pause;

    Rigidbody2D rb;
    int nextPoint = 0;
    float pointDistance;
    [SerializeField]
    int nextPause = 0;
    [SerializeField]
    float pauseEnd;

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
            //print(i);
        }
        walkPath.Add(transform.position);
        pause.Add(0);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DistanceToPoint(transform.position, walkPath[nextPoint]);
        //print(walkPath.Count);
    }

    // Update is called once per frame
    void Update()
    {
        PathWalk();
    }

    void PathWalk()
    {
        
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
                    nextPause = 0;
                }              
                pauseEnd = pause[nextPause];
            } 
            else
            {
                if (pauseEnd > 0f)
                {
                    pauseEnd -= 1 * Time.deltaTime;
                }
                else
                {
                    rb.position = Vector2.MoveTowards(transform.position, walkPath[nextPoint], walkSpeed * Time.deltaTime);
                }
            }

        } else if (loopWalk)
        {
            nextPoint = 0;
        }
        DistanceToPoint(transform.position, walkPath[nextPoint]);
    }

    void DistanceToPoint(Vector2 p1, Vector2 p2)
    {
        pointDistance = Mathf.Sqrt(Mathf.Pow(p1[0] - p2[0], 2) + Mathf.Pow(p1[1] - p2[1], 2));
    }

}
