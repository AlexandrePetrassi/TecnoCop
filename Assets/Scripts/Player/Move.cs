using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace PlayerControl{
		/// <summary>
		/// Player move. 
		/// Controla o movimento horizontal do jogador
		/// </summary>
		public class Move : PlayerTrigger {
			
			public float speed;

			protected override void preStart(){
				ribo.velocity = new Vector2(speed * Time.deltaTime * getAxisValue(),ribo.velocity.y);
			}
		}
	}
}
