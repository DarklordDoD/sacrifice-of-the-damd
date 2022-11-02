using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    string nextScene;
    public bool isLock;
    [SerializeField]
    GameObject sceneManeger;
    [SerializeField]
    bool close;
    Animator aabenDoor;

    void Start()
    {
        aabenDoor = this.GetComponent<Animator>();
        if (close)
        {
            aabenDoor.SetBool("Close", true);
        }
    }

    void Update()
    {
        if (!isLock)
        {
            aabenDoor.SetBool("Aaben", true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(!isLock)
            {
                sceneManeger.GetComponent<SceneManeger>().NextLevel(nextScene);
            }  
        }
    }

}
