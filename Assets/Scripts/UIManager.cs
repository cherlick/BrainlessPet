using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrainlessPet.Tools;
using TMPro;
using System;

namespace BrainlessPet.Core.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject uiPanel;
        [SerializeField] private TextMeshProUGUI uiCountDown;
        [SerializeField] private GameObject menuPanel;

        private void Awake() 
        {
            DisablePanels();
        }

        private void OnEnable() 
        {
           
        }

        private void OnDisable() 
        {

            
        }

        public void SetCountDown(float countDown)
        {
            if (uiCountDown == null || !uiPanel.activeSelf) return;

            float minutes = Mathf.FloorToInt(countDown / 60);  
            float seconds = Mathf.FloorToInt(countDown % 60);
            uiCountDown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void DisablePanels()
        {
            if (uiPanel != null)
            {
                uiPanel?.SetActive(false);
            }
            if (menuPanel != null)
            {
                menuPanel?.SetActive(false);
            }
            
        }

        

    }
}

