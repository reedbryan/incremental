using UnityEngine;

public class OrbitPlanet : MonoBehaviour
{
    private PlanetID _planetID;
    private float _angle; // current orbit angle in degrees

    public float orbitSpeed = 30f; // degrees per second

    void Start()
    {
        _planetID = GetComponentInParent<PlanetID>();
        if (_planetID == null)
        {
            Debug.LogError("OrbitPlanet: No PlanetID found in parent!");
        }
    }

    void Update()
    {
        if (_planetID == null) return;

        _angle += orbitSpeed * Time.deltaTime;

        float angleRad = _angle * Mathf.Deg2Rad;
        float radius = _planetID.radius * 1.1f;

        Vector3 planetPos = _planetID.transform.position;
        Vector3 offset = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f) * radius;

        transform.position = planetPos + offset;

        // ROTATION: Face tangentially to the orbit path
        float tangentAngle = _angle - 90f; // +90 so it faces along the orbit
        transform.rotation = Quaternion.Euler(0f, 0f, tangentAngle);
    }
}
