using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] [Range(.1f, 1)] private float _playerSpeed;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private WeaponWithBulletPool _weaponWithPool;
    
    private List<IWeapon> _availableWeapons = new List<IWeapon>();
    private int _activeWeaponSlot = 1;

    private Vector2 _moveInput;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void AddWeapon(IWeapon weapon)
    {
        _availableWeapons.Add(weapon);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        // Debug.Log($"moveInput: {_moveInput}");
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(_weapon != null)
            _weapon.Shoot();

        if(_weaponWithPool != null)
            _weaponWithPool.Shoot();

        if(_availableWeapons.Count > _activeWeaponSlot)
            _availableWeapons[_activeWeaponSlot].Shoot();
    }

    private void FixedUpdate()
    {
        var moveVector = new Vector3(_moveInput.x, 0, _moveInput.y);
        _characterController.Move( moveVector * _playerSpeed);
    }
}
