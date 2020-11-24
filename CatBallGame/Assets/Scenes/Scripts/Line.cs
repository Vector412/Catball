using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LineRenderer))]
[DisallowMultipleComponent]
public class Line : MonoBehaviour
{
	[Range(0, 5000)]
	public List<Vector2> points;
	public float maxPoints;
	[SerializeField] float pointZPosition;
	[SerializeField] bool autoAddColliderPoint = true;
	
	
	 List<Vector2> polygon2DPoints;
	 LineRenderer lineRenderer;
	 PolygonCollider2D polygonCollider2D;
	 Rigidbody2D rigidBody2D;

	
	float pointMinOffset = 0.05f;
	static Vector2 tempVector;
    static Vector2 direction;
	static float angle;
	static float halfWidth;


	void Awake ()
	{
		points = new List<Vector2> ();
		polygon2DPoints = new List<Vector2> ();
		lineRenderer = GetComponent<LineRenderer> ();
		polygonCollider2D = GetComponent<PolygonCollider2D> ();
		rigidBody2D = GetComponent<Rigidbody2D> ();

		
		halfWidth = lineRenderer.endWidth / 2.0f;
	}

	
	public void AddPoint (Vector3 point)
	{
		if (points.Count > 1) 
		{
			if (Vector2.Distance (point, points [points.Count - 1]) < pointMinOffset)
			{
				Debug.Log(11);
				return;
			}
		}

		point.z = pointZPosition;
		points.Add (point);
        lineRenderer.positionCount++;
		lineRenderer.SetPosition (lineRenderer.positionCount - 1, point);

		if (autoAddColliderPoint)
		{
			AddPointToCollider (points.Count - 1);
		}
	}

	
	public void EnableCollider ()
	{
		polygonCollider2D.enabled = true;
	}
	
	
	public void DisableCollider ()
	{
		polygonCollider2D.enabled = false;
	}


	public void SetRigidBodyType(RigidbodyType2D type){
		rigidBody2D.bodyType = type;
	}


	public void SimulateRigidBody ()
	{
		rigidBody2D.simulated = true;
	}

	
	public bool ReachedPointsLimit(){
		return points.Count >= maxPoints;
	}

	public void AddPointToCollider (int index)
	{
		direction = points [index] - points [index + 1 < points.Count ? index + 1 : (index - 1 >= 0 ? index - 1 : index)];
		angle = Mathf.Atan2 (direction.x, -direction.y);

		tempVector = points [index];
		tempVector.x = tempVector.x + halfWidth * Mathf.Cos (angle);
		tempVector.y = tempVector.y + halfWidth * Mathf.Sin (angle);
		polygon2DPoints.Insert (polygon2DPoints.Count, tempVector);

		tempVector = points [index];
		tempVector.x = tempVector.x - halfWidth * Mathf.Cos (angle);
		tempVector.y = tempVector.y - halfWidth * Mathf.Sin (angle);
		polygon2DPoints.Insert (0, tempVector);

		polygonCollider2D.points = polygon2DPoints.ToArray ();
	}
}
