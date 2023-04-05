/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using TMPro;

using UnityEngine;

namespace UI.Score {
	public class ScorePresenter : MonoBehaviour {
		[SerializeField]
		private TMP_Text _currentScoreText;
		
		[SerializeField]
		private TMP_Text _highScoreText;
		
		#region Lifecycle

		private void Awake() {
			this.ResetCurrentScoreDisplay();
		}

		#endregion
		
		#region Public

		/// <summary>
		/// Update the current score UI.
		/// </summary>
		/// <param name="score">The current score int value.</param>
		public void UpdateCurrentScore(int score) {
			this._currentScoreText.SetText(score.ToString());
		}
		
		/// <summary>
		/// Update the highscore UI.
		/// </summary>
		/// <param name="score">The highscore score int value.</param>
		public void UpdateHighScore(int score) {
			this._highScoreText.SetText(score.ToString());
		}

		/// <summary>
		/// Reset the current score UI.
		/// </summary>
		public void ResetCurrentScoreDisplay() {
			this._currentScoreText.SetText("0");
		}
		
		#endregion
	}
}