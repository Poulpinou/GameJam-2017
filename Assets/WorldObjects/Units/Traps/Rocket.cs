using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	[SerializeField]
	float _speed;
	public Vector3 _destination;

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
	}
	// Update is called once per frame
	void Update ()
	{
		transform.position += _direction * _speed * Time.deltaTime;
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
