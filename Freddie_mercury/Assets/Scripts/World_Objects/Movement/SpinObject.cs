using UnityEngine;

public class RotateObject : MonoBehaviour
{
	private float _speed = 5f;


    void FixedUpdate()
    {
        transform.Rotate(Vector3.down, _speed * Time.deltaTime, Space.Self);
    }
}
