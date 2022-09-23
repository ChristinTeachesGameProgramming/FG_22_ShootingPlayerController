using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float _speed;
    private bool _isInitialized;

    public void Init(float speed)
    {
        _speed = speed;
        _isInitialized = true;
    }

    private void FixedUpdate()
    {
        if(!_isInitialized)
        {
            return;
        }

        //move bullet forward
    }
}