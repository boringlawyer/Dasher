using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Caleb Katzenstein
// Dasher
public class CameraFollow : MonoBehaviour 
{
	[SerializeField] Transform player;
	// distance this from the player by a set amount in the -z direction
	void Update()
	{
		transform.position = player.position + Vector3.forward * -10;
	}
}
