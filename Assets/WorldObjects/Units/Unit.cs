using UnityEngine;
using System.Collections;
using BDB;

public class Unit : WorldObject {
    public int health, maxhealth;
    private float healthPercentage;
    public Player owner;

    /*
    private void CalculateCurrentHealth()
    {
        healthPercentage = health / maxhealth;
        if (healthPercentage > 0.65f) healthStyle.normal.background = ResourceManager.HealthyTexture;
        else if (healthPercentage > 0.35f) healthStyle.normal.background = ResourceManager.DamagedTexture;
        else healthStyle.normal.background = ResourceManager.CriticalTexture;
    }*/

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
