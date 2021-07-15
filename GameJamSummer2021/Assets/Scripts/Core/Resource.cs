using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private GameObject persistantPrefab;

        private static GameObject _instance;
        Resource(){}
        public static GameObject Instance
        {
            get
            {
                if (_instance == null)
                {
                    //_instance = CreateObj();
                }
                return _instance;
            }
        }
        private void CreateObject()
        {
            
        }

        private GameObject CreateObj()
        {
            GameObject _obj = Instantiate(persistantPrefab, transform.position, transform.rotation);
            return _obj;
        }
    }
}
