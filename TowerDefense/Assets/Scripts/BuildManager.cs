using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		if(instance!=null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		
		instance = this;
	}

	public GameObject standardTurretPrefab;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		turretToBuild=standardTurretPrefab;
	}

	private GameObject turretToBuild;
	
	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}
}
