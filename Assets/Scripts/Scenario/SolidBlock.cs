using UnityEngine;
using System.Collections;
using TecnoCop.PlayerControl;

namespace TecnoCop{
	namespace Scenario{
		public class SolidBlock : Tile {

			public override void collideOnEnter(PlayerCollider playerCollider){
				playerCollider.isColliding = true;
			}

			public override void collideOnStay(PlayerCollider playerCollider){
				playerCollider.isColliding = true;
			}
		}
	}
}
