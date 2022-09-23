using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerInputController2 : MonoBehaviour
{
    [SerializeField] [Range (0.1f,1)] private float _movementSpeed;
    [SerializeField] private Weapon2 weapon;

    private CharacterController _characterController;
    private Vector2 _moveValue;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Debug.Log("Move");
        _moveValue = context.ReadValue<Vector2>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(!context.performed)
        {
            return;
        }

        weapon.Shoot();
    }

    private void FixedUpdate()
    {
        var moveVector = new Vector3(_moveValue.x, 0, _moveValue.y);
        _characterController.Move(moveVector * _movementSpeed);
    }
}