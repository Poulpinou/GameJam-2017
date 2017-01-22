using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
	[SerializeField]
	int[] _bibitPerWave;
	[SerializeField]
	int[] _fatPerWave;
	[SerializeField]
	int[] _flyPerWave;

	public int GetWaveCount { get { return _bibitPerWave.Length; } }
	EnemiesManager _enemyManager;
	// Use this for initialization
	void Awake () {
		_enemyManager = FindObjectOfType<EnemiesManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetWave(int index)
	{
		for(int i = 0; i < _bibitPerWave[index]; i++)
		{
			_enemyManager.SpawnEnemy(BDB.Enemies.Bibit);
		}
		for (int i = 0; i < _fatPerWave[index]; i++)
		{
			_enemyManager.SpawnEnemy(BDB.Enemies.FatCock);
		}
		for (int i = 0; i < _flyPerWave[index]; i++)
		{
			_enemyManager.SpawnEnemy(BDB.Enemies.FlyingPhallus);
		}
	}
}
