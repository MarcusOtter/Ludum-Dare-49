using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private float _inputX;
	private float _inputY;

	private void Update()
	{
		_inputX = Input.GetAxisRaw("Horizontal");
		_inputY = Input.GetAxisRaw("Vertical");
	}

	public float GetInputX()
	{
		return _inputX;
	}

	public float GetInputY()
	{
		return _inputY;
	}
}
