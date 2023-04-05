/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using System.Globalization;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Obstacle {
	public class ObstacleGroup : MonoBehaviour {
		private bool _shouldMove;
		private Vector3 _spawnPoint;
		public event Action<ObstacleGroup> OnOutOfBounds;
		
		#region Lifecycle
		
		private void FixedUpdate() {
			if (this._shouldMove) {
				this.transform.position += Vector3.right * -4f * Time.fixedDeltaTime;	
			}
		}
		
		#endregion

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
			float randomY = Random.Range(-1f, 2f);
			this.transform.position += Vector3.up * randomY;
		}
		
		/// <summary>
		/// Reset to original position.
		/// </summary>
		public void ResetPosition() {
			this.transform.position = this._spawnPoint;
		}
		
		/// <summary>
		/// Enable moving for the group.
		/// </summary>
		public void EnableMove() {
			this._shouldMove = true;
		}

		/// <summary>
		/// Disable moving for the group.
		/// </summary>
		public void DisableMove() {
			this._shouldMove = false;
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
