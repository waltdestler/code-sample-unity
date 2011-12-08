﻿using System.Collections;
using UnityEngine;

public class PositionAction : MonoBehaviour
{
	public Vector3 StartPos;
	public Vector3 EndPos;
	public float Duration = 1;
	public float Delay = 0;
	public AnimationCurve Curve = AnimationCurve.Linear(0, 0, 1, 1);

	private bool _running;

	public void DoActivateTrigger()
	{
		if(!_running)
			StartCoroutine(RunAction());
	}

	private IEnumerator RunAction()
	{
		_running = true;
		yield return new WaitForSeconds(Delay);
		float startTime = Time.time;
		do
		{
			yield return 0;
			float t = Curve.Evaluate((Time.time - startTime) / Duration);
			transform.position = Vector3.Lerp(StartPos, EndPos, t);
		}
		while(Time.time - startTime <= Duration);
		_running = false;
	}
}