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
	[SerializeField]
	GameObject _badaboum;
	[SerializeField]
	GameObject _vibartor;


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
				newTrap = Instantiate(_vibartor);
				active_trap = newTrap.GetComponent<Trap>();
				break;
			case BDB.Trap.EMP:
				newTrap = Instantiate(_emp);
				active_trap = newTrap.GetComponent<Trap>();
				break;
			case BDB.Trap.Badaboum:
				newTrap = Instantiate(_badaboum);
				active_trap = newTrap.GetComponent<Trap>();
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
		if (active_trap != null)
		{
			if (active_trap == null) return;
			Destroy(active_trap.gameObject);
			active_trap = null;
			is_building = false;
		}
	}

	public void place_object()
	{
		if (active_trap != null)
		{
			active_trap.SetActive = true;
			active_trap = null;
		}
	}

	private void place_preview()
	{
		int[] temp_coor = grid.get_coordinates();
		if (temp_coor[0] != last_coordinates[0] || temp_coor[1] != last_coordinates[1])
		{
			last_coordinates = temp_coor;
			calculate_coordinates();

		}

	}

	private void calculate_coordinates()
	{
		if (active_trap != null)
		{
			active_trap.transform.position = new Vector3(last_coordinates[0] * grid.cellSize, 0, last_coordinates[1] * grid.cellSize);
		}
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
