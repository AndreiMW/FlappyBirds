/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UnityEngine;

namespace UI.Score {
	public class ScoreModel {
		private const string HIGHSCORE_KEY = "HighScore";
		private ScorePresenter _scorePresenter;
		
		private int _currentScore;
		public int CurrentScore => this._currentScore;
		
		private int _currentHighScore;
		public ScoreModel(ScorePresenter presenter) {
			this._scorePresenter = presenter;
			this._currentHighScore = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
			this._scorePresenter.UpdateHighScore(this._currentHighScore);
		}

		#region Public

		/// <summary>
		/// Add to the score and update UI.
		/// </summary>
		public void AddScore() {
			this._currentScore++;
			this._scorePresenter.UpdateCurrentScore(this._currentScore);
		}

		/// <summary>
		/// Reset the score and the UI.
		/// </summary>
		public void ResetScore() {
			this._currentScore = 0;
			this._scorePresenter.ResetCurrentScoreDisplay();
		}

		/// <summary>
		/// Compare current score with highscore.
		/// </summary>
		public void CompareCurrentScoreWithHighscore() {
			if (this._currentScore > this._currentHighScore) {
				this._currentHighScore = this._currentScore;
				PlayerPrefs.SetInt(HIGHSCORE_KEY, this._currentHighScore);
			}
		}

		#endregion
	}
}