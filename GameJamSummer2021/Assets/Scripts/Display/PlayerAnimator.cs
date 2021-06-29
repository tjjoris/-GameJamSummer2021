using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Display
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;

        public void InputLeft(bool _result)
        {
            playerAnimator.SetBool("RotLeft", _result);
        }

        public void InputRight(bool _result)
        {
            playerAnimator.SetBool("RotRight", _result);
        }

        public void InputUp(bool _result)
        {
            playerAnimator.SetBool("Thruster", _result);
        }
    }
}
