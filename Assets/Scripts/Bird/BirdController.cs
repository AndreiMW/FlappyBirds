/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using Managers;
using UnityEngine;

namespace Scripts {
	public class BirdController : MonoBehaviour {
		[SerializeField]
		private int _jumpForce;
		
		private Rigidbody _rigidbody;
		private Vector3 _originalPos;
		private Quaternion _originalRot;
		
		#region Lifecycle

		private void Awake() {
			this._rigidbody = this.GetComponent<Rigidbody>();
			this._originalPos = this.transform.position;
			this._originalRot = this.transform.rotation;
			
			this.DisableGravity();
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				this._rigidbody.AddForce(Vector3.up * this._jumpForce, ForceMode.Impulse);
			}
		}

		#endregion
		
		#region Public

		public void Reset() {
			this._rigidbody.velocity = Vector3.zero;
			this._rigidbody.angularVelocity = Vector3.zero;
			this.transform.position = this._originalPos;
			this.transform.rotation = this._originalRot;
		}

		/// <summary>
		/// Enable gravity.
		/// </summary>
		public void EnableGravity() {
			this._rigidbody.useGravity = true;
		}

		/// <summary>
		/// Disable gravity.
		/// </summary>
		public void DisableGravity() {
			this._rigidbody.useGravity = false;
		}
		
		#endregion
		
		#region Collision

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Score")) {
				ScoreManager.Instance.AddScore();
			}
		}

		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.CompareTag("Pipe")) {
				GameManager.Instance.EndGame();
				ScoreManager.Instance.CompareCurrentScoreToHighScore();
			}
		}

		#endregion
	}
}