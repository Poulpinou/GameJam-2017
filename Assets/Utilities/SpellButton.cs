using UnityEngine;
using System.Collections;

public class SpellButton : MonoBehaviour {

	[SerializeField]
	BDB.Spell _spell;

	Player _player;
	// Use this for initialization
	void Start ()
	{
		_player = GameObject.FindObjectOfType<Player>();
		if(_player == null)
		{
			Debug.LogError("no player in the scene");
		}
	}
	public void OnClick()
	{
		_player.set_spell(_spell);
	}
}
