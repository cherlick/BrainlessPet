using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrainlessPet.ScenesChangeSystem;
using BrainlessPet.Actions;

namespace BrainlessPet.Core
{
    public class GameManager : MonoBehaviour, IActionListener
    {
        public void ActionRaised()
        {
            RestartLevel();
        }

        private void RestartLevel() => ScenesManager.RestartScene();
    }
}