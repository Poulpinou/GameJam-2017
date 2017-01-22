using UnityEngine;
using System.Collections.Generic;

public class Vibartor : Trap {

	[SerializeField] GameObject _wave;

	float _lastWave;
	List<GameObject> _waves;
	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Time.time - _lastWave > reloadTime)
		{
			SpawnWave();
		}
	}

	void SpawnWave()
	{
		GameObject newWave = Instantiate(_wave);
		newWave.transform.parent = this.transform;
		newWave.transform.localPosition = new Vector3(0, -0.4f, 0);
		_lastWave = Time.time;
	}
}
