using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 rotation;
    public Vector3 offsetPosition;
    public float smoothFollowTime = 0.3f;
    public float smoothRotationTime = 0.3f;


    public Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 goalPos = target.position + offsetPosition;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothFollowTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotation), smoothRotationTime * Time.deltaTime);

    }
}
