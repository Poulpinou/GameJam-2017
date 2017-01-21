using UnityEngine;
using System.Collections;
using BDB;

public class Player : MonoBehaviour {
	#region Fields
	public string Name;
    public int pieces, energy, energy_max;
    public float increment_speed;
    private float increment;
	private TrapManager trapManager;

	#endregion

	#region Resources
	//Setters
	private void reload_energy ()
    {
        increment += Time.deltaTime * increment_speed;
        if (increment > 1)
        {
            energy += 1;
            increment = 0;
        }
    }

    public void spend_pieces (int amount)
    {
        if (amount < 0)
            amount = 0;
        pieces -= amount;
    }

    public void add_pieces()
    {
        // Make later a system which can add pieces with bonus and enemies' death
    }

	public int get_pieces()
	{
		return pieces;
	}

	#endregion

	#region Properties

	public void set_trap(BDB.Trap trap)
	{
		trapManager.buildTrap(trap);
	}



	public void set_spell(BDB.Spell spell)
	{
		switch (spell)
		{
			case Spell.Spell1:
				break;
			case Spell.Spell2:
				break;
			case Spell.Spell3:
				break;
			case Spell.Spell4:
				break;
			default:
				break;
		}
		print(spell);
	}

	#endregion
	// Use this for initialization
	void Start () {
		trapManager = FindObjectOfType<TrapManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (energy != energy_max)
            reload_energy();
		if (Input.GetKey(KeyCode.B))
			trapManager.buildTrap(BDB.Trap.Magnet);
	}
}
