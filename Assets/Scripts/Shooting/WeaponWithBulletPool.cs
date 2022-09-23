using UnityEngine;

public class WeaponWithBulletPool : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    private BulletPool bulletPool;

    private void Awake()
    {
        bulletPool = new BulletPool(_bulletPrefab.gameObject);
    }

    public void Shoot()
    {
        var bullet = bulletPool.GetBullet();
        bullet.transform.position = _spawnPoint.position;

        var angle = Mathf.Abs(90 - transform.localEulerAngles.x) * 1/90;
        var direction = angle * Vector3.up + Vector3.forward;
        var force = direction * _bulletSpeed;

        bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}