using UnityEngine;
using System;
using System.Collections.Generic;

namespace BrainlessPet.Actions
{
    public class RegisterActions : MonoBehaviour
    {
        /*[SerializeField] private ScriptableActions actionToRegister;
        private IActionListener listener;
        private void Awake() 
        {
            listener = GetComponent<IActionListener>();
        }
        private void OnEnable() => actionToRegister.genericAction += OnActionRaised;
        private void OnDisable() => actionToRegister.genericAction -= OnActionRaised;

        protected virtual void OnActionRaised()
        {
            //if (listener == null) return;

            listener.ActionRaised();
        }*/

        [SerializeField] private List<MultipleRegistrys> listnerToRegister;

        private void OnEnable() => listnerToRegister.ForEach(l => {l.Register(); Debug.Log($"{l} register");});

        private void OnDisable() => listnerToRegister.ForEach(l => l.Register());
    }

    [Serializable]
    public class MultipleRegistrys
    {
        public ScriptableActions actionToRegister;
        public bool isActionWithParameter;
        public UnityEngine.Object scriptListener;

        public void Register()
        {
            if (isActionWithParameter)
            {
                RegisterFloat();
            }
            actionToRegister.genericAction += OnActionRaised; Debug.Log(actionToRegister.name);

        }
         public void RegisterFloat()  
         {
            ScriptableActionsFloat actionFloatToRegister = actionToRegister as ScriptableActionsFloat;
            actionFloatToRegister.genericAction += OnActionRaised; Debug.Log(actionToRegister.name);
        }
        public void Deregister() => actionToRegister.genericAction -= OnActionRaised;
        public void OnActionRaised()
        {
            Debug.Log("Raise");
            IActionListener listener = scriptListener as IActionListener;
            listener.ActionRaised();
        }
        public void OnActionRaised(float data)
        {
            Debug.Log("Raise data");
            IActionListener<float> listener = scriptListener as IActionListener<float>;
            listener.ActionRaised(data);
        }
    }
}

