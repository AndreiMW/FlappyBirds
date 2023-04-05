/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
	[SerializeField]
	private Transform _firstSegment;
	
	[SerializeField]
	private Transform _secondSegment;
	
	[SerializeField]
	private Transform _outOfBoundsPoint;

	private bool _shouldScroll;
	
	private Vector3 _resetPoint;
	
	#region Lifecycle

	private void Awake() {
		this._resetPoint = this._secondSegment.transform.position;
	}


	private void Update() {
		if (!this._shouldScroll) {
			return;
		}
		this._firstSegment.position += Vector3.left * 2f * Time.deltaTime;
		this._secondSegment.position += Vector3.left * 2f * Time.deltaTime;

		float distance = this._firstSegment.transform.position.x - this._outOfBoundsPoint.transform.position.x;
		
		if (distance <= 0) {
			this._firstSegment.transform.position = this._resetPoint;
		}

		distance = this._secondSegment.transform.position.x - this._outOfBoundsPoint.transform.position.x;
		
		if (distance <= 0) {
			this._secondSegment.transform.position = this._resetPoint;
		}
	}
	
	#endregion
	
	#region Public

	/// <summary>
	/// Enable the movement of the parralax background
	/// </summary>
	public void EnableMove() {
		this._shouldScroll = true;
	}

	/// <summary>
	/// Disable the movement of the parralax background
	/// </summary>
	public void DisableMove() {
		this._shouldScroll = false;
	}
	
	#endregion
}