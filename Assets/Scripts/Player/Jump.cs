using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace PlayerControl{
		/// <summary>
		/// Player jump. 
		/// Controla a açao de salto do jogador
		/// </summary>
		public class Jump : PlayerTrigger {

			public int maxJump = 1;               // Quantidade de vezes que o jogador pode pular sem tocar o chao
			private int jumpCount;                // Quantidade de vezes que o jogador pulou. Nunca pode ultrapassar o valor de maxJump
			public float jumpPower;               // Intensidade do salto. Quanto maior o valor, mais alto o personagem pula.
			public GameObject doubleJumpParticle; // Objeto usado para o efeito de double Jump

			override protected bool startCondition(){
				if(!collision.feet.isColliding && jumpCount == 0) jumpCount = 1; // Considera como salto toda vez que o personagem sair de uma plataforma sem pular
				return jumpCount < maxJump;
			}

			/// <summary>
			/// Controla quando o jogador pode pular novamente
			/// </summary>
			override protected void preStart(){
				refreshJumpCount();
			}

			/// <summary>
			/// Inicia o Salto
			/// </summary>
			override protected void start_positive(){
				//ribo.velocity = new Vector2(ribo.velocity.x,jumpPower); 
				move.setVelocity_y(jumpPower,0);
				if(++jumpCount > 1) Instantiate(doubleJumpParticle,transform.position,Quaternion.identity); // Incrementa +1 no contador de pulos e instancia o efeito de DoubleJump
			}

			/// <summary>
			/// Cancela o salto caso ainda esteja sendo executado
			/// </summary>
			override protected void end(){
				if(ribo.velocity.y > 0)
					//ribo.velocity = new Vector2(ribo.velocity.x,0); 
					move.setVelocity_y(0,0);
			}

			/// <summary>
			/// Caso o personagem toque o chao, o contador de saltos eh resetado
			/// </summary>
			private void refreshJumpCount(){
				if(collision.feet.isColliding || (wallSticking!=null && wallSticking.isWallSticking))
					jumpCount = 0;
			}

			
		}
	}
}
