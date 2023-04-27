using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public GameObject ropeTop;
    public GameObject ropeBottom;
    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, ropeBottom.transform.position);
        lineRenderer.SetPosition(1, ropeTop.transform.position);
    }
}
