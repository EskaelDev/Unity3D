﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;
	public float range = 10f;
	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;
	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach(GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy<shortestDistance)
			{
				shortestDistance=distanceToEnemy;
				nearestEnemy=enemy;
			}
		}
		if(nearestEnemy!=null&&shortestDistance<=range)
		{
			target = nearestEnemy.transform;
		}
		else {
			target=null;
		}
	}
	// Update is called once per frame
	void Update () {
		if(target==null)
		return;

		Vector3 direction = target.position-transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
		partToRotate.rotation= Quaternion.Euler(0f, rotation.y, 0f);
	}

	/// <summary>
	/// Callback to draw gizmos only if the object is selected.
	/// </summary>
	void OnDrawGizmosSelected()
	{
		Gizmos.color=Color.red;
		Gizmos.DrawWireSphere(transform.position, range);	
	}
}
