using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public class LaunchBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bombPrefab;
        private Rigidbody2D rigidbody2D;
        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        public void LaunchBombAction()
        {
            GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            Vector2 shipVelocity = rigidbody2D.velocity;
            bomb.GetComponent<Rigidbody2D>().velocity = shipVelocity;
        }
    }
}
