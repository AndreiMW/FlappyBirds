/**
 * Created Date: 4/5/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Avangarde Software. All rights reserved. 
 */

using UI.DeathScreen;
using UnityEngine;

namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_Instance;
		public static UIManager Instance => s_Instance ??= FindObjectOfType<UIManager>();
		
		[SerializeField]
		private DeathScreenView _deathScreenView;

		#region Public
		
		/// <summary>
		/// Show the death screen.
		/// </summary>
		public void ShowDeathScreen(int highScore) {
			this._deathScreenView.Show(highScore);
		}
		
		#endregion
	}
}