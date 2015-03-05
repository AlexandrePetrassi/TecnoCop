using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace PlayerControl{
		public class Player : PlayerBehaviour {
			
			/// <summary>
			/// Awake this instance.
			/// </summary>
			void Awake () {
				player = this;
			}
			
			/// <summary>
			/// Update this instance.
			/// </summary>
			void FixedUpdate () {
				foreach(PlayerUpdateable updateable in updateables)
					updateable.update();
			}
			
		}
	}
}