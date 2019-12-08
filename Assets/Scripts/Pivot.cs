using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Caleb Katzenstein
// Dasher
// Used to rotate an entire level
public class Pivot : MonoBehaviour 
{
	[SerializeField] float speed;	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
