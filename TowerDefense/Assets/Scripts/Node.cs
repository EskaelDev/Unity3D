using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;

	public Vector3 positionOffset;

	private GameObject turret;
	private Renderer rend;
	private Color startColor;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		if(turret !=null)
		{
			Debug.Log("Can't build there - TODO: Display on screen");
			return;
		}
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position+positionOffset, transform.rotation);
	}

	/// <summary>
	/// Called when the mouse enters the GUIElement or Collider.
	/// </summary>
	void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	/// <summary>
	/// Called when the mouse is not any longer over the GUIElement or Collider.
	/// </summary>
	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
