using UnityEngine;

public class Floating_Object : MonoBehaviour
{
    [Header("Bob")]
    public float bobHeight = 0.05f;
    public float bobSpeed = 0.8f;

    [Header("Tilt")]
	public bool  doTilt;
    public float tiltAngle = 2f;
    public float tiltSpeed = 0.5f;

	[Header("Tilt Axis")]
	public bool tiltX;
	public bool tiltY;
	public bool tiltZ;

    private float _phase;
    private Vector3 _startPos;
    private Quaternion _startRot;

    void Start()
    {
        _phase = Random.Range(0f, Mathf.PI * 2f);
        _startPos = transform.position;
        _startRot = transform.rotation;
    }

    void Update()
    {
        float t = Time.time;

        float yOffset = Mathf.Sin(t * bobSpeed + _phase) * bobHeight;
        transform.position = _startPos + new Vector3(0f, yOffset, 0f);

		if (!doTilt) return;

        float tilt = Mathf.Sin(t * tiltSpeed + _phase) * tiltAngle;
        transform.rotation = _startRot * Quaternion.Euler(
				tiltX ? tilt : 0f, 
				tiltY ? tilt : 0f, 
				tiltZ ? tilt : 0f);
    }
}
