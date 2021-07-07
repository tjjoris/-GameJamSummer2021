using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FreeEscape.Core
{
    public class DebrisTracker : MonoBehaviour
    {
        [SerializeField] private Transform debrisBasicParent;
        [SerializeField] private Transform debrisResistantParent;
        [SerializeField] private Transform specialDebrisParent;
        private List<DebrisEvent> debrisBasicList; //easily destroyed space rocks
        private List<DebrisEvent> debrisResistantList; //Harder to destroy debris such as spaceship parts
        private List<DebrisEvent> specialDebrisList; //Destructables with special behaviours, such as explosive ship reactor or corrosive alien eggs
        private int totalDebrisRemaining;
        [SerializeField] private TextMeshProUGUI debrisRemainingText;

        private DebrisEvent debrisEvent;
        public event EventHandler AllDebrisCleared;

        public void AlertEventWatchers()
        {
		    AllDebrisCleared?.Invoke(this, EventArgs.Empty);
        }
	
        public void TallyDebris()
        {
            totalDebrisRemaining = 0;

            debrisBasicList = new List<DebrisEvent>();
            debrisResistantList = new List<DebrisEvent>();
            specialDebrisList = new List<DebrisEvent>();

            HookupDebrisObjects(debrisBasicParent, debrisBasicList);
            HookupDebrisObjects(debrisResistantParent, debrisResistantList);
            HookupDebrisObjects(specialDebrisParent, specialDebrisList);
        }

        private void HookupDebrisObjects(Transform _parentObject, List<DebrisEvent> _list)
        {
            foreach (Transform debrisObj in _parentObject)
            {
                DebrisEvent debrisEvent = debrisObj.gameObject.GetComponent<DebrisEvent>();
                if (debrisEvent != null) 
                {
                    totalDebrisRemaining ++;
                    _list.Add(debrisEvent);
                    debrisEvent.DebrisDestroyedEvent += RegisterDebrisDestroyed;
                }

                UpdateDebrisText();
            }
        }

        private void UpdateDebrisText()
        {
            debrisRemainingText.text = "Debris Remaining: " + totalDebrisRemaining;
        }
        
        private void RegisterDebrisDestroyed (object sender, EventArgs e)
        {
            totalDebrisRemaining --;
            UpdateDebrisText();
            UnSubscribe((DebrisEvent)sender);

            if (totalDebrisRemaining <= 0)
            {
                AllDebrisCleared?.Invoke(this, EventArgs.Empty);
            }
        }
        
        
        private void UnSubscribe(DebrisEvent _debrisEvent)
        {
            //make sure to do this if script is ever removed
            _debrisEvent.DebrisDestroyedEvent -= RegisterDebrisDestroyed;
        }

        public void LevelCleared()
        {
            debrisRemainingText.text = "All Debris Destroyed, Great Job!";
        }

        public void HideText()
        {
            debrisRemainingText.gameObject.SetActive(false);
        }

        public void ShowText()
        {
            debrisRemainingText.gameObject.SetActive(true);
        }
    }
}
