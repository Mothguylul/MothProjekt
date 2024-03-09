using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    private float minZoom = 3f, maxZoom = 10f;
    private float velocity = 0f, smoothTime = 0.25f;
    [SerializeField] private float zoom, zoomMultiplier;
    private Camera cam;

    void Start()
    {
       cam = FindAnyObjectByType<Camera>();
        zoom = cam.orthographicSize;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }
}
