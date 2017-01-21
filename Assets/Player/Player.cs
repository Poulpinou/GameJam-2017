using UnityEngine;
using System.Collections;
using BDB;

public class Player : MonoBehaviour {
    public string Name;
    public int pieces, energy, energy_max;
    public float increment_speed;
    private float increment;
    private bool is_building;

    // ------- BUILD TRAP ---------
    public void buildTrap (GameObject trap)
    {

    }

    public void trapPreview (GameObject trap)
    {

    }


    //-------- RESOURCES ----------
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



    //Getters
    public int get_pieces ()
    {
        return pieces;
    }

    public string get_action()
    {
        return "Action";// Temporary get action
    }
	// Use this for initialization
	void Start () {
        is_building = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (energy != energy_max)
            reload_energy();
        if (is_building)
            trapPreview(ResourceManager.GetUnit(get_action()));
            

	
	}
}
