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

namespace UI {
	public class PauseMenuView : BaseUIView {
		[SerializeField]
		private Button _resumeButton;
		
		[SerializeField]
		private Button _mainMenuButton;

		public event Action ShowMainMenu;
		
		#region Lifecycle

		private void Awake() {
			this.Alpha = 0f;
			this._resumeButton.onClick.AddListener(this.ResumeListener);
			this._mainMenuButton.onClick.AddListener(this.MainMenuListener);
		}

		#endregion
		
		#region Public

		/// <summary>
		/// Show the pause view.
		/// </summary>
		public void Show() {
			this.Alpha = 1f;
		}
		
		#endregion
		
		#region Private

		private void ResumeListener() {
			GameManager.Instance.Resume();
			this.FadeOutAnimation(0.2f);
		}

		private void MainMenuListener() {
			this.ShowMainMenu?.Invoke();
			this.FadeOutAnimation(0.2f);
		}

		#endregion
	}
}