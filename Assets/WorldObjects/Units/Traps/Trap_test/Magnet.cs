using UnityEngine;
using System.Collections.Generic;

public class Magnet : Trap {

	[SerializeField] int _maxEnemiesAttracted;
	[SerializeField] int _damage;
	List<Enemy> _attractedEnemies;
	float _lastWave;
	// Use this for initialization
	void Awake () {
		_lastWave = Time.time;
		_attractedEnemies = new List<Enemy>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time - _lastWave > reloadTime)
		{
			DealDamage();
		}
	}

	void DealDamage()
	{
		foreach(Enemy enemy in _attractedEnemies)
		{
			if (enemy == null)
			{
				_attractedEnemies.Remove(enemy);
				return;
			}
			else
			{
				if (Vector3.Distance(enemy.transform.position, transform.position) < 2.0f)
				{
					enemy.SetDamages(_damage, BDB.Trap.Magnet);
					_lastWave = Time.time;
					enemy.Freeze(reloadTime * 2);
				}
			}
		}
	}

	public void SetNewAttractedEnemy(Enemy enemy)
	{
		if (!_attractedEnemies.Contains(enemy) && _attractedEnemies.Count < _maxEnemiesAttracted)
		{
			_attractedEnemies.Add(enemy);
			NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
			agent.SetDestination(transform.position);
			agent.speed *= 2;
		}
	}
}
