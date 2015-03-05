using UnityEngine;
using System.Collections;
using TecnoCop.PlayerControl;

namespace TecnoCop{
	namespace Scenario{
		public abstract class Collideable : MonoBehaviour {

			public virtual void collideOnEnter(PlayerCollider playerCollider){}

			public virtual void collideOnStay(PlayerCollider playerCollider){}

			public virtual void collideOnExit(PlayerCollider playerCollider){}
		}
	}
}
