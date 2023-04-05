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
		
		#endregion

		#region Private

		private void HandleShowMainMenu() {
			GameManager.Instance.Resume();
			GameManager.Instance.ResetGameWithoutStarting();
			this._mainMenuView.Show();
		}

		private void PauseButtonListener() {
			this._pauseMenu.Show();
			GameManager.Instance.Pause();
		}

		#endregion
	}
}