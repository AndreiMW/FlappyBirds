/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

namespace Obstacle {
	public class ObstacleMovement : MonoBehaviour {
		
		#region Lifecycle
		
		private void FixedUpdate() {
			this.transform.position += Vector3.right * -4f * Time.fixedDeltaTime;
		}
		
		#endregion
	}
}