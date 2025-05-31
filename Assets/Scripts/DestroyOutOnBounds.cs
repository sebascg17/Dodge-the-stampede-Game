using UnityEngine;

public class DestroyOutOnBounds : MonoBehaviour
{
    private float topBound = 25;
    private float lowerBound = -15;
    private float sideBound = 40;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > sideBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound)
        {
            Destroy(gameObject);
        }
    }
}
