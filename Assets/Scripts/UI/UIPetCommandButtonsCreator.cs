using System.Collections.Generic;
using BrainlessPet.Characters.Pets;
using BrainlessPet.Scriptables;
using UnityEngine;

namespace BrainlessPet.UI
{
    public class UIPetCommandButtonsCreator : MonoBehaviour
    {
        [SerializeField] private UIPetCommand commandButtonprefab;
        [SerializeField] private LoadEventChannelSO onLevelLoaded;
        [SerializeField] private VoidEventChannelSO onLevelReady;
        private Dictionary<string, UIPetCommand> commandsCreated = new Dictionary<string, UIPetCommand>();
        private LevelSO currentLevel;

        private void OnEnable() 
        {
            if (onLevelLoaded != null)
            {
                onLevelLoaded.OnLoadingRequested += SetLevelDataUI;
            }

            if (onLevelReady != null)
            {
                onLevelReady.OnEventRaised += SetupLevelUI;
            }
        }

        private void SetLevelDataUI(GameSceneSO newScene, bool showLoadingScreen)
        {
            currentLevel = newScene as LevelSO;
            DisableAllButtons();
        }
        private void SetupLevelUI()
        {
             if (currentLevel != null)
            {
                currentLevel.levelData.petCommandsData.ForEach(command => CreateCommandUI(command));
            }
        }

        private void CreateCommandUI(PetCommandsData data)
        {
            if (commandsCreated.ContainsKey(data.commandType.name))
            {
                commandsCreated[data.commandType.name].gameObject.SetActive(true);
                commandsCreated[data.commandType.name].UpdateUsageWithDelay();
                return;
            } 

            var newButton = Instantiate(commandButtonprefab, transform);

            newButton.SetupUIButton(data.commandType.icon, data.commandType.commandTriggerChannel,
                data.commandType.commandSetupChannel, data.commandType.usageVariableReference
            );

            commandsCreated.Add(data.commandType.name, newButton);
        }

        private void DisableAllButtons()
        {
            foreach (var commandButton in commandsCreated)
            {
                commandButton.Value.gameObject.SetActive(false);
            }
        }
    }
}

