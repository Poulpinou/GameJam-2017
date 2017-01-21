using UnityEngine;
using System.Collections;
using BDB;

public class Phases : MonoBehaviour {
    private Phase actualPhase;
    private int timer, timerLimit, actualWave;
    private float increment;

    public void nextPhase()
    {
        if (actualPhase == Phase.Start)
        {
            if (Input.GetKey(KeyCode.S))
            {
                actualPhase = Phase.Timer;
                timerLimit = 5; // Really equal 5 seconds? => Test
            }
        }
        if (actualPhase == Phase.Timer)
        {
            playTimer();
            if (timer == timerLimit)
            {
                actualPhase = Phase.Battle;
                timer = 0;
            }
        }
        if (actualPhase == Phase.Battle)
        {
            // When there is no more ennemies
            actualPhase = Phase.Timer;
            timerLimit = 20;
        }
    }

    private void playTimer()
    {
        increment += Time.deltaTime;
        if (increment > 1)
        {
            timer += 1;
            increment = 0;
        }
    }

    public Phase getPhase()
    {
        return actualPhase;
    }

	// Use this for initialization
	void Start () {
        actualPhase = Phase.Start;
	}
	
	// Update is called once per frame
	void Update () {
        nextPhase();
	}
}
