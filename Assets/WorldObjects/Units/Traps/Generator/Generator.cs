using UnityEngine;
using System.Collections;

public class Generator : Trap {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Enemy>() != null)
		{
			other.GetComponent<Enemy>().value *= 2;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Enemy>() != null)
		{
			other.GetComponent<Enemy>().value /= 2;
		}
	}
}
