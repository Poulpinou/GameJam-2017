using UnityEngine;
using System.Collections;

public class Trap : Unit {
    public int cost, size_x, size_z;
    public float reloadTime;
	bool isActive;

	public bool SetActive { set { isActive = value; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
