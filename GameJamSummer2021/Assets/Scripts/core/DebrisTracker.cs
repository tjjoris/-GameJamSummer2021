using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

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

        
        // void Start()
        // {
        //     ObjectsToTrack(debrisBasicParent);
        // }

        public DebrisEvent debrisEvent;
	
        private void Start()
        {
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
                    _list.Add(debrisEvent);
                    debrisEvent.DebrisDestroyedEvent += RegisterDebrisDestroyed;
                }
            }
        }
        
        private void RegisterDebrisDestroyed (object sender, EventArgs e)
        {
            Debug.Log("Debris Event Fired!");
            //UnSubscribe(sender);
        }
        
        
        private void UnSubscribe(DebrisEvent _debrisEvent)
        {
            //make sure to do this if script is ever removed
            //_debrisEvent.DebrisDestroyedEvent -= RegisterDebrisDestroyed;
        }
    }
}
