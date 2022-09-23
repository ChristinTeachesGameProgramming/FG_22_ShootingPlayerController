using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private float _bulletSpeed;

    public Vector3 _force;
    public float _angle;

    public void Shoot()
    {
        var bullet = Instantiate<Rigidbody>(_bullet);
        bullet.transform.position = _spawnPoint.position;
        bullet.gameObject.AddComponent<RemoveOnImpact>();

        // 0 = 100%, 90 = 0%; Assumption: weapon can only rotate 90 degrees
        // 90 - x => 90 = 100%, 0 = 0%
        // 1% = x * 1/90
        _angle = Mathf.Abs(90 - transform.localEulerAngles.x) * 1/90;
        var direction = _angle * Vector3.up + Vector3.forward;
        _force = direction * _bulletSpeed;

        bullet.AddForce(_force, ForceMode.Impulse);
    }
}
