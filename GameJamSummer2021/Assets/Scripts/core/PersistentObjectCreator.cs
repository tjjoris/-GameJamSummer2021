using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Core
{
    public class PersistentObjectCreator : MonoBehaviour
    {
        static int numberOfPersistentGO = 0;
        [SerializeField] GameObject persistentPrefab;
        
        void Awake()
        {
            if (numberOfPersistentGO == 0)
            {
                GameObject persistentGO = Instantiate(persistentPrefab, transform.position, transform.rotation);
                DontDestroyOnLoad(persistentGO);
                numberOfPersistentGO++;
            }
        }
    }
}
