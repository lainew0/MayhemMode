using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.25f;
    [SerializeField] private AnimationCurve curveSmooth;
    [SerializeField] private float curveVelocity;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;

        curveVelocity = curveSmooth.Evaluate(Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
