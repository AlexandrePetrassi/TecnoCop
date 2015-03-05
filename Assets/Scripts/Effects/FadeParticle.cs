using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace Effects{
		public class FadeParticle : MonoBehaviour {

			public float lifetime;

			// Use this for initialization
			void Start () {
				Destroy(gameObject,lifetime);
			}
		}
	}
}
