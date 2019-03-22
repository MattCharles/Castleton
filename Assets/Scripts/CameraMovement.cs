using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform buildingPlatform;
    public Transform shootingPosition;
    public Transform enemyPlatform;
    public bool playerShooting = false;

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
    private Vector3 defaultPosition = new Vector3(10, 3, 0);
    private Vector3 targetPosition = Vector3.zero;

    void Update()
    {
        if (playerShooting)
        {
            //Gracefully move to shooting position
            targetPosition = shootingPosition.position;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            transform.LookAt(enemyPlatform);
            ShootUpdate();
            return;
        }
        //TODO: Let them see where their shot goes. Then, transition the camera to view their
        // fort as the AI shoots at it.
        if(targetPosition == shootingPosition.position)
        {
            targetPosition = defaultPosition;
            transform.position = defaultPosition;
        }
        transform.LookAt(buildingPlatform);
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(buildingPlatform.position, Vector3.up, -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(buildingPlatform.position, Vector3.up, speed);
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
            transform.position = Vector3.SmoothDamp(transform.position, buildingPlatform.position, ref velocity, smoothTime);
        }

        if (scroll < -scrollThreshold)
        {
            if (Vector3.Distance(buildingPlatform.position, transform.position) > distanceThreshold) { return; }
            transform.position -= transform.forward * zoomSpeed * Time.deltaTime;
        }
    }

    void ShootUpdate()
    {

    }
}
