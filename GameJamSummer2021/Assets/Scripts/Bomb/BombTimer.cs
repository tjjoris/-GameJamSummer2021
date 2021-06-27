using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Bomb
{
    public class BombTimer : MonoBehaviour
    {
        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSecondsRealtime(5f);
            Detonate();
        }
        private void Detonate()
        {
            Destroy(gameObject);
        }
    }
}
