/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu {
	public class MainMenuView : BaseUIView {
		[SerializeField]
		private Button _playButton;
		
		[SerializeField]
		private Button _exitButton;

		#region Lifecycle
		
		private void Awake() {
			this._playButton.onClick.AddListener(this.PlayButtonListener);
			this._exitButton.onClick.AddListener(this.ExitButtonListener);
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
		
		#endregion
	}
}