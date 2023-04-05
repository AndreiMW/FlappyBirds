/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using DG.Tweening;
using UnityEngine;

namespace UI {
	[RequireComponent(typeof(CanvasGroup))]
	public class BaseUIView : MonoBehaviour {
		private CanvasGroup _canvasGroupReference;
		private CanvasGroup _canvasGroup => this._canvasGroupReference ??= this.GetComponent<CanvasGroup>();

		public float Alpha {
			get => this._canvasGroup.alpha;
			set {
				this._canvasGroup.alpha = value;
				this._canvasGroup.interactable = value > 0f;
				this._canvasGroup.blocksRaycasts = value > 0f;
			}
		}

		public bool Interactable {
			get => this._canvasGroup.interactable;
			set => this._canvasGroup.interactable = value;
		}

		#region Public
		
		/// <summary>
		/// Fade in the view.
		/// </summary>
		/// <param name="duration">The duration of the fade.</param>
		/// <param name="completionCallback">What should this method do after completion.</param>
		public virtual void FadeInAnimation(float duration, Action completionCallback = null) {
			this._canvasGroup.DOFade(1f, duration).OnComplete(TriggerCallback);

			void TriggerCallback() {
				this._canvasGroup.interactable = true;
				this._canvasGroup.blocksRaycasts = true;
				completionCallback?.Invoke();
			}
		}

		/// <summary>
		/// Fade out the view.
		/// </summary>
		/// <param name="duration">The duration of the fade.</param>
		/// <param name="completionCallback">What should this method do after completion.</param>
		public virtual void FadeOutAnimation(float duration, Action completionCallback = null) {
			this._canvasGroup.DOFade(0f, duration).OnComplete(TriggerCallback);
			
			void TriggerCallback() {
				this._canvasGroup.interactable = false;
				this._canvasGroup.blocksRaycasts = false;
				completionCallback?.Invoke();
			}
		}

		/// <summary>
		/// Fade the view to a custom value.
		/// </summary>
		/// <param name="alpha">The alpha to fade to.</param>
		/// <param name="duration">The duration of the fade.</param>
		/// <param name="completionCallback">What should this method do after completion.</param>
		public void FadeAnimation(float alpha, float duration, Action completionCallback = null) {
			this._canvasGroup.DOFade(alpha, duration).OnComplete(TriggerCallback);
			
			void TriggerCallback() {
				this._canvasGroup.interactable = alpha > 0f;
				this._canvasGroup.blocksRaycasts = alpha > 0f;
				completionCallback?.Invoke();
			}
		}

		/// <summary>
		/// Scale in the view.
		/// </summary>
		/// <param name="duration">The duration of the scale.</param>
		/// <param name="completionCallback">What should this method do after completion.</param>
		public void ScaleInAniamation(float duration, Action completionCallback = null) {
			this._canvasGroup.transform.DOScale(1f, duration).OnComplete(TriggerCallback);
			
			void TriggerCallback() {
				completionCallback?.Invoke();
			}
		}
		
		/// <summary>
		/// Scale out the view.
		/// </summary>
		/// <param name="duration">The duration of the scale.</param>
		/// <param name="completionCallback">What should this method do after completion.</param>
		public void ScaleOutAniamation(float duration, Action completionCallback = null) {
			this._canvasGroup.transform.DOScale(0f, duration).OnComplete(TriggerCallback);
			
			void TriggerCallback() {
				completionCallback?.Invoke();
			}
		}
		
		/// <summary>
		/// Scale the view to a custom value.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="duration">The duration of the scale.</param>
		/// <param name="completionCallback">What should this method do after completion</param>
		public void ScaleAnimation(float value, float duration, Action completionCallback = null) {
			this._canvasGroup.transform.DOScale(value, duration).OnComplete(TriggerCallback);
			
			void TriggerCallback() {
				completionCallback?.Invoke();
			}
		}

		/// <summary>
		/// Fade and scale in at the same time the view.
		/// </summary>
		/// <param name="duration">The duration of the animation.</param>
		public void FadeAndScaleInAnimation(float duration) {
			this.FadeInAnimation(duration);
			this.ScaleInAniamation(duration);
		}
		
		/// <summary>
		/// Fade and scale out at the same time the view.
		/// </summary>
		/// <param name="duration">The duration of the animation.</param>
		public virtual void FadeAndScaleOutAnimation(float duration, Action completionCallback = null) {
			this.FadeOutAnimation(duration);
			this.ScaleOutAniamation(duration, completionCallback);
		}
		
		#endregion
	}
}