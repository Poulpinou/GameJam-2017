using UnityEngine;
using System.Collections;

public class TrapButton : MonoBehaviour {

	[SerializeField]
	BDB.Trap _trap;

	Player _player;
	// Use this for initialization
	void Start()
	{
		_player = GameObject.FindObjectOfType<Player>();
		if (_player == null)
		{
			Debug.LogError("no player in the scene");
		}
	}

	public void OnClick()
	{
		_player.set_trap(_trap);
	}
}
