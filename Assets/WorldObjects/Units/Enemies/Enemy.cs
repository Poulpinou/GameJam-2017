using UnityEngine;

public class Enemy : Unit {

	public int value;
	#region Fields
	PathfinderDuPauvre _pathfinder;
	NavMeshAgent _agent;
	Player _player;
	int index = 0;
	float _originalSpeed;
	float _timeOnFreeze;
	float _timeToFreeze;
	bool _isFrozen = false;

	#endregion

	#region Properties
	public BDB.Enemies _enemyName;

	#endregion
	// Use this for initialization
	void Awake ()
	{
		_pathfinder = GameObject.FindObjectOfType<PathfinderDuPauvre>();
		_agent = GetComponent<NavMeshAgent>();
		LoadNewPathPoint();
		_originalSpeed = GetComponent<NavMeshAgent>().speed;
		_player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!_isFrozen)
		{
			if (_agent.remainingDistance < 0.8f)
			{
				LoadNewPathPoint();
			}
		}
		else
		{
			if(Time.time - _timeOnFreeze >= _timeToFreeze)
			{
				_agent.Resume();
				_isFrozen = false;
			}
		}
	}

	void LoadNewPathPoint()
	{
		BoxCollider pathPoint = _pathfinder.GetPathPoint(index);
		if(pathPoint != null)
		{
			float distanceX = UnityEngine.Random.Range(-pathPoint.transform.lossyScale.x/2, pathPoint.transform.lossyScale.x/2);
			float distanceZ = UnityEngine.Random.Range(-pathPoint.transform.lossyScale.z/2, pathPoint.transform.lossyScale.z/2);
			Vector3 destination = pathPoint.transform.position + pathPoint.transform.right * distanceX + pathPoint.transform.forward * distanceZ;
			_agent.SetDestination(destination);
			index++;
		}
		else
		{
			Destroy(this.gameObject);
		}

	}

	public virtual void SetDamages(int damages, BDB.Trap type)
	{
		if (type == BDB.Trap.EMP)
			Freeze(1.0f);
		else
		{
			health -= damages;
			if (health <= 0)
			{
				Destroy(this.gameObject);
			}
			_player.add_pieces(value);
		}
	}

	public void Shoot(BDB.Trap type)
	{
		if (_enemyName == BDB.Enemies.FatCock) return;

		switch (type)
		{
			case BDB.Trap.Magnet:
				break;
			case BDB.Trap.Vibartor:
				break;
			case BDB.Trap.EMP:
				SetDamages(5, type);
				break;
			case BDB.Trap.Badaboum:
				SetDamages(5, type);
				break;
			case BDB.Trap.Wall:
				break;
			case BDB.Trap.Generator:
				break;
			default:
				break;
		}
	}

	public void Freeze(float time)
	{
		_agent.Stop();
		_timeOnFreeze = Time.time;
		_timeToFreeze = time;
		_isFrozen = true;
	}
}
