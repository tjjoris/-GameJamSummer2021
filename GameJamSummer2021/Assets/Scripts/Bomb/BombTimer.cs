using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Bomb
{
    public class BombTimer : MonoBehaviour
    {
        [SerializeField] float timeTillExplode = 3.7f;
        [SerializeField] GameObject bombExplosionPrefab;
        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSecondsRealtime(timeTillExplode);
            Detonate();
        }
        private void Detonate()
        {
            Instantiate(bombExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
