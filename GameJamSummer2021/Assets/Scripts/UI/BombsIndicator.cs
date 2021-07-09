using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.UI
{
    public class BombsIndicator : MonoBehaviour
    {
        int numberOfbombtypes;
        [SerializeField] BombIcon[] bombIcon;

        private void Start()
        {
            numberOfbombtypes = FindObjectsOfType<BombIcon>().Length;
        }
        public void SetBombActive(int bombIndex)
        {
            for (int i = 0; i < numberOfbombtypes; i++)
            {
                if (bombIndex != i)
                {
                    bombIcon[i].BombUnarmed();
                }
                else
                {
                    bombIcon[i].BombActive();
                }
            }
        }
        public void ShowAmmo(int bombIndex, int newAmmo)
        {
            bombIcon[bombIndex].ShowAmmo(newAmmo);
        }

    }
}
