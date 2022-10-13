using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrainlessPet.Scriptables;
using TMPro;
using BrainlessPet.Characters.Pets;

namespace BrainlessPet.Core.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private VoidEventChannelSO OnPauseMenu;
        [Header("UI Panels")]
        [SerializeField] private GameObject uiCommandsPanel;
        [SerializeField] private TextMeshProUGUI uiCountDown;
        [SerializeField] private GameObject menuPanel;

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
        }

        private void OnDisable() 
        {
            if (OnPauseMenu != null)
            {
                OnPauseMenu.OnEventRaised -= OpenCloseMenuPanel;
            }
            
        }
        
        private void OpenCloseMenuPanel()
        {
            if (menuPanel != null)
            {
                menuPanel!.SetActive(true);
            }
        }

        public void SetCountDown(float countDown)
        {
            if (uiCountDown == null) return;

            float minutes = Mathf.FloorToInt(countDown / 60);  
            float seconds = Mathf.FloorToInt(countDown % 60);
            uiCountDown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void DisablePanels()
        {
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

