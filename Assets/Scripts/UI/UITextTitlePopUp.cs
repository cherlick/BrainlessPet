using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrainlessPet.Core.UI
{
    public class UITextTitlePopUp : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textLevelName;
        [SerializeField] private TextMeshProUGUI textLevelDescription;
        [SerializeField] private Animator animator;

        private void Start() 
        {
            textLevelName.gameObject.SetActive(false);
            textLevelDescription.gameObject.SetActive(false);
        }

        public void UpdateText(string levelName, string levelDescription)
        {
            textLevelName.text = levelName.Replace("_", " ");
            textLevelDescription.text = levelDescription;
        }
        public void ShowTitle()
        {
            animator.SetTrigger("TitlePopUp");
        }
    }
}

