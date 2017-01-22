using UnityEngine;
using System.Collections;
using System;
using BDB;

public class Phases : MonoBehaviour {
    private Phase actualPhase;
    private float timer;
    private float increment;
	WaveManager _waveManager;
	int _waveCount;
	int _waveIndex = 0;
	[SerializeField] float waveTimer;
	[SerializeField] float waitTimer;
	[SerializeField] float surviveTimer;
	[SerializeField] int _lifePoints;

	public float GetInvertedTimer { get { return waitTimer - timer; } }
	public event Action OnPhaseChange;

    public void nextPhase()
    {
        if (actualPhase == Phase.Start)
        {
            if (Input.GetKey(KeyCode.S))
            {
                actualPhase = Phase.Timer;
            }
        }
        if (actualPhase == Phase.Timer)
        {
            playTimer();
            if (timer >= waitTimer)
            {
                actualPhase = Phase.Battle;
                timer = 0;
				if (_waveIndex < _waveCount)
				{
					_waveManager.SetWave(_waveIndex);
				}
				else
				{
					actualPhase = Phase.Survive;
				}
            }
        }
        if (actualPhase == Phase.Battle)
        {
			playTimer();
			if(timer >= waveTimer)
			{
				actualPhase = Phase.Timer;
				timer = 0;
				_waveIndex++;
			}
        }

		if(actualPhase == Phase.Survive)
		{
			playTimer();
			if (timer >= surviveTimer)
			{
				actualPhase = Phase.Win;
			}
		}

		OnPhaseChange();
    }

    private void playTimer()
    {
        timer += Time.deltaTime;
    }

    public Phase getPhase()
    {
        return actualPhase;
    }

	public void SetDamage()
	{
		_lifePoints--;
		if(_lifePoints <= 0)
		{
			actualPhase = Phase.Lose;
		}
	}

	// Use this for initialization
	void Awake () {
        actualPhase = Phase.Start;
		_waveManager = FindObjectOfType<WaveManager>();
		_waveCount = _waveManager.GetWaveCount;
	}
	
	// Update is called once per frame
	void Update () {
        nextPhase();
	}
}
