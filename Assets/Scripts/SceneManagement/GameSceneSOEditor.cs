#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;

namespace BrainlessPet.Scriptables
{
    public abstract partial class GameSceneSO : ScriptableObject, ISerializationCallbackReceiver
    {
        // This is second part of implementation of GameSceneSO
        // This part is reponsible for the editor-related functionality
        public static Action<GameSceneSO> onEnabled;

        private SceneAsset prevSceneAsset;

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            PopulateScenePath();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        { }

        private void OnEnable()
        {
            // In case domain was not reloaded after entering play mode
            prevSceneAsset = null;
            PopulateScenePath();
            onEnabled?.Invoke(this);
        }

        private void PopulateScenePath()
        {
            if (sceneAsset != null)
            {
                if (prevSceneAsset != sceneAsset)
                {
                    prevSceneAsset = sceneAsset;
                    scenePath = AssetDatabase.GetAssetPath(sceneAsset);
                }
            }
            else
            {
                scenePath = string.Empty;
            }
        }
    }
}
#endif

