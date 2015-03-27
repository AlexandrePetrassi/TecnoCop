using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TecnoCop.Collisions;

namespace TecnoCop{
	namespace PlayerControl{

		[RequireComponent(typeof(Player))]
		[RequireComponent(typeof(PlayerCollisionManager))]
		[RequireComponent(typeof(PlayerAnimationManager))]
		
		/// <summary>
		/// Player behaviour.
		/// Gerencia a interaçao entre os componentes do jogador, facilitando o acesso a diferentes modulos.
		/// </summary>
		public abstract class PlayerManager : ModuleManager {
			
			// triggerables
			static private Move             myMove;
			static private Jump             myJump;
			static private Dash             myDash;
			static private WallStick        myWall;
			static private WallJump     myWallJump;
			
			static public Move move{
				get{
					if(myMove == null)
						myMove = player.GetComponent<Move>();
					return myMove;
				}
				set{
					myMove = value;
				}
			}
			
			static public Jump jump{
				get{
					if(myJump == null)
						myJump = player.GetComponent<Jump>();
					return myJump;
				}
				set{
					myJump = value;
				}
			}
			
			static public WallStick wallStick{
				get{
					if(myWall == null)
						myWall = player.GetComponent<WallStick>();
					return myWall;
				}
				set{
					myWall = value;
				}
			}
			
			static public WallJump wallJump{
				get{
					if(myWallJump == null)
						myWallJump = player.GetComponent<WallJump>();
					return myWallJump;
				}
				set{
					myWallJump = value;
				}
			}
			
			static public Dash dash{
				get{
					if(myDash == null)
						myDash = player.GetComponent<Dash>();
					return myDash;
				}
				set{
					myDash = value;
				}
			}
		}
	}
}