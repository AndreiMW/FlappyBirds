/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using UnityEngine;

namespace Scripts {
	public class BirdController : MonoBehaviour {
		[SerializeField]
		private int _jumpForce;
		
		private Rigidbody _rigidbody;
		
		#region Lifecycle

		private void Awake() {
			this._rigidbody = this.GetComponent<Rigidbody>();
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				this._rigidbody.AddForce(Vector3.up * this._jumpForce, ForceMode.Impulse);
			}
		}

		#endregion
	}
}