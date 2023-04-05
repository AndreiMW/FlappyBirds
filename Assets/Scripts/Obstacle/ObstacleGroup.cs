/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

namespace Obstacle {
	public class ObstacleGroup : MonoBehaviour {
		private Vector3 _spawnPoint;

		#region Public
	
		public void Init(Vector3 spawnPos) {
			this.transform.position = spawnPos;
			this._spawnPoint = spawnPos;
		}

		public void ResetPosition() {
			this.transform.position = this._spawnPoint;
		}
	
		#endregion
	}
}
