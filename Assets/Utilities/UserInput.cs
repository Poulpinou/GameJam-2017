using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BDB;

public class UserInput : MonoBehaviour {
    // Variables
    private Player player;

    // Functions
    // CAMERAS
    private void MoveCamera()
    {
        float xpos = Input.mousePosition.x;
        float ypos = Input.mousePosition.y;
        Vector3 movement = new Vector3(0, 0, 0);

        //horizontal camera movement
        if (xpos >= 0 && xpos < ResourceManager.ScrollWidth)
        {
            movement.x -= ResourceManager.ScrollSpeed;
        }
        else if (xpos <= Screen.width && xpos > Screen.width - ResourceManager.ScrollWidth)
        {
            movement.x += ResourceManager.ScrollSpeed;
        }

        //vertical camera movement
        if (ypos >= 0 && ypos < ResourceManager.ScrollWidth)
        {
            movement.z -= ResourceManager.ScrollSpeed;
        }
        else if (ypos <= Screen.height && ypos > Screen.height - ResourceManager.ScrollWidth)
        {
            movement.z += ResourceManager.ScrollSpeed;
        }

		//make sure movement is in the direction the camera is pointing
		//but ignore the vertical tilt of the camera to get sensible scrolling
		if (Camera.main != null)
		{
			movement = Camera.main.transform.TransformDirection(movement);
			movement.y = 0;

			//away from ground movement
			movement.y -= ResourceManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");

			//calculate desired camera position based on received input
			Vector3 origin = Camera.main.transform.position;
			Vector3 destination = origin;
			destination.x += movement.x;
			destination.y += movement.y;
			destination.z += movement.z;

			//limit away from ground movement to be between a minimum and maximum distance
			if (destination.y > ResourceManager.MaxCameraHeight)
			{
				destination.y = ResourceManager.MaxCameraHeight;
			}
			else if (destination.y < ResourceManager.MinCameraHeight)
			{
				destination.y = ResourceManager.MinCameraHeight;
			}

			//if a change in position is detected perform the necessary update
			if (destination != origin)
			{
				Camera.main.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.ScrollSpeed);
			}
		}

    }

    private void RotateCamera()
    {
		if (Camera.main != null)
		{
			Vector3 origin = Camera.main.transform.eulerAngles;
			Vector3 destination = origin;

			//detect rotation amount if ALT is being held and the Right mouse button is down
			if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetMouseButton(1))
			{
				destination.x -= Input.GetAxis("Mouse Y") * ResourceManager.RotateAmount;
				destination.y += Input.GetAxis("Mouse X") * ResourceManager.RotateAmount;
			}

			//if a change in position is detected perform the necessary update
			if (destination != origin)
			{
				Camera.main.transform.eulerAngles = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.RotateSpeed);
			}
		}

    }

    //WORLD SELECTION
    private void MouseActivity()
    {
        if (Input.GetMouseButtonDown(0)) LeftMouseClick();
        else if (Input.GetMouseButtonDown(1)) RightMouseClick();
    }

    private void LeftMouseClick()
    {
		TrapManager trap_manager = FindObjectOfType<TrapManager>();
		if (trap_manager.get_isBuilding() == false)
		{
			GameObject hitObject = FindHitObject(Input.mousePosition);
			if (hitObject.name == "Grid")
			{
				int[] test = hitObject.GetComponent<Grid>().get_coordinates();
			}
		}
		else
		{
			trap_manager.place_object();
			//trap_manager.kill_object();
		}
    }

    private void RightMouseClick()
    {
		TrapManager trap_manager = FindObjectOfType<TrapManager>();
		if (trap_manager.get_isBuilding() == false)
		{
			
		}
		else
		{
			trap_manager.kill_object();
		}
	}

    public static GameObject FindHitObject(Vector3 origin)
    {
        Ray ray = Camera.main.ScreenPointToRay(origin);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) return hit.collider.gameObject;
        return null;
    }

    public static Vector3 FindHitPoint(Vector3 origin)
    {
		if (Camera.main != null)
		{
			Ray ray = Camera.main.ScreenPointToRay(origin);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) return hit.point;
		}
        return ResourceManager.InvalidPosition;
    }

  


    // Use this for initialization
    void Start () {
        //Initialize player
        player = transform.root.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
   
        MoveCamera();
        RotateCamera();


        MouseActivity();
    }

       
}
