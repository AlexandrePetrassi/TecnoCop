using UnityEngine;
using System.Collections;
using TecnoCop.Scenario;

/// <summary>
/// PlayerCollider
/// Controla os subColliders do personagem
/// </summary>
namespace TecnoCop{
	namespace PlayerControl{
		public class PlayerCollider : MonoBehaviour {
			private bool wasColliding;
			public bool isColliding;

			void OnTriggerEnter2D(Collider2D collider){
				Collideable script = collider.GetComponent<Collideable>();
				if(script != null) script.collideOnEnter(this);
			}
			
			void OnTriggerStay2D(Collider2D collider){
				Collideable script = collider.GetComponent<Collideable>();
				if(script != null) script.collideOnStay(this);
			}
			
			void OnTriggerExit2D(Collider2D collider){
				Collideable script = collider.GetComponent<Collideable>();
				if(script != null) script.collideOnExit(this);
			}
		}
	}
}
