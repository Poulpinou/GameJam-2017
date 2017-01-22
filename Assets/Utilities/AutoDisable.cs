using UnityEngine;
using System.Collections;

public class AutoDisable : MonoBehaviour {

	[SerializeField]
	float _timer;

	float _timeLeft;
	// Use this for initialization

	private void OnEnable()
	{
		_timeLeft = _timer;
	}
	void Awake ()
	{
		_timeLeft = _timer;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(_timeLeft <= 0.0f)
		{
			this.gameObject.SetActive(false);
		}
		_timeLeft -= Time.deltaTime;
	
	}
}
