using UnityEngine;
using System.Collections;
using BrainlessPet.Scriptables;
namespace BrainlessPet.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float startingLevelDelayInSeconds;
        [SerializeField] private BoolReference isLevelReady;
        [SerializeField] private WaitForSeconds delayInSeconds = new WaitForSeconds(1);
        [SerializeField] private VoidEventChannelSO OnSceneReady;
        [SerializeField] private VoidEventChannelSO onDeathChannel;
        [SerializeField] private VoidEventChannelSO onNextLevelChannel;
        [SerializeField] private FloatEventChannelSO onCountUpdate;
        private float countTime;

        private void Start() 
        {
            isLevelReady.Variable.Value = false;
            countTime = startingLevelDelayInSeconds;
        }
        private void OnEnable() 
        {
            onDeathChannel.OnEventRaised += ResetIsLevelReady;
            onNextLevelChannel.OnEventRaised += ResetIsLevelReady;
            OnSceneReady.OnEventRaised += StartTheDelayCount;
        }

        private void OnDisable() 
        {
            onDeathChannel.OnEventRaised -= ResetIsLevelReady;
            onNextLevelChannel.OnEventRaised -= ResetIsLevelReady;
            OnSceneReady.OnEventRaised -= StartTheDelayCount;
        }
        
        private void StartTheDelayCount()
        {
            
            StartCoroutine(StartDelay());
        }

        private IEnumerator StartDelay()
        {
            onCountUpdate.RaiseEvent(countTime);
            while (countTime > 0)
            {
                
                yield return delayInSeconds;
                countTime -= 1;
                onCountUpdate.RaiseEvent(countTime);
            }
            
           isLevelReady.Variable.Value = true;
        }

        private void ResetIsLevelReady()
        {
            countTime = startingLevelDelayInSeconds;
            isLevelReady.Variable.Value = false;
        } 
    }
}