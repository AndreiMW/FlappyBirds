/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using Obstacle;
using Pool;
using UnityEngine;

public class ObstaclePool : ObjectPool<ObstacleGroup> {
	[SerializeField]
	private ObstacleGroup _obstaclePrefab;

	[SerializeField]
	private Transform _obstacleSpawnPoint;
	
	protected override ObstacleGroup CreatePooled() {
		ObstacleGroup obstacleGroup = GameObject.Instantiate(this._obstaclePrefab);
		obstacleGroup.Init(this._obstacleSpawnPoint.transform.position);
		obstacleGroup.gameObject.SetActive(false);
		
		return obstacleGroup;
	}

	protected override void OnGet(ObstacleGroup pooled) {
		pooled.AddRandomY();
		pooled.gameObject.SetActive(true);
	}

	protected override void OnReturn(ObstacleGroup pooled) {
		pooled.ResetPosition();
		pooled.gameObject.SetActive(false);
	}
}