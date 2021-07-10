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

        void Awake()
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

            reverseBool = InputToReverse();
            bool forwardBool = false;
            if (!reverseBool)
            {
                forwardBool = InputToForward();
                InputToLeft();
                InputToRight();
                SendRotation();

            }
            if (!reverseBool && !forwardBool)
            {
                mover.Accelerate(false);
            }

            
            SpaceKey();

            EquipAbility00();
            EquipAbility01();
            EquipAbility02();
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
        private bool InputToForward()
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                mover.Accelerate(true);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void InputToLeft()
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                rotateLeft = true;
            }
            else
            {
                rotateLeft = false;
            }
        }
        private void InputToRight()
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                rotateRight = true;
            }
            else
            {
                rotateRight = false;
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
                return false;
            }
        }
        private bool InputToReverse()
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                rotateLeft = false;
                rotateRight = false;
                reverse.ReverseFunction();
                return true;
            }
            else
            {
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

        private void EquipAbility00()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                abilityManager.EquipAbility00();
            }
        }

        private void EquipAbility01()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                abilityManager.EquipAbility01();
            }
        }
        private void EquipAbility02()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                abilityManager.EquipAbility02();
            }
        }

        public void PlayerControlsLocked(bool _state)
        {
            launchBomb.LauncherEnabled(!_state);
            playerLocked = _state;
            mover.Rotate(0);
            mover.Accelerate(false);
        }
    }
}
