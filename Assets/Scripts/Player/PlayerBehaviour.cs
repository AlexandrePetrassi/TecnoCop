using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TecnoCop{
	namespace PlayerControl{
		[RequireComponent(typeof(Rigidbody2D))]
		[RequireComponent(typeof(Animator))]
		[RequireComponent(typeof(AnimationManager))]
		[RequireComponent(typeof(CollisionManager))]
		[RequireComponent(typeof(Player))]

		/// <summary>
		/// Player behaviour.
		/// Gerencia a interaçao entre os componentes do jogador, facilitando o acesso a diferentes modulos.
		/// </summary>
		public abstract class PlayerBehaviour : MonoBehaviour {

			// not triggerables
			static private Player           myPlayer;
			static private Rigidbody2D      myRB;
			static private Animator         myAnim;
			static private AnimationManager myAnimMan; 
			static private CollisionManager myCollision;

			// triggerables
			static private Move             myMove;
			static private Jump             myJump;
			static private Dash             myDash;
			static private WallStick        myWall;

			static protected List<PlayerUpdateable> updateables = new List<PlayerUpdateable>();

			static public Player player{
				get{
					if(myPlayer == null)
						myPlayer = FindObjectOfType<Player>();
					return myPlayer;
				}
				set{
					myPlayer = value;
				}
			}

			static public Rigidbody2D ribo{
				get{
					if(myRB == null)
						myRB = myPlayer.GetComponent<Rigidbody2D>();
					return myRB;
				}
				set{
					myRB = value;
				}
			}

			static public Animator animator{
				get{
					if(myAnim == null)
						myAnim = myPlayer.GetComponent<Animator>();
					return myAnim;
				}
				set{
					myAnim = value;
				}
			}

			static public AnimationManager anim{
				get{
					if(myAnimMan == null)
						myAnimMan = myPlayer.GetComponent<AnimationManager>();
					return myAnimMan;
				}
				set{
					myAnimMan = value;
				}
			}

			static public CollisionManager collision{
				get{
					if(myCollision == null)
						myCollision = myPlayer.GetComponent<CollisionManager>();
					return myCollision;
				}
				set{
					myCollision = value;
				}
			}

			static public Move move{
				get{
					if(myMove == null)
						myMove = myPlayer.GetComponent<Move>();
					return myMove;
				}
				set{
					myMove = value;
				}
			}

			static public Jump jump{
				get{
					if(myJump == null)
						myJump = myPlayer.GetComponent<Jump>();
					return myJump;
				}
				set{
					myJump = value;
				}
			}

			static public WallStick wallSticking{
				get{
					if(myWall == null)
						myWall = myPlayer.GetComponent<WallStick>();
					return myWall;
				}
				set{
					myWall = value;
				}
			}

			static public Dash dash{
				get{
					if(myDash == null)
						myDash = myPlayer.GetComponent<Dash>();
					return myDash;
				}
				set{
					myDash = value;
				}
			}
			
		}
	}
}