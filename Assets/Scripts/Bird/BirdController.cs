/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using Managers;
using Scripts.Bird;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts {
	public class BirdController : MonoBehaviour {
		[SerializeField]
		private int _jumpForce;

		[SerializeField]
		private BirdSounds _birdSounds;

		private Rigidbody _rigidbody;
		private Vector3 _originalPos;
		private Quaternion _originalRot;

		private BoxCollider _collider;
		
		#region Lifecycle

		private void Awake() {
			this._rigidbody = this.GetComponent<Rigidbody>();
			this._collider = this.GetComponent<BoxCollider>();
			this._originalPos = this.transform.position;
			this._originalRot = this.transform.rotation;
			
			this.DisableGravity();
		}

		private void Update() {
			if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.IsPointerOverGameObject(0)) {
				return;
			} 
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
				this._rigidbody.AddForce(Vector3.up * this._jumpForce, ForceMode.Impulse);
				this._birdSounds.PlayFlyClip();
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
			this._rigidbody.isKinematic = false;
			this._collider.enabled = true;
		}

		/// <summary>
		/// Disable gravity.
		/// </summary>
		public void DisableGravity() {
			this._rigidbody.useGravity = false;
			this._rigidbody.isKinematic = true;
			this._collider.enabled = false;
		}
		
		#endregion
		
		#region Collision

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Score")) {
				ScoreManager.Instance.AddScore();
				this._birdSounds.PlayPointClip();
			}
		}

		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.CompareTag("Pipe")) {
				this._birdSounds.PlayHitClip();
				GameManager.Instance.EndGame();
				ScoreManager.Instance.CompareCurrentScoreToHighScore();
			}
		}

		#endregion
	}
}