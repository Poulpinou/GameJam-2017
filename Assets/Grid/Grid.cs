using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
    public int cellSize;
    public int maxSize;
    private bool grid_enabled;
    private int[] coordinates;

    private int calculate_x_pos(Vector3 hitPoint)
    {
        int  x_pos =(int)(hitPoint.x);
        if (x_pos < maxSize && x_pos > -maxSize)
        {
            x_pos -= x_pos % cellSize;
            return x_pos / cellSize;
        }
        else return 0;
    }

    private int calculate_z_pos(Vector3 hitPoint)
    {
        int z_pos = (int)(hitPoint.z);
        if (z_pos < maxSize && z_pos > -maxSize)
        {
            z_pos -= z_pos % cellSize;
            return z_pos / cellSize;
        }
        else return 0;
    }

    private void build_coordinates()
    {
        coordinates = new int[] { calculate_x_pos(UserInput.FindHitPoint(Input.mousePosition)), calculate_z_pos(UserInput.FindHitPoint(Input.mousePosition)) };
        Debug.Log("x = " + coordinates[0] + " / y = " + coordinates[1]);
    }

    public int get_coordinate (string axe = null)
    {
        build_coordinates();
        if (axe != null)
        {
            if (axe == "x")
                return coordinates[0];
            else if (axe == "y")
                return coordinates[1];
            else
            {
                Debug.Log("Invalid");
                return 0;
            }
        }
        else
            return 0;
    }

    public int[] get_coordinates()
    {
        build_coordinates();
        return coordinates;
    }

    public void hide_show_grid()
    {
        if (grid_enabled)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else if (!grid_enabled)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }

    private void show_ground_rect()
    {

    }


    // Use this for initialization
    void Start () {
        grid_enabled = true;
        hide_show_grid();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            grid_enabled = true;
            hide_show_grid();
        }
        if (Input.GetKey(KeyCode.D))
        {
            grid_enabled = false;
            hide_show_grid();
        }




    }
}
