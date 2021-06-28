using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public class LaunchBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bombPrefab;
        private Rigidbody2D rigidbody2D;
        private float reverseVelocity = 100f;
        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        public void LaunchBombAction()
        {
            GameObject bomb = Instantiate(bombPrefab, transform.position, transform.rotation);
            Vector2 shipVelocity = rigidbody2D.velocity;
            Vector2 reverseV2 = new Vector2(0, -reverseVelocity);
            bomb.GetComponent<Rigidbody2D>().AddRelativeForce(reverseV2);
            bomb.GetComponent<Rigidbody2D>().velocity = shipVelocity;
        }
    }
}
