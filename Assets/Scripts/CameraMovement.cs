using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float speed = 2.0f;
    public float verticalSpeed = 13.0f;
    public float zoomSpeed = 20.0f;
    public float smoothTime = .3f;
    public float scrollThreshold = .4f;

    public float positiveCameraBlockHeight = 6f;
    public float negativeCameraBlockHeight = -4f;
    public float absoluteHeightBlock = 15f;

    public float cameraDistanceMax = 20f;
    public float cameraDistanceMin = 5f;

    public float distanceThreshold = 13f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.LookAt(target);
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(target.position, Vector3.up, -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(target.position, Vector3.up, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y < Vector3.one.y * negativeCameraBlockHeight) { return; }
            transform.position -= transform.up * verticalSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if(transform.position.y > Vector3.one.y * positiveCameraBlockHeight) { return; }
            transform.position += transform.up * verticalSpeed * Time.deltaTime;
        }

        if (scroll > scrollThreshold)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        }

        if (scroll < -scrollThreshold)
        {
            if (Vector3.Distance(target.position, transform.position) > distanceThreshold) { return; }
            transform.position -= transform.forward * zoomSpeed * Time.deltaTime;
        }
    }
}
