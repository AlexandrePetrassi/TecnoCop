using UnityEngine;
using System.Collections;
using TecnoCop.PlayerControl;

namespace TecnoCop{
	namespace Effects{
		public class DashParticle : TransparentParticle {

			// Use this for initialization
			void Start () {
				spriteRenderer.sprite = ModuleManager.player.spriteRenderer.sprite;
				transform.position = ModuleManager.player.transform.position;
				transform.localScale = ModuleManager.player.transform.localScale;
				transform.rotation = ModuleManager.player.transform.rotation;
			}
		}
	}
}
