using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float movementSpeed;
	[SerializeField] private float rotationSpeed;

	private Rigidbody _rigidbody;
	private PlayerInput _playerInput;

	private void Awake()
	{
		_playerInput = FindObjectOfType<PlayerInput>();
		_rigidbody = GetComponent<Rigidbody>();
	}

    private void Update()
    {
	    var playerInputX = _playerInput.GetInputX();
	    var playerInputY = _playerInput.GetInputY();
	    // Rotation should be reversed when backing up
		var rotationDirectionMultiplier = playerInputY < 0 ? -1 : 1;

	    _rigidbody.velocity = transform.forward * (playerInputY * movementSpeed);
	    _rigidbody.angularVelocity = Mathf.Abs(playerInputX) > 0
			? new Vector3(0, playerInputX * rotationSpeed * rotationDirectionMultiplier, 0)
			: Vector3.zero;
    }
}
