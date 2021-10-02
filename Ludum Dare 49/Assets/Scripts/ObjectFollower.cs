using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
	[SerializeField] private Transform transformToFollow;

	private Vector3 _offset;
	private bool _shouldFollow;

	private void Awake()
	{
		_offset = transformToFollow.position - transform.position;
		_shouldFollow = transformToFollow != null;
	}

	private void Update()
	{
		if (!_shouldFollow) return;
	    transform.position = transformToFollow.position - _offset;
    }
}
