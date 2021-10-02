using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
	[SerializeField] private Transform transformToFollow;

	private Vector3 _offset;

	private void Awake()
	{
		_offset = transformToFollow.position - transform.position;
	}

	private void Update()
    {
	    transform.position = transformToFollow.position - _offset;
    }
}
