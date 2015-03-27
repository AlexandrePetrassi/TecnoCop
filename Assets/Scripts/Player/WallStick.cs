using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace PlayerControl{
		/// <summary>
		/// Wall Stick. Habilidade do personagem grudar em paredes
		/// </summary>
		public class WallStick : PlayerTrigger {
			
			public float slideSpeed = 0;
			public bool isWallSticking;
			
			protected override void continuous(){
				isWallSticking = !collision.feet.isColliding && collision.front.isColliding;
				if(isWallSticking){
					move.setVelocity_y(slideSpeed,1);
					move.toogleGravity(false);
				}
			}
			
			protected override void preStart(){
				isWallSticking = false;
				move.toogleGravity(true);
			}
			
			
		}
	}
}

