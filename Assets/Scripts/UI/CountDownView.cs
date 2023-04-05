/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using TMPro;
using UnityEngine;

namespace UI {
	public class CountDownView : BaseUIView {
		[SerializeField]
		private TMP_Text _text;

		private int _countdownValue = 3;

		private void Awake() {
			this.Alpha = 0f;
		}

		#region Public

		/// <summary>
		/// Start the resume countdown timer/
		/// </summary>
		/// <param name="countdownComplete">The action for countdown complete.</param>
		public void StartCountdown(Action countdownComplete = null) {
			if (this._countdownValue == 0) {
				this._countdownValue = 3;
				this._text.SetText(this._countdownValue.ToString());
				countdownComplete?.Invoke();
				return;
			}
			this.Alpha = 1f;
			this.transform.localScale = Vector3.one;
			this.FadeOutAnimation(1f, () => {
				this._countdownValue--;
				this._text.SetText(this._countdownValue.ToString());
				this.StartCountdown(countdownComplete);
			});
		}
		
		#endregion
	}
}