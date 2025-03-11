using UnityEngine;
public class Player : MonoBehaviour
{
    public Transform ObstacleCheckPosition;
    public float FrontDetectDistance=1.5f;
    public LayerMask IgnoredFrontHitLayers;
    private LevelMainBehavior levelMainBehavior;
    private void Awake()
    {
        levelMainBehavior = LevelMainBehavior.Instance;
    }
    private void Update()
    {
        if(IsWayClear())
        {
            levelMainBehavior.Move=true;
        }
        else 
        {
            levelMainBehavior.Move = false;
        }
    }
    
    private bool IsWayClear()
    {
        return !Physics.Raycast(ObstacleCheckPosition.position, Vector3.right, FrontDetectDistance, IgnoredFrontHitLayers); ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Sea"|| other.transform.tag=="Fail")
        {
            levelMainBehavior.Failed();
        }
        if (other.transform.tag == "ClickCollider")
        {
            Destroy(other);
        }
    }

}
