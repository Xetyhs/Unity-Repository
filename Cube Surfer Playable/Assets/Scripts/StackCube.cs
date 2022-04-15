using UnityEngine;



public class StackCube : MonoBehaviour
{
    private bool _isCollected = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool IsAttachPlayer(GameObject other)
    {
        return other.transform.parent == StackManager.Instance.GetContainer();
               
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        var otherTransform = other.gameObject.transform;

        if (!other.CompareTag("Block Cube"))
            return;


        
        
        float heightDecrease = 0f;
        if (otherTransform.childCount != 0)
        {
            for (int i = 0; i < otherTransform.childCount; i++)
            {
                StackManager.Instance.RemoveCube(otherTransform.GetChild(i));
                heightDecrease += Utils.GetColliderHeight(otherTransform.GetComponent<Collider>());
            }
            Player.Instance.DecreaseHeight(heightDecrease);
            return;
        }
        
        heightDecrease = Utils.GetColliderHeight(otherTransform.GetComponent<Collider>());
        
        StackManager.Instance.RemoveCube(other.transform);
        
        Player.Instance.DecreaseHeight(heightDecrease);
        
        
        */

    }
}
