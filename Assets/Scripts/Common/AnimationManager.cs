﻿using UnityEngine;
using System.Collections;
using TecnoCop.Collisions;
using TecnoCop.PlayerControl;

namespace TecnoCop{
	/// <summary>
	/// Animation manager.
	/// Gerencia as flags de animaçao do personagem e o "espelhamento" das sprites
	/// </summary>
	public class AnimationManager : ModuleManager, IUpdatable {
		
		public void update(){
			setLookingDirection();
			setAnimationFlags();
		}
		
		/// <summary>
		/// Espelha a sprite do personagem toda vez que o sentido da velocidade horizontal muda
		/// </summary>
		void setLookingDirection(){
			if((ribo.velocity.x < 0 && transform.localScale.x > 0) || (ribo.velocity.x > 0 && transform.localScale.x < 0))
				transform.localScale =  new Vector3(transform.localScale.x *-1,transform.localScale.y,transform.localScale.z);
		}

		/// <summary>
		/// Atualiza as Flags das animaçoes
		/// </summary>
		protected virtual void setAnimationFlags(){}
	}
}
