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

		private void Update() {
			if (Input.GetKeyDown(KeyCode.A)) {
				this.ResetGame();
			}
		}

		public void StartGame() {
			this._obstacleManager.StartSpawningObstacles();
			this._birdController.EnableGravity();
		}

		public void EndGame() {
			this._obstacleManager.StopSpawningObstacles();
			this._birdController.DisableGravity();
			UIManager.Instance.ShowDeathScreen(ScoreManager.Instance.GetCurrentScore());
		}

		public void ResetGame() {
			this._birdController.Reset();
			this.StartGame();
		}
		
	}
}