using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TecnoCop.Scenario;

/// <summary>
/// CollisionManager
/// Gerencia a colisao do personagem com objetos do cenario
/// </summary>
namespace TecnoCop{
	namespace PlayerControl{
		public class CollisionManager : PlayerModule {

			public PlayerCollider feet;   // Usado para detectar colisoes com o chao
			public PlayerCollider head;   // Usado para detectar colisoes com o teto
			public PlayerCollider front;  // Usado para detectar colisoes com paredes

			public Vector3 feetPosition;  // Posiçao dos pes do personagem
			public Vector3 headPosition;  // Posiçao da cabeça do personagem
			public Vector3 frontPosition; // posiçao do collider frontal do personagem

			public Vector2 feetSize;      // Tamanho do collider dos pes
			public Vector2 headSize;      // Tamanho do collider da cabeça
			public Vector2 frontSize;     // Tamanho do collider do front

			void Start(){
				feet  = makeCollider("Feet" ,feetPosition,feetSize);
				head  = makeCollider("Head" ,headPosition,headSize);
				front = makeCollider("Front",frontPosition,frontSize);
			}

			public override void update(){
				feet.isColliding  = false;
				head.isColliding  = false;
				front.isColliding = false;
			}

			private PlayerCollider makeCollider(string name, Vector3 position, Vector2 size){
				GameObject collider = new GameObject();
				collider.name = name;
				collider.transform.position = transform.position + position;
				collider.transform.parent =  transform;
				BoxCollider2D boxCollider = collider.AddComponent<BoxCollider2D>();
				boxCollider.size = size;
				boxCollider.isTrigger = true;
				return collider.AddComponent<PlayerCollider>();
			}
		}
	}
}
