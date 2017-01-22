using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using BDB;

public class TrapManager : MonoBehaviour {
	private bool is_building;
	private Trap active_trap;
	private Player player;
	private Grid grid;
	private int[] last_coordinates;
	private List<Material> oldMaterials = new List<Material>();

	[SerializeField]
	GameObject _magnet;
	[SerializeField]
	GameObject _emp;
	[SerializeField]
	GameObject _generator;


	public bool get_isBuilding()
	{
		return is_building;
	}

	public void set_isBuilding()
	{
		is_building = !is_building;
	}

	private void setActiveTrap(BDB.Trap selected_trap)
	{
		GameObject newTrap;
        switch (selected_trap)
		{
			case BDB.Trap.Magnet:
				newTrap = Instantiate(_magnet);
				active_trap = newTrap.GetComponent<Trap>();
				break;
			case BDB.Trap.Vibartor:
				break;
			case BDB.Trap.EMP:
				newTrap = Instantiate(_emp);
				active_trap = newTrap.GetComponent<Trap>();
				break;
			case BDB.Trap.Badaboum:
				break;
			case BDB.Trap.Wall:
				break;
			case BDB.Trap.Generator:
				newTrap = Instantiate(_generator);
				active_trap = newTrap.GetComponent<Trap>();
				break;
			default:
				break;
		}
	}

	public void buildTrap (BDB.Trap selected_trap)
	{
		setActiveTrap(selected_trap);
		if (check_possible(active_trap))
		{
			is_building = true;
		}
		else
		{
			kill_object();
		}

	}

	public bool check_possible (Trap trap)
	{
		if ((player.pieces - trap.cost) > 0)
		{
			player.spend_pieces(trap.cost);
			return true;
		}
		else
			kill_object();
			return false;
	}

	public void kill_object()
	{
		Destroy(active_trap);
		active_trap = null;
		is_building = false;
	}

	private void place_preview()
	{
		int[] temp_coor = grid.get_coordinates();
		if (temp_coor[0] != last_coordinates[0] || temp_coor[1] != last_coordinates[1])
		{
			last_coordinates = temp_coor;
			calculate_coordinates();
			calculate_range();

		}

	}

	private void calculate_coordinates()
	{
		active_trap.transform.position = new Vector3(last_coordinates[0] * grid.cellSize, 0, last_coordinates[1] * grid.cellSize);
	}

	private void calculate_range()
	{
		remove_all_squares();
		//float factor = grid.cellSize * 10 ;// Will may cause issues...
		Vector3 position = active_trap.transform.position;
		add_square(position.x - 0.5f, position.z - 0.5f);
		if (active_trap.size_x > 1)
		{
			for (int i = 1; i <= (active_trap.size_x - 1); i++)
			{
				if (active_trap.size_z > 1)
				{
					for (int j = 0; j <= (active_trap.size_z - 1); j++)
					{
						add_square(position.x - 0.5f + i, position.z - 0.5f + j);
					}
				}
			}
		}
    }

	private void add_square (float x, float z)
	{
		Square square = new Square();
		square.transform.position = new Vector3(x, -0.1f , z);
	}

	private void remove_all_squares()
	{
		Square[] squares = FindObjectsOfType<Square>();
        foreach (Square square in squares) {
			Destroy(square);
		}
	}



	public void SetTransparentMaterial(Material material, bool storeExistingMaterial)
	{
		if (storeExistingMaterial) oldMaterials.Clear();
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in renderers)
		{
			if (storeExistingMaterial) oldMaterials.Add(renderer.material);
			renderer.material = material;
		}
	}

	public void RestoreMaterials()
	{
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		if (oldMaterials.Count == renderers.Length)
		{
			for (int i = 0; i < renderers.Length; i++)
			{
				renderers[i].material = oldMaterials[i];
			}
		}
	}

	// Use this for initialization
	void Start () {
		is_building = false;
		last_coordinates = new int[] { 0, 0 };
		player = FindObjectOfType<Player>();
		grid = FindObjectOfType<Grid>();
	}
	
	// Update is called once per frame
	void Update () {
		if (is_building)
		{
			place_preview();

		}
	
	}
}
