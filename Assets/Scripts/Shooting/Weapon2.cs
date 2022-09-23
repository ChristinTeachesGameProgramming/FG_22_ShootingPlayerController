using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _speed;

    public void Shoot() 
    {
        var bullet = Instantiate<Rigidbody>(_bulletPrefab, _spawnPoint.position, Quaternion.identity);

        var angle = Mathf.Abs(90 - transform.localEulerAngles.x) * 1/90;
        var direction = Vector3.up * angle + Vector3.forward;
        bullet.AddForce(direction * _speed, ForceMode.Impulse);
    }
}
