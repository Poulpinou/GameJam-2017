using UnityEngine;
using System.Collections.Generic;

public class Podium : MonoBehaviour {

	[SerializeField] Transform[] _winPosition;
	List<Enemy> _enemies;
	int _maxEnemies;
	Phases _phases;
	// Use this for initialization
	void Awake () {
		_maxEnemies = _winPosition.Length;
		_enemies = new List<Enemy>();
		_phases = FindObjectOfType<Phases>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Enemy enemy in _enemies)
		{
			enemy.transform.localPosition = Vector3.up * 0.5f;
			enemy.transform.localRotation = Quaternion.Euler(Vector3.zero);
		}
	
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.GetComponent<Enemy>() != null)
		{
			Enemy enemy = collision.collider.GetComponent<Enemy>();
			if(!_enemies.Contains(enemy) && _enemies.Count < _maxEnemies)
			{
				_enemies.Add(enemy);
				enemy.transform.parent = _winPosition[_enemies.Count - 1].transform;
				enemy.transform.localPosition = Vector3.up * 0.5f;
				enemy.transform.localRotation = Quaternion.Euler(Vector3.zero);
				_phases.SetDamage();

			}

		}
	}
}
