/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using UnityEngine;

namespace Obstacle {
	public class ObstacleGroup : MonoBehaviour {
		private Vector3 _spawnPoint;
		public event Action<ObstacleGroup> OnOutOfBounds;

		#region Public
	
		public void Init(Vector3 spawnPos) {
			this.transform.position = spawnPos;
			this._spawnPoint = spawnPos;
		}

		public void ResetPosition() {
			this.transform.position = this._spawnPoint;
		}
	
		#endregion
		
		#region Collision

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag("ResetObstacle")) {
				this.OnOutOfBounds?.Invoke(this);
			}
		}
		
		#endregion
	}
}
