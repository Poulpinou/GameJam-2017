using UnityEngine;
using System.Collections;

public class PathfinderDuPauvre : MonoBehaviour {
	[SerializeField] BoxCollider[] _path;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public BoxCollider GetPathPoint(int index)
	{
		if (index >= _path.Length) return null;
		return _path[index];
	}
}
