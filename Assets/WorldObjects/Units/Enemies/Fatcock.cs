using UnityEngine;
using System.Collections;

public class Fatcock : Enemy {

	public int shield;
	private bool shield_enabled;
	[SerializeField]
	GameObject shield_object;

	private void damage_shield (int amount)
	{
		shield -= amount;
		if (shield <= 0)
		{
			shield_enabled = false;
			Destroy(shield_object); 
		}
	}

	public override void SetDamages(int damages, BDB.Trap type)
	{
		if (shield_enabled)
		{
			if (type == BDB.Trap.EMP)
			{
				damages *= 4;
			}
			else
			{
				damages = 1;
			}
			damage_shield(damages);
		}
		else
		{
			base.SetDamages(damages, type);
		}

	}
	// Use this for initialization
	void Start () {
		shield_enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
