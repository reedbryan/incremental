using UnityEngine;

public class PlanetID : MonoBehaviour
{

    public Vector3 position;
    public float radius;

    void Start()
    {
        position = transform.position;
        radius = GetComponent<SpriteRenderer>().bounds.size.y/2;
    }
}
