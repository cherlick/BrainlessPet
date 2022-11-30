using UnityEngine;
using BrainlessPet.Scriptables;
using TMPro;

namespace BrainlessPet.Core.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private VoidEventChannelSO OnPauseMenu;
        [SerializeField] private FloatEventChannelSO OnCountUpdate;
        [SerializeField] private LoadEventChannelSO OnLevelLoaded;
        [Header("UI Panels")]
        [SerializeField] private GameObject uiCommandsPanel;
        [SerializeField] private UITextTitlePopUp titleMenu;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private TextMeshProUGUI countLabel;

        private void Awake() 
        {
            DisablePanels();
            uiCommandsPanel.SetActive(true);
        }

        private void OnEnable() 
        {
            if (OnPauseMenu != null)
            {
                OnPauseMenu.OnEventRaised += OpenCloseMenuPanel;
            }
            if (OnLevelLoaded != null)
            {
                OnLevelLoaded.OnLoadingRequested += ShowTitle;
            }
            OnCountUpdate.OnEventRaised += UpdateCountPanel;
            
        }

        private void OnDisable() 
        {
            if (OnPauseMenu != null)
            {
                OnPauseMenu.OnEventRaised -= OpenCloseMenuPanel;
            }
            if (OnLevelLoaded != null)
            {
                OnLevelLoaded.OnLoadingRequested -= ShowTitle;
            }
            OnCountUpdate.OnEventRaised -= UpdateCountPanel;
        }
        
        private void OpenCloseMenuPanel()
        {
            if (menuPanel != null)
            {
                menuPanel!.SetActive(true);
            }
        }

        private void UpdateCountPanel(float updatedValue)
        {
            if (updatedValue > 0 )
            {
                if (!countLabel.isActiveAndEnabled)
                {
                    countLabel.gameObject.SetActive(true);
                }
                
                countLabel.text = updatedValue.ToString();

            }
            else
            {
                countLabel.gameObject.SetActive(false);
            }
        }

        private void ShowTitle(GameSceneSO levelSO, bool isToShowLoading)
        {
            titleMenu.UpdateText(levelSO.name, levelSO.shortDescription);
            titleMenu.ShowTitle();
        }

        private void DisablePanels()
        {
            countLabel.gameObject.SetActive(false);
            if (uiCommandsPanel != null)
            {
                uiCommandsPanel!.SetActive(false);
            }
            if (menuPanel != null)
            {
                menuPanel!.SetActive(false);
            }
        }
    }
}

