/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UI.Score;
using UnityEngine;

namespace Managers {
	public class ScoreManager : MonoBehaviour {
		private static ScoreManager s_Instance;
		public static ScoreManager Instance => s_Instance ??= FindObjectOfType<ScoreManager>();

		[SerializeField]
		private ScorePresenter _scorePresenter;

		private ScoreModel _scoreModel;
		
		#region Lifecycle

		private void Awake() {
			this._scoreModel = new ScoreModel(this._scorePresenter);
		}

		#endregion
		
		#region Public

		/// <summary>
		/// Add to the score.
		/// </summary>
		public void AddScore() {
			this._scoreModel.AddScore();
		}

		/// <summary>
		/// Compare current score with highscore.
		/// </summary>
		public void CompareCurrentScoreToHighScore() {
			this._scoreModel.CompareCurrentScoreWithHighscore();
			this._scoreModel.ResetScore();
		}

		/// <summary>
		/// Get the current score.
		/// </summary>
		/// <returns>The current score.</returns>
		public int GetCurrentScore() {
			return this._scoreModel.CurrentScore;
		}
		
		#endregion
	}
}