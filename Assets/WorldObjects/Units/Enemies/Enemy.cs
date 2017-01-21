using UnityEngine;
using System.Collections;

public class Enemy : Unit {

	#region Fields
	PathfinderDuPauvre _pathfinder;
	NavMeshAgent _agent;
	int index = 0;

	#endregion
	// Use this for initialization
	void Awake ()
	{
		_pathfinder = GameObject.FindObjectOfType<PathfinderDuPauvre>();
		_agent = GetComponent<NavMeshAgent>();
		LoadNewPathPoint();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(_agent.remainingDistance < 0.3f)
		{
			LoadNewPathPoint();
		}
	}

	void LoadNewPathPoint()
	{
		BoxCollider pathPoint = _pathfinder.GetPathPoint(index);
		if(pathPoint != null)
		{
			float distanceX = Random.Range(-pathPoint.transform.lossyScale.x/2, pathPoint.transform.lossyScale.x/2);
			float distanceZ = Random.Range(-pathPoint.transform.lossyScale.z/2, pathPoint.transform.lossyScale.z/2);
			Vector3 destination = pathPoint.transform.position + pathPoint.transform.right * distanceX + pathPoint.transform.forward * distanceZ;
			_agent.SetDestination(destination);
			index++;
		}

	}
}
