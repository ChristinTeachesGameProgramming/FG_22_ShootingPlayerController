using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PoolOnImpact : MonoBehaviour
{
    private BulletPool _bulletPool;
    private Rigidbody _rigidbody;

    public void Init(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.layer == gameObject.layer)
        {
            return;
        }

        // Debug.Log($"OnCollisionEnter RemoveOnImpact {gameObject.name} X {collision.gameObject.name}");

        _rigidbody.Sleep();
        Invoke("DestroyMe", 0.2f);
    }

    private void DestroyMe()
    {
        _bulletPool.Return(gameObject);
    }
}
