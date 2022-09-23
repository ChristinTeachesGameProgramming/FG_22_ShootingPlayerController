using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenProjectiles;

    public void Shoot() 
    {
        float timeOfImpact = ShootRay();

        AddProjectiles(3, timeOfImpact);
    }

    private IEnumerator AddProjectiles(int number, float timeOfImpact)
    {
        for (int i = 0; i < number; i++)
        {
            var projectile = Instantiate<GameObject>(_projectilePrefab, _spawnPoint.position, Quaternion.identity);
            projectile.name = $"p{i}";

            var movement = projectile.AddComponent<ProjectileMovement>();
            movement.Init(_speed);

            var removeAfterTime = projectile.AddComponent<RemoveAfterTime>();
            removeAfterTime.Init(timeOfImpact - i * _timeBetweenProjectiles);

            AudioPlayer.Instance.Play("Gunshot");

            yield return new WaitForSeconds(_timeBetweenProjectiles);
        }
    }

    private float ShootRay()
    {
        var timeOfImpact = 3f;

        //Raycast, based on _speed, calculate impact time

        return timeOfImpact;
    }
}

public class AudioPlayer
{
    private static AudioPlayer _instance;
    public static AudioPlayer Instance 
    {
        get 
        {
            if(_instance == null)
            {
                _instance = new AudioPlayer();
            }
            
            return _instance;
        }
    } 

    private AudioPlayer()
    {
        // Initialize the audio player
    }

    public void Play(string audioClip) 
    {
        // play the clip
    }
}



