using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Bomb
{
    public class BombShredder : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
            {
            BombProperties bombProperties = collision.gameObject.GetComponent<BombProperties>();
            if (bombProperties != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
