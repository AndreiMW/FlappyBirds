using System;
using UnityEngine;

/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

public class ObstacleManager : MonoBehaviour {
	[SerializeField]
	private ObstaclePool _obstaclePool;

	
	private void Awake() {
		InvokeRepeating(nameof(this.GetObstacle),0f,2f);
	}

	private void GetObstacle() {
		this._obstaclePool.Get();
	}
}