/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using UI;
using UI.DeathScreen;
using UI.MainMenu;
using UnityEngine;
using UnityEngine.UI;

namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_Instance;
		public static UIManager Instance => s_Instance ??= FindObjectOfType<UIManager>();

		[SerializeField]
		private MainMenuView _mainMenuView;
		
		[SerializeField]
		private DeathScreenView _deathScreenView;

		[SerializeField]
		private CountDownView _countDownView;

		[SerializeField]
		private Button _pauseButton;

		[SerializeField]
		private PauseMenuView _pauseMenu;

		#region Lifecycle

		private void Awake() {
			this._pauseButton.onClick.AddListener(this.PauseButtonListener);
			this._pauseMenu.ShowMainMenu += this.HandleShowMainMenu;
		}

		#endregion
		
		#region Public
		
		/// <summary>
		/// Show the death screen.
		/// </summary>
		public void ShowDeathScreen(int highScore) {
			this._deathScreenView.Show(highScore);
		}

		/// <summary>
		/// Show the pause button.
		/// </summary>
		public void ShowPauseButton() {
			this._pauseButton.gameObject.SetActive(true);	
		}
		
		/// <summary>
		/// Hide the pause button.
		/// </summary>
		public void HidePauseButton() {
			this._pauseButton.gameObject.SetActive(false);	
		}

		/// <summary>
		/// Start the resume countdown sequence.
		/// </summary>
		/// <param name="completionCallback">The completion callback.</param>
		public void StartResumeCountdown(Action completionCallback = null) {
			this._countDownView.StartCountdown(completionCallback);
		}
		
		#endregion

		#region Private

		private void HandleShowMainMenu() {
			GameManager.Instance.ResumeOnlyWithTimeScale();
			GameManager.Instance.ResetGameWithoutStarting();
			this._mainMenuView.Show();
			this.HidePauseButton();
		}

		private void PauseButtonListener() {
			this._pauseMenu.Show();
			this.HidePauseButton();
			GameManager.Instance.Pause();
		}

		#endregion
	}
}