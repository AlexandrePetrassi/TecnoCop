using UnityEngine;
using System.Collections;


namespace TecnoCop{
	namespace PlayerControl{
		/// <summary>
		/// Dash 
		/// Controla a habilidade de Dash do jogador 
		/// </summary>
		[RequireComponent(typeof(TecnoCop.PlayerControl.Move))]
		public class Dash : PlayerTrigger {

			public float speedMultiplier = 2;
			[HideInInspector]public bool isDashing;

			protected override bool startCondition(){
				return !isDashing;
			}

			protected override void start_positive(){
				isDashing = true;
			}

			protected override void continuous(){
				if(isDashing) move.setVelocity_x(move.speed * speedMultiplier * Time.deltaTime * (transform.localScale.x>0?1:-1),1);
			}

			protected override void end(){
				isDashing = false;
			}
		}
	}
}
