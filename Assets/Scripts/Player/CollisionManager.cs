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

			[HideInInspector]public PlayerCollider feet;   // Usado para detectar colisoes com o chao
			[HideInInspector]public PlayerCollider head;   // Usado para detectar colisoes com o teto
			[HideInInspector]public PlayerCollider front;  // Usado para detectar colisoes com paredes

			public Rect feetRect;  // Posiçao e tamanho dos pes do personagem
			public Rect headRect;  // Posiçao e tamanho da cabeça do personagem
			public Rect frontRect; // posiçao e tamanho do collider frontal do personagem

			void Start(){
				feet  = makeCollider("Feet" ,feetRect);
				head  = makeCollider("Head" ,headRect);
				front = makeCollider("Front",frontRect);
			}


			/// <summary>
			/// A cada frame torna false todas as flags de colisao. 
			/// Caso a colisao ainda esteja ocorrendo, a flag sera setada como true antes do fim do frame
			/// Senao a flag continua como false, identificando assim uma "nao-colisao".
			/// </summary>
			public override void update(){
				feet.isColliding  = false;
				head.isColliding  = false;
				front.isColliding = false;
			}

			/// <summary>
			/// Cria um collider para gerenciar colisoes em diferentes partes do corpo do personagem
			/// </summary>
			private PlayerCollider makeCollider(string name, Rect rect){
				GameObject collider = new GameObject();
				collider.name = name;
				Vector3 position = new Vector3(rect.x,rect.y);
				collider.transform.position = transform.position + position;
				collider.transform.parent = transform;
				BoxCollider2D boxCollider = collider.AddComponent<BoxCollider2D>();
				Vector2 size = new Vector2(rect.width,rect.height);
				boxCollider.size = size;
				boxCollider.isTrigger = true;
				return collider.AddComponent<PlayerCollider>();
			}
		}
	}
}
