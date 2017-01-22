using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	[SerializeField]
	float _speed;
	public Vector3 _destination;
	float _timeOnStart;

	Vector3 _direction;
	// Use this for initialization
	void Awake () {
		
	}
	
	public void SetDestination(Vector3 destination)
	{
		_destination = destination;
		_destination.y = transform.position.y;
		_direction = (_destination - transform.position).normalized;
		transform.LookAt(_direction);
		_timeOnStart = Time.time;
	}
	// Update is called once per frame
	void Update ()
	{
		transform.position += _direction * _speed * Time.deltaTime;

		if(Time.time - _timeOnStart >= 10.0f)
		{
			Destroy(this.gameObject);
		}
		_timeOnStart += Time.deltaTime;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.GetComponent<Enemy>() != null)
		{
			collision.collider.GetComponent<Enemy>().Shoot(BDB.Trap.Badaboum);
		}

		Destroy(this.gameObject);
	}
}
