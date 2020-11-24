using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[DisallowMultipleComponent]
public class LineFactory : MonoBehaviour
{
	[SerializeField] GameObject linePrefab;
	[SerializeField] bool enableLineLife;
	[SerializeField] bool isRunning;
	[SerializeField] Line currentLine;
	[SerializeField] Transform lineParent;
	[SerializeField] Image lineLife;

	RigidbodyType2D lineRigidBodyType = RigidbodyType2D.Kinematic;
	LineEnableMode lineEnableMode = LineEnableMode.ON_CREATE;
	
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			CreateNewLine ();
		} 
		else if (Input.GetMouseButtonUp (0))
		{
			RelaseCurrentLine ();
		}

		if (currentLine != null)
		{
			currentLine.AddPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition));
			UpdateLineLife ();
			if (currentLine.ReachedPointsLimit())
			{
				RelaseCurrentLine ();
			}
		}
	}

	private void CreateNewLine ()
	{
		currentLine = Instantiate (linePrefab, Vector3.zero, Quaternion.identity).GetComponent<Line> ();
		currentLine.transform.SetParent (lineParent);
		currentLine.SetRigidBodyType (lineRigidBodyType);

		if (lineEnableMode == LineEnableMode.ON_CREATE)
		{
			EnableLine ();
		}
	}

	private void EnableLine ()
	{
		currentLine.EnableCollider ();
		currentLine.SimulateRigidBody ();
	}

	private void RelaseCurrentLine ()
	{
		if (lineEnableMode == LineEnableMode.ON_RELASE)
		{
			EnableLine ();
		}

		currentLine = null;
	}

	private void UpdateLineLife ()
	{
		if (!enableLineLife)
		{
			return;
		}

		if (lineLife == null)
		{
			return;
		}

		lineLife.fillAmount = 1 - (currentLine.points.Count / currentLine.maxPoints);
	}

	public enum LineEnableMode
	{
		ON_CREATE,
		ON_RELASE}

	;
}
