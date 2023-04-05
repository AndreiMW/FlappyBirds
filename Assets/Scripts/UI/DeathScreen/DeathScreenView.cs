/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DeathScreen {
	public class DeathScreenView : BaseUIView {
		[SerializeField]
		private Button _restartButton;

		[SerializeField]
		private TMP_Text _yourScoreText;
		
		#region Lifecycle

		private void Awake() {
			this.Alpha = 0f;
			this._restartButton.onClick.AddListener(this.ButtonListener);
		}

		/// <summary>
		/// Show the death screen.
		/// </summary>
		public void Show(int highscore) {
			string yourScore = $"Your score: {highscore}";
			this._yourScoreText.SetText(yourScore);
			this.FadeInAnimation(0.2f);
		}

		#endregion
		
		#region Private

		private void ButtonListener() {
			GameManager.Instance.ResetGame();
			this.FadeOutAnimation(0.2f);
		}
		
		#endregion
	}
}