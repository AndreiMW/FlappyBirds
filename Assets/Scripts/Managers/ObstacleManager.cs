using System;
using System.Collections.Generic;
using Obstacle;
using UnityEngine;

/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

namespace Managers {
	public class ObstacleManager : MonoBehaviour {
		[SerializeField]
		private ObstaclePool _obstaclePool;

		private List<ObstacleGroup> _currentActiveObstacles;

		[SerializeField]
		private float _timeBetweenObstacles = 2f;

		private float _timeToNextObstacle;
		
		private bool _shouldSpawnObstacles;

		private void Awake() {
			this._currentActiveObstacles = new List<ObstacleGroup>();
			this._timeToNextObstacle = this._timeBetweenObstacles;
		}

		private void Update() {
			if (!this._shouldSpawnObstacles) {
				return;
			}
			this._timeToNextObstacle -= Time.deltaTime;
			if (this._timeToNextObstacle <= 0) {
				this.GetObstacle();
				this._timeToNextObstacle = this._timeBetweenObstacles;
			}
		}

		public void StartSpawningObstacles() {
			this._shouldSpawnObstacles = true;
			foreach (ObstacleGroup currentActiveObstacle in this._currentActiveObstacles) {
				this._obstaclePool.Return(currentActiveObstacle);
			}
			this._currentActiveObstacles.Clear();
		}

		public void StopSpawningObstacles() {
			this._shouldSpawnObstacles = false;
			foreach (ObstacleGroup activeObstacle in this._currentActiveObstacles) {
				activeObstacle.DisableMove();	
			}
		}

		private void GetObstacle() {
			ObstacleGroup obstacleGroup = this._obstaclePool.Get();
			this._currentActiveObstacles.Add(obstacleGroup);
			obstacleGroup.OnOutOfBounds += Listener;
			obstacleGroup.EnableMove();

			void Listener(ObstacleGroup group) {
				this._currentActiveObstacles.Remove(group);
				this._obstaclePool.Return(group);
				obstacleGroup.OnOutOfBounds -= Listener;
			}
		}
	}
}
