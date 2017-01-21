using UnityEngine;
using System.Collections;

public class EnemiesManager : MonoBehaviour {
	[SerializeField] BoxCollider _spawn;
	[SerializeField] GameObject _enemyBibit;
	[SerializeField] GameObject _enemyFatCock;
	[SerializeField] GameObject _enemyFlyingPhallus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B))
		{
			SpawnEnemy(BDB.Enemies.Bibit);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			SpawnEnemy(BDB.Enemies.FatCock);
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			SpawnEnemy(BDB.Enemies.FlyingPhallus);
		}
	}


	public void SpawnEnemy(BDB.Enemies enemy)
	{
		GameObject newEnemy = null;
		switch (enemy)
		{
			case BDB.Enemies.Bibit:
				newEnemy = Instantiate(_enemyBibit);
				break;
			case BDB.Enemies.FatCock:
				newEnemy = Instantiate(_enemyFatCock);
				break;
			case BDB.Enemies.FlyingPhallus:
				newEnemy = Instantiate(_enemyFlyingPhallus);
				break;
			default:
				break;
		}
		float distanceX = Random.Range(-_spawn.transform.lossyScale.x / 2, _spawn.transform.lossyScale.x / 2);
		float distanceZ = Random.Range(-_spawn.transform.lossyScale.z / 2, _spawn.transform.lossyScale.z / 2);
		newEnemy.transform.position = _spawn.transform.position + _spawn.transform.right * distanceX + _spawn.transform.forward * distanceZ;
	}

}
