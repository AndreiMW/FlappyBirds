/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;

using UnityEngine;

using Random = UnityEngine.Random;

namespace Obstacle {
	public class ObstacleGroup : MonoBehaviour {
		private Vector3 _spawnPoint;
		public event Action<ObstacleGroup> OnOutOfBounds;

		#region Public
	
		/// <summary>
		/// Initialize the obstacle group.
		/// </summary>
		/// <param name="spawnPos">The spawn position of the group.</param>
		public void Init(Vector3 spawnPos) {
			this.transform.position = spawnPos;
			this._spawnPoint = spawnPos;
		}

		/// <summary>
		/// Add random Y.
		/// </summary>
		public void AddRandomY() {
			float randomY = Random.Range(-1.3f, 1.3f);
			this.transform.position += Vector3.up * randomY;
		}
		
		/// <summary>
		/// Reset to original position.
		/// </summary>
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
