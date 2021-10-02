using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float movementSpeed = 1;
	//[SerializeField] private float rotationSpeed;

	private const string CartTag = "Cart";
	private const string GrabCartButton = "Submit";

	private Transform _transform;
	private Rigidbody _rigidbody;
	private PlayerInput _playerInput;

	private Transform _cart;
	private bool _canGrabCart;
	private bool _isHoldingCart;

	private void Awake()
	{
		_playerInput = FindObjectOfType<PlayerInput>();
		_rigidbody = GetComponent<Rigidbody>();
		_transform = transform;
	}

    private void Update()
    {
	    if (_isHoldingCart)
	    {
		    if (Input.GetButtonDown(GrabCartButton))
		    {
			    _isHoldingCart = false;
		    }

			return;
	    }

	    if (_canGrabCart && Input.GetButtonDown(GrabCartButton))
	    {
		    _isHoldingCart = true;
		    _rigidbody.velocity = Vector3.zero;
		    _transform.position = _cart.position;
		    _transform.forward = _cart.forward;
		    return;
	    }


	    var playerInputX = _playerInput.GetInputX();
	    var playerInputY = _playerInput.GetInputY();

	    // Rotation should be reversed when backing up
		//var rotationDirectionMultiplier = playerInputY < 0 ? -1 : 1;
		//_rigidbody.velocity = transform.forward * (playerInputY * movementSpeed);
		//_rigidbody.angularVelocity = Mathf.Abs(playerInputX) > 0
		//	? new Vector3(0, playerInputX * rotationSpeed * rotationDirectionMultiplier, 0)
		//	: Vector3.zero;

		_rigidbody.velocity = new Vector3(playerInputX, 0, playerInputY).normalized * movementSpeed;
		if (_rigidbody.velocity.sqrMagnitude > 0)
		{
			_transform.forward = _rigidbody.velocity;
		}
    }

    private void OnTriggerEnter(Collider trigger)
    {
	    if (_isHoldingCart) return;
	    if (!trigger.CompareTag(CartTag)) return;
	    _cart = trigger.transform;
	    _canGrabCart = true;
    }

	private void OnTriggerExit(Collider trigger)
    {
	    if (!trigger.CompareTag(CartTag)) return;
	    _canGrabCart = false;
    }
}
