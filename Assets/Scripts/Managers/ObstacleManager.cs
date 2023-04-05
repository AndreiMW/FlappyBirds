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

		private void Awake() {
			this._currentActiveObstacles = new List<ObstacleGroup>();
		}

		public void StartSpawningObstacles() {
			foreach (ObstacleGroup currentActiveObstacle in this._currentActiveObstacles) {
				this._obstaclePool.Return(currentActiveObstacle);
			}
			InvokeRepeating(nameof(this.GetObstacle), 0f, 2f);
		}

		public void StopSpawningObstacles() {
			CancelInvoke(nameof(this.GetObstacle));
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
