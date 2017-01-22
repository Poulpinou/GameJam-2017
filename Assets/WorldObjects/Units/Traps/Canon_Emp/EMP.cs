using UnityEngine;
using System.Collections;

public class EMP : Trap {
	[SerializeField] float _range;
	[SerializeField] GameObject _ray;
	float _lastWave;
	Transform _canon;
	// Use this for initialization
	void Awake () {
		Transform[] children = GetComponentsInChildren<Transform>();
		foreach(Transform child in children)
		{
			if(child.name.Contains("Rotor"))
			{
				_canon = child;
				break;
			}
		}
		_lastWave = Time.time;
		SendEMP();
		_ray.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time - _lastWave >= reloadTime)
		{
			SendEMP();
		}
	}

	void SendEMP()
	{
		Enemy[] enemies = FindObjectsOfType<Enemy>();
		float minDistance = float.MaxValue;
		Enemy closestEnemy = null;
		foreach(Enemy enemy in enemies)
		{
			float distance = Vector3.Distance(enemy.transform.position, transform.position);
			if (distance < minDistance)
			{
				minDistance = distance;
				closestEnemy = enemy;
			}
		}
		if(minDistance <= _range && closestEnemy != null)
		{
			Vector3 target = closestEnemy.transform.position;
			_canon.transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
			closestEnemy.Shoot(BDB.Trap.EMP);
			_lastWave = Time.time;
			_ray.SetActive(true);
		}
	}
}
