using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Movement;
using FreeEscape.Display;

namespace FreeEscape.Control
{
    public class PlayerInput : MonoBehaviour
    {
        private Mover mover;
        private LaunchBomb launchBomb;
        private AbilityManager abilityManager;
        private Reverse reverse;
        private bool rotateRight;
        private bool rotateLeft;
        private bool reverseBool;
        private bool playerLocked = true;

        void Start()
        {
            mover = GetComponent<Mover>();
            launchBomb = GetComponent<LaunchBomb>();
            abilityManager = GetComponent<AbilityManager>();
            reverse = GetComponent<Reverse>();
        }


        void Update()
        {
            if (playerLocked == true)
            {
                return;
            }

            reverseBool = ReverseKey();
            bool forwardBool = false;
            if (!reverseBool)
            {
                forwardBool = ForwardKey();
                LeftKey();
                RightKey();
                SendRotation();

            }
            if (!reverseBool && !forwardBool)
            {
                mover.Accelerate(false);
            }

            
            SpaceKey();

            EquipPrevAbility();
            EquipNextAbility();
            EquipProximityBomb();
        }

        private bool ForwardKey()
        {
            if (Input.GetKey(KeyCode.W))
            {
                mover.Accelerate(true);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void LeftKey()
        {
            if (Input.GetKey(KeyCode.A))
            {
                rotateLeft = true;
            }
            else
            {
                rotateLeft = false;
            }
        }
        private void RightKey()
        {
            if (Input.GetKey(KeyCode.D))
            {
                rotateRight = true;
            }
            else
            {
                rotateRight = false;
            }
        }
        private bool ReverseKey()
        {
            if (Input.GetKey(KeyCode.S))
            {
                rotateLeft = false;
                rotateRight = false;
                reverse.ReverseFunction();
                return true;
            }
            else
            {
                //reverseBool = false;
                return false;
            }
        }
        private void SendRotation()
        {
            if (rotateLeft && rotateRight || !rotateLeft && !rotateRight)
            {
                mover.Rotate(0);
            }
            else if (rotateLeft)
            {
                mover.Rotate(1);
            }
            else if (rotateRight)
            {
                mover.Rotate(-1);
            }
        }
        private void SpaceKey()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                launchBomb.LaunchBombAction();
            }
        }

        private void EquipPrevAbility()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                abilityManager.EquipPrevAbility();
            }
        }

        private void EquipNextAbility()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                abilityManager.EquipNextAbility();
            }
        }
        private void EquipProximityBomb()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                abilityManager.EquipProximityBomb();
            }
        }

        public void PlayerControlsLocked()
        {
            playerLocked = true;
        }

        public void PlayerControlsUnlocked()
        {
            playerLocked = false;
        }
    }
}
