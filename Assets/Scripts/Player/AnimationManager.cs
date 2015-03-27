using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace PlayerControl{
		public class AnimationManager : PlayerModule {
			
			public override void update(){
				setLookingDirection();
				setAniamtionFlags();
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
			void setAniamtionFlags(){
				animator.SetInteger("SpeedX",(int)(ribo.velocity.x>0?1:(ribo.velocity.x<0?-2:0)));
				animator.SetInteger("SpeedY",(int)(ribo.velocity.y>0?1:(ribo.velocity.y<0?-2:0)));
				animator.SetBool("WallColliding",wallSticking!=null? wallSticking.isWallSticking: false);
				animator.SetBool("Dash",dash!=null? dash.isDashing: false);
				animator.SetBool("OnGround",collision.feet.isColliding);
			}
		}
	}
}
