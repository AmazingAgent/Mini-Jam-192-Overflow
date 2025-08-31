using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] private bool following = false;
    private GameObject followObj;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public bool GetFollowing() { return following; }
    public void SetFollowing(GameObject obj)
    {
        following = true;
        followObj = obj;
        gameObject.GetComponent<PlayerController>().following = true;
        gameObject.GetComponent<PlayerController>().controllable = true;
    }
    public void RemoveFollowing()
    {
        following = false;
        followObj = null;
    }
}
