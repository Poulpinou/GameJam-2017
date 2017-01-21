using UnityEngine;
using System.Collections;

public class VibartorWave : MonoBehaviour {

	[SerializeField] float _speelLoss;
	[SerializeField] float _waveSpeed;
	float _timeOnSpawn;
	float _scale;
	// Use this for initialization
	void Awake ()
	{
		_timeOnSpawn = Time.time;
		_scale = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_scale += Time.deltaTime * _waveSpeed;
		transform.localScale = Vector3.one * _scale;
		if(_scale > 1)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		print("trigger");
		if(collider.GetComponent<Enemy>() != null)
		{
			Enemy enemy = collider.GetComponent<Enemy>();
			enemy.SetDamages(1);
			enemy.GetComponent<NavMeshAgent>().speed -= _speelLoss;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.GetComponent<Enemy>() != null)
		{
			Enemy enemy = collider.GetComponent<Enemy>();
			enemy.SetDamages(1);
			enemy.GetComponent<NavMeshAgent>().speed += _speelLoss;
		}
	}
}
