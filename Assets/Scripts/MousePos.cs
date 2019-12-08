using UnityEngine;
using System.Collections;
// Caleb Katzenstein
// Dasher
// determines the mouse position in game coordinates
public static class MousePos : object 
{
	public static Vector3 GetMousePos()
	{
		return Camera.main.ScreenPointToRay (Input.mousePosition).origin - new Vector3(0, 0, Camera.main.ScreenPointToRay(Input.mousePosition).origin.z);
	}
	
    public static Vector3 MousePosition
    {
        get
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition).origin - new Vector3(0, 0, Camera.main.ScreenPointToRay(Input.mousePosition).origin.z);
        }
    }	
}
