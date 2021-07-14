using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Control;

namespace FreeEscape
{
    public static class Factory
    {
        [SerializeField] private static GameObject persistentObjectPrefab;
        public static GameObject testObj;
        public static GameObject CreatePersistentObject()
        {
            return persistentObjectPrefab;
        }
    }
}
