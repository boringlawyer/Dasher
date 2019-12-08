using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Caleb Katzenstein
// Dasher
// Allows the player to Dash
public class Dash : MonoBehaviour 
{
	[SerializeField]float dashDistance = 5;
	bool isOnPlatform = true;
	[SerializeField] float speed;
    // measures how many dashes have occurred since the last time the player
    // landed on a platform
    float numTimesDashedWithoutLanding = 0;
    int numDashesWithoutLandingAllowed = 1;
    SpriteRenderer renderer;
    public Trail trail;
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update () 
	{
        // lmb triggers dash
        if (Input.GetMouseButtonDown(0))
		{
            ++numTimesDashedWithoutLanding;
            // if the player is blue, they cannot dash until they are red
            renderer.color = Color.blue;
            // checks to see if this is already moving before dashing again
            if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
			{
				StartCoroutine(Move(MousePos.MousePosition));
			}
			// interrupt current dash, start new dash
			else
			{
				StopAllCoroutines();
				StartCoroutine(Move(MousePos.MousePosition));
			}
		}
        else if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            renderer.color = Color.red;
            numTimesDashedWithoutLanding = 0;
        }
		// end game if player is not visible
		if (!GetComponent<Renderer>().isVisible)
		{
			// There was a glitch where this was invisible in the beginning, this fixes that
			if (Time.timeSinceLevelLoad > .5)
			{
				EventSystem.GameOver(ReasonForDying.Reason.FellOffScreen);
			}
		}
	}
	// Handles the "dash"
	IEnumerator Move(Vector3 location)
	{
        // stop being attached to platforms when moving
		if (transform.parent != null)
		{
			transform.parent.DetachChildren();
		}
		Vector3 oldPosition = transform.position;
		Vector3 velocityHeading = (location - oldPosition).normalized;
		float sqrDistanceToTravel = Vector3.SqrMagnitude(location - oldPosition);
		// move to position until distance diminishes to a certain point
		while (Vector3.Distance(transform.position, location) > .1f)
		{
            if (numTimesDashedWithoutLanding > numDashesWithoutLandingAllowed)
            {
                EventSystem.GameOver(ReasonForDying.Reason.TooManyClicks);
            }
            GetComponent<Rigidbody2D>().velocity = velocityHeading * speed;
			if (Vector3.SqrMagnitude(transform.position - oldPosition) > sqrDistanceToTravel)
			{
				break;
			}
            Trail trailInstance = Instantiate(trail, transform.position, Quaternion.identity);
            trailInstance.spriteColor = renderer.color;
			yield return null;
		}
		// stop movement
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// end game if player did not land on platform
		if (!isOnPlatform)
		{
			EventSystem.GameOver(ReasonForDying.Reason.Abyss);
		}
	}
	// ends game if this hits an obstacle
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Obstacle"))
		{
			EventSystem.GameOver(ReasonForDying.Reason.HitObstacle);
		}
        else if (other.CompareTag("Platform"))
        {
            numTimesDashedWithoutLanding = 0;
            renderer.color = Color.red;
        }
    }
	// stays on a platform if this lands on it, leaves the platform when it dashes off of it
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Platform"))
		{
			isOnPlatform = true;
			if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
			{
                transform.parent = other.transform;
			}
			else
			{
				if (transform.parent != null)
				{
					transform.parent.DetachChildren();
				}
			}
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Platform"))
		{
			isOnPlatform = false;
		}
	}
}
