using UnityEngine;
using System.Collections;

namespace TecnoCop{
	/// <summary>
	/// Damage.
	/// Representa uma quantidade de dano que um personagem recebe.
	/// Dano pode ser de varios tipos e eh alterado em base as resistencias do personagem que o recebe
	/// </summary>
	public class Damage {

		public float power = 0;
		public DamageType type = DamageType.none;

		public Damage(float power){
			this.power = power;
		}

		public Damage(float power, DamageType type):this(power){
			this.type = type;
		}
		
	}
	public enum DamageType{
		blunt,
		pierce,
		slash,
		heat,
		cold,
		eletric,
		acid,
		none
	}
}
