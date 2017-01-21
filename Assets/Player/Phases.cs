using UnityEngine;
using System.Collections;

public class Phases : MonoBehaviour {
    private string actualPhase;
    private int timer, timerLimit, actualWave;
    private float increment;

    public void nextPhase()
    {
        if (actualPhase == "Start")
        {
            if (Input.GetKey(KeyCode.S))
            {
                actualPhase = "Timer";
                timerLimit = 5; // Really equal 5 seconds? => Test
            }
        }
        if (actualPhase == "Timer")
        {
            playTimer();
            if (timer == timerLimit)
            {
                actualPhase = "Battle";
                timer = 0;
            }
        }
        if (actualPhase == "Battle")
        {
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

    public string getPhase()
    {
        return actualPhase;
    }

	// Use this for initialization
	void Start () {
        actualPhase = "Start";
	}
	
	// Update is called once per frame
	void Update () {
        nextPhase();
	}
}
