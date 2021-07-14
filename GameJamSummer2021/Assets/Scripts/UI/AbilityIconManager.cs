using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Control;

namespace FreeEscape.UI
{
    public class AbilityIconManager : MonoBehaviour
    {
        int numberOfbombtypes;
        [SerializeField] private GameObject abilityIconPrefab;
        [SerializeField] private AbilityManager abilityManager;
        [SerializeField] AbilityIcon[] bombIcon;
        private List<GameObject> abilityIcons = new List<GameObject>();

        private void Start()
        {
            numberOfbombtypes = FindObjectsOfType<AbilityIcon>().Length;
        }


        public void GenerateIcons(I_AbilityProperties abilityProperties)
        {
            GameObject iconObj = Instantiate(abilityIconPrefab, this.transform);
            abilityIcons.Add(iconObj);
            iconObj.GetComponent<AbilityIcon>().SetupAbilityIcon(abilityProperties);
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
