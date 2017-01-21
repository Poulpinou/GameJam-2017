using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public string Name;
    public int pieces, energy, energy_max;
    public float increment_speed;
    private float increment;

    // ------- BUILD TRAP ---------


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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (energy != energy_max)
            reload_energy();
            

	
	}
}
