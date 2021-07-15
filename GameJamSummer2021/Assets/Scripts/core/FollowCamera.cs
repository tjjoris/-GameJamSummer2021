using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Core
{
    public class FollowCamera : MonoBehaviour
    {
        private GameObject player;
        private bool followPlayer = false;
        private Vector3 cameraOffset;
        // Start is called before the first frame update
        void Start()
        {
            cameraOffset = new Vector3(0, 0, -10f);
        }

        // Update is called once per frame
        void Update()
        {
            if (followPlayer)
            {
                transform.position = player.transform.position + cameraOffset;
            }
        }

        public void LockCameraToPlayer(GameObject _player)
        {
            player = _player;
            followPlayer = true;

        }
    }
}
