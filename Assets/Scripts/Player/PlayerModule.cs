using UnityEngine;
using System.Collections;
/// <summary>
/// Classe abstrada para diferenciar um modulo comum de um PlayerTrigger.
/// Esta classe define um modulo do jogador que NAO esta relacionado a input.
/// </summary>
namespace TecnoCop{
	namespace PlayerControl{
		public abstract class PlayerModule : PlayerBehaviour, PlayerUpdateable {

			void Awake(){
				updateables.Add(this); // Adciona este script ao FINAL da lista de updateables
			}

			public abstract void update();
		}
	}
}
