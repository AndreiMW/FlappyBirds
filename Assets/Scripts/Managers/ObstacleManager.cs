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

	
		private void Awake() {
			InvokeRepeating(nameof(this.GetObstacle),0f,2f);
		}

		private void GetObstacle() {
			ObstacleGroup obstacleGroup = this._obstaclePool.Get();
			obstacleGroup.OnOutOfBounds += Listener;

			void Listener(ObstacleGroup group) {
				this._obstaclePool.Return(group);
				obstacleGroup.OnOutOfBounds -= Listener;
			}
		}
	}
}
