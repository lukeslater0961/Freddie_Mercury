using UnityEngine;

public class TranslateObject : MonoBehaviour
{
	public Transform	_targetPos;
	public Vector3	_startPos;
	bool _goingToFinal;

	private float		_speed = 1f;

	void Start()
	{
		_startPos = transform.position;
		_goingToFinal = true;
	}

	void FixedUpdate()
	{
		if (!_targetPos) return;
		Vector3	_currentTarget = _goingToFinal ? _targetPos.position : _startPos;
		float step =  _speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, _currentTarget, step);

		if (Vector3.Distance(transform.position, _currentTarget) < 0.001f)
			_goingToFinal = !_goingToFinal;
	}
}
