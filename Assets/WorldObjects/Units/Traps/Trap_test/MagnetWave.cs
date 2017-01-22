using UnityEngine;
using System.Collections;

public class MagnetWave : MonoBehaviour {

	Magnet _magnet;
	// Use this for initialization
	void Start () {
		_magnet = transform.parent.gameObject.GetComponent<Magnet>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.GetComponent<Enemy>() != null)
		{
			_magnet.SetNewAttractedEnemy(other.GetComponent<Enemy>());
		}
	}
}
