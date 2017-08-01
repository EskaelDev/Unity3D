using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;

	private Transform target;
	private int wavepointIndex = 0;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		target = Waypoints.waypoints[0];
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		Vector3 direction = target.position-transform.position;
		transform.Translate(direction.normalized*speed*Time.deltaTime, Space.World);

		if(Vector3.Distance(transform.position, target.position)<=0.2f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if(wavepointIndex>=Waypoints.waypoints.Length-1)
	{
		Destroy(gameObject);
		return;
	}

		wavepointIndex++;
		target=Waypoints.waypoints[wavepointIndex];
	}
}
