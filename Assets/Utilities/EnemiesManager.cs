using UnityEngine;
using System.Collections;

public class EnemiesManager : MonoBehaviour {
	[SerializeField] BoxCollider _spawn;
	[SerializeField] GameObject _enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
		{
			SpawnEnemy(BDB.Enemies.Bibit);
		}
	}


	public void SpawnEnemy(BDB.Enemies enemy)
	{
		GameObject newEnemy = Instantiate(_enemy);
		float distanceX = Random.Range(-_spawn.transform.lossyScale.x / 2, _spawn.transform.lossyScale.x / 2);
		float distanceZ = Random.Range(-_spawn.transform.lossyScale.z / 2, _spawn.transform.lossyScale.z / 2);
		newEnemy.transform.position = _spawn.transform.position + _spawn.transform.right * distanceX + _spawn.transform.forward * distanceZ;
	}

}
