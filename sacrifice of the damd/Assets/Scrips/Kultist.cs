using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kultist : MonoBehaviour
{
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    List<Transform> walkPoints;
    [SerializeField]
    List<Vector2> walkPath;
    [SerializeField]
    List<float> pause;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
