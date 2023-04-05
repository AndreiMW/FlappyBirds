/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu {
	public class MainMenuView : BaseUIView {
		[SerializeField]
		private Button _playButton;
		
		[SerializeField]
		private Button _exitButton;

		[SerializeField]
		private TMP_Text _highscore;

		

		#region Lifecycle
		
		private void Awake() {
			this._playButton.onClick.AddListener(this.PlayButtonListener);
			this._exitButton.onClick.AddListener(this.ExitButtonListener);
		}

		private void Start() {
			this.ShowHighscore();
		}
		
		#endregion
		
		#region Public
		
		/// <summary>
		/// Show the main menu.
		/// </summary>
		public void Show() {
			this.FadeInAnimation(0.2f);
			this.ShowHighscore();
		}
		
		#endregion
		
		#region Private

		private void PlayButtonListener() {
			GameManager.Instance.StartGame();
			this.FadeOutAnimation(0.2f);
		}

		private void ExitButtonListener() {
			Application.Quit();
		}

		private void ShowHighscore() {
			int currentHighscore = ScoreManager.Instance.GetCurrentHighscore();
			if (currentHighscore > 0) {
				string highscoreText = $"Highscore: {currentHighscore}";
				this._highscore.alpha = 1f;
				this._highscore.SetText(highscoreText);
			} else {
				this._highscore.alpha = 0f;
			}
		}
		
		#endregion
	}
}