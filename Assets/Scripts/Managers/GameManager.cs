/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */


using System;
using Scripts;
using UnityEngine;

namespace Managers {
	public class GameManager : MonoBehaviour {
		private static GameManager s_instance;
		public static GameManager Instance => s_instance ??= FindObjectOfType<GameManager>();

		[SerializeField]
		private ObstacleManager _obstacleManager;

		[SerializeField]
		private BirdController _birdController;

		[SerializeField]
		private BackgroundScroll _backgroundScroll;

		private void Awake() {
			Application.targetFrameRate = 60;
		}

		public void StartGame() {
			this._obstacleManager.StartSpawningObstacles();
			this._birdController.EnableGravity();
			UIManager.Instance.ShowPauseButton();
			this._backgroundScroll.EnableMove();
		}

		public void EndGame() {
			this._obstacleManager.StopSpawningObstacles();
			this._birdController.DisableGravity();
			this._backgroundScroll.DisableMove();
			UIManager.Instance.ShowDeathScreen(ScoreManager.Instance.GetCurrentScore());
			UIManager.Instance.HidePauseButton();
		}

		public void ResetGame() {
			this.ResetGameWithoutStarting();
			this.StartGame();
		}

		public void ResetGameWithoutStarting() {
			this._backgroundScroll.DisableMove();
			this._birdController.Reset();
			this._obstacleManager.StopSpawningObstacles();
			this._birdController.DisableGravity();
		}

		/// <summary>
		/// Pause the game.
		/// </summary>
		public void Pause() {
			Time.timeScale = 0f;
		}

		/// <summary>
		/// Resume the game.
		/// </summary>
		public void Resume() {
			UIManager.Instance.StartResumeCountdown(() => {
				Time.timeScale = 1f;
				UIManager.Instance.ShowPauseButton();
			});
			
		}
		
	}
}