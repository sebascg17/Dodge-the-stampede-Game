using UnityEngine;

public class DestroyBallVertical : MonoBehaviour
{
    private float LowerBound = -2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.y < LowerBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
