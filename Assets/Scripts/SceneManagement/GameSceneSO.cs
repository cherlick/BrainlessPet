using UnityEngine;

namespace BrainlessPet.Scriptables
{
    public abstract partial class GameSceneSO : ScriptableObject
	{
		[Header("Information")]
	#if UNITY_EDITOR // See GameSceneSOEditor.cs
		public UnityEditor.SceneAsset sceneAsset;
	#endif
		[HideInInspector]
		public string scenePath;
		[TextArea] public string shortDescription;

		[Header("Sounds")]
		public AudioClip music;
	}
}

