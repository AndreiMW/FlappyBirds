/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Bird {
	public class BirdSounds : MonoBehaviour {
		[SerializeField]
		private AudioClip _flyClip;
		
		[SerializeField]
		private AudioClip _hitClip;
		
		[SerializeField]
		private AudioClip _pointClip;

		[SerializeField]
		private AudioSource[] _audioSources;

		private Queue<AudioSource> _audioSourcesQueue;

		#region Lifecycle
		
		private void Awake() {
			this._audioSourcesQueue = new Queue<AudioSource>();
			if (this._audioSources.Length == 0) {
				return;
			}
			foreach (AudioSource audioSource in this._audioSources) {
				this._audioSourcesQueue.Enqueue(audioSource);
			}
		}
		
		#endregion
		
		#region Public

		/// <summary>
		/// Play fly sound effect.
		/// </summary>
		public void PlayFlyClip() {
			if (this._audioSources.Length == 0) {
				return;
			}
			
			AudioSource source = this.GetFreeAudioSource();
			source.clip = this._flyClip;
			source.Play();

			this.WaitForClipToEnd(source);
		}
		
		/// <summary>
		/// Play obstacle hit sound effect.
		/// </summary>
		public void PlayHitClip() {
			if (this._audioSources.Length == 0) {
				return;
			}
			
			AudioSource source = this.GetFreeAudioSource();
			source.clip = this._hitClip;
			source.Play();

			this.WaitForClipToEnd(source);
		}
		
		/// <summary>
		/// Play point gained sound effect.
		/// </summary>
		public void PlayPointClip() {
			if (this._audioSources.Length == 0) {
				return;
			}
			
			AudioSource source = this.GetFreeAudioSource();
			source.clip = this._pointClip;
			source.Play();
			
			this.WaitForClipToEnd(source);
			
		}
		
		#endregion
		
		#region Private

		private AudioSource GetFreeAudioSource() {
			return this._audioSourcesQueue.Dequeue();
		}

		private async void WaitForClipToEnd(AudioSource source) {
			float clipLength = source.clip.length;
			await Task.Delay(TimeSpan.FromSeconds(clipLength));
			this._audioSourcesQueue.Enqueue(source);
		}
		
		#endregion
	}
}