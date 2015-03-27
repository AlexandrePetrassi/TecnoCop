using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace PlayerControl{
		public class Knockback : PlayerTrigger, IUpdatable {
			public float multiplier = 0; // Multiplicador do Knockback. Pode ser usado para diminuir a intensidade caso os valores estejam entre 0 e 1;
			private float power     = 0; // Força de Knockback que sera aplicada a este personagem
			private float endTime   = 0; // Momento no tempo em que o Knockback acabarah
			private float startTime = 0; // Momento no tempo em que o Knockback iniciou

			protected override bool startCondition(){
				return (power > 0 && endTime > Time.time);
			}

			protected override void start(){
				applyKnockback();
			}

			protected override void continuous(){
				applyKnockback();
			}
			
			public void receiveKnockback(float power,float time){
				this.power = power;
				this.endTime = time + Time.time;
				this.startTime = Time.time;
			}

			private void applyKnockback(){
				move.setVelocity_x(Mathf.Lerp(power*multiplier,0,lerpTime()),3);
			}

			private float lerpTime(){
				return (Time.time - startTime) / (endTime - startTime);
			}
		}
	}
}

