using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Core
{
    public class PersistentObjectCreator : MonoBehaviour
    {
        static int numberOfPersistentGO = 0;
        [SerializeField] GameObject persistentPrefab;
        // Start is called before the first frame update
        void Start()
        {
        if (numberOfPersistentGO == 0)
            {
                GameObject persistentGO = Instantiate(persistentPrefab, transform.position, transform.rotation);
                DontDestroyOnLoad(persistentGO);
                numberOfPersistentGO++;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
