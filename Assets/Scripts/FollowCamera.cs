using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] [Range(5,10)] private float smoothness;
    [SerializeField] private Transform targetObject;

    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    void Start()
    {  
        initalOffset = transform.position - targetObject.position;
    }

    void FixedUpdate()
    {
        cameraPosition = targetObject.position + initalOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness*Time.fixedDeltaTime);
    }
}