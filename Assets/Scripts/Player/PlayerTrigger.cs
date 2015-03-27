using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace PlayerControl{
		/// <summary>
		/// Player trigger. 
		/// Controla o disparo das açoes do jogador
		/// </summary>
		public abstract class PlayerTrigger : PlayerBehaviour, PlayerUpdateable {

			public TriggerAxis triggerAxis;   // Botao/Eixo usado para ativar o script
			public TriggerType triggerType;   // Modo de ativaçao do script (HoldKey, SingleTap, DoubleTap...)
			[HideInInspector]
			public TriggerEvent triggerEvent; // Metodo que sera executado neste frame (Começar a açao, cancelar a açao, etc)
			private bool myIsPressed;         // Checa se o botao esta precionado
			private bool myWasPressed;        // Checa se o botao estava pressionado na ultima iteraçao
			public float tapInterval;         // Tempo de tolerancia de um tap pro outro;

			void Awake(){
				updateables.Insert(0,this); // Adciona este script ao INICIO da lista de updateables
			}

			protected float getAxisValue(){
				switch(triggerAxis){
				case TriggerAxis.HorizontalAxis:
					return Input.GetAxisRaw("Horizontal");
				case TriggerAxis.Up:
					return Input.GetAxisRaw("Vertical");
				case TriggerAxis.Down:
					return Input.GetAxisRaw("Vertical");
				case TriggerAxis.Accept:
					return Input.GetAxisRaw("Accept");
				case TriggerAxis.Cancel:
					return Input.GetAxisRaw("Cancel");
				case TriggerAxis.Switch:
					return Input.GetAxisRaw("Switch");
				case TriggerAxis.Menu:
					return Input.GetAxisRaw("Menu");
				case TriggerAxis.Jump:
					return Input.GetAxisRaw("Jump");
				default:
					return 0;
				}
			}

			/// <summary>
			/// Checa se os botoes correspondentes ao trigger estao pressionados
			/// </summary>
			private bool isPressed(TriggerAxis triggerAxis){
				switch(triggerAxis){
				case TriggerAxis.HorizontalAxis:
					return Input.GetAxisRaw("Horizontal") != 0;
				case TriggerAxis.Up:
					return Input.GetAxisRaw("Vertical") > 0;
				case TriggerAxis.Down:
					return Input.GetAxisRaw("Vertical") < 0;
				default:
					return getAxisValue() != 0;
				}
			}

			/// <summary>
			/// Checa se os resitos de ativaçao deste trigger sao atingidos
			/// </summary>
			private bool isTriggered(){
				switch(triggerType){
				case TriggerType.HoldKey:
					return isTriggered_HoldKey();
				case TriggerType.SingleTap:
					return isTriggered_SingleTap();
				case TriggerType.DoubleTap:
					return isTriggered_DoubleTap();
				case TriggerType.TripleTap:
					return isTriggered_TripleTap();
				case TriggerType.ContinuousWhileTapping:
					return isTriggered_ContinuousWhileTapping();
				case TriggerType.ChargeAndRelease:
					return isTriggered_ChargeAndRelease();
				default:
					return true;
				}
			}

			private bool isTriggered_HoldKey(){
				return myIsPressed;
			}

			private bool isTriggered_SingleTap(){
				return true;
			}

			private bool isTriggered_DoubleTap(){
				return true;
			}

			private bool isTriggered_TripleTap(){
				return true;
			}

			private bool isTriggered_ContinuousWhileTapping(){
				return true;
			}

			private bool isTriggered_ChargeAndRelease(){
				return true;
			}

			/// <summary>
			/// Atualiza
			/// </summary>
			public virtual void update(){
				updateFlags();
				callEvent();
			}

			private void updateFlags(){
				myWasPressed = myIsPressed;
				myIsPressed = isPressed(triggerAxis);
			}

			private TriggerEvent getEvent(){
				if(myIsPressed  && !myWasPressed) return TriggerEvent.Start;
				if(myIsPressed  && myWasPressed)  return TriggerEvent.Continue;
				if(!myIsPressed && myWasPressed)  return TriggerEvent.End;
				if(!myIsPressed && !myWasPressed) return TriggerEvent.PostEnd;
				return TriggerEvent.none;
			}

			private void callEvent(){
				preStart();
				switch(getEvent()){
				case TriggerEvent.Start:
					start(); break;
				case TriggerEvent.Continue:
					continuous(); break;
				case TriggerEvent.End:
					end(); break;
				case TriggerEvent.PostEnd:
					postEnd(); break;
				default:
					break;
				}
			}

			/// <summary>
			/// Caso retorne false, interrompe o fluxo do trigger
			/// </summary>
			virtual protected void preStart(){} 

			/// <summary>
			/// Bifurca a chamada do metodo start em start_positive e start_negative
			/// </summary>
			private void start(){
				if(startCondition()) start_positive();
				else start_negative();
			}

			/// <summary>
			/// Condiçao utilizada para alternar entre start_positive e start_negative
			/// </summary>
			/// <returns><c>true</c>, Chama start_positive, <c>false</c> Chama start_negative.</returns>
			virtual protected bool startCondition(){return true;}

			virtual protected void start_positive(){}

			virtual protected void start_negative(){}

			virtual protected void continuous(){}

			virtual protected void end(){}
			
			virtual protected void postEnd(){}

		}

		public enum TriggerAxis{
			HorizontalAxis,
			Up,
			Down,
			Accept,
			Cancel,
			Switch,
			Menu,
			Jump,
			None
		}

		public enum TriggerType{
			HoldKey,
			SingleTap,
			DoubleTap,
			TripleTap,
			ContinuousWhileTapping,
			ChargeAndRelease,
			none
		}

		public enum TriggerEvent{
			none,
			Start,
			Continue,
			End,
			PostEnd
		}
	}
}