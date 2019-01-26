using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSpawnArea : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 range;
    private Vector3 randomRange;
    private Vector3 randomCoordinate;

    public void Start()
    {
        Vector3 origin = transform.position;
        Vector3 range = transform.localScale / 2.0f;
    }

    public void Update()
    {
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x),
                                          Random.Range(-range.y, range.y),
                                          Random.Range(-range.z, range.z));
        Vector3 randomCoordinate = randomRange;
        print(randomRange);
    }

    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    public Color DotColor = new Color(0.1f, 0.1f, 0.1f, 1f);

    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
        Gizmos.color = DotColor;
        Gizmos.DrawWireSphere(randomCoordinate, 1f);
    }
}
