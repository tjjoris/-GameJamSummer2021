using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape
{
    public class BombExplosion : MonoBehaviour
    {
        private bool bigExplosion;
        [SerializeField] private bool thisIsBigExplosion;
        //private CircleCollider2D collider2D;
        void Start()
        {
            Destroy(gameObject, 0.2f);
            //collider2D = GetComponent<CircleCollider2D>();
            //if (collider2D.IsTouchingLayers(LayerMask.GetMask("Debris")))
            //{
            //    Debug.Log("collided with debris111");
            //}
            //collider2D.
        }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.layer == LayerMask.GetMask("Debris"))
        //    {
        //        Debug.Log("collision from on trigger enter");
        //    }
        //}
        //private void OnCollisionStay2D(Collision2D collision)
        //{
        //    //if (collision.gameObject.layer == LayerMask.GetMask("Debris"))
        //    {
        //        Debug.Log("collision stay");
        //    }
        //}
        private void OnTriggerStay2D(Collider2D collision)
        {

            RedBarrel redBarrel = collision.gameObject.GetComponent<RedBarrel>();
            if (redBarrel != null)
            {
                bigExplosion = true;
                redBarrel.RedBarrelTriggered();
                
            }
            Debris debris = collision.gameObject.GetComponent<Debris>();
            if (debris != null)
            {
                //Destroy(collision.gameObject);
                debris.HitByBomb(thisIsBigExplosion);
                Destroy(gameObject);

            }

        }

    }
}
