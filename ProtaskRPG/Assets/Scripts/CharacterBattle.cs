using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private CharacterBase characterBase;
    private void Awake()
    {
        characterBase.GetComponent<CharacterBase>();
    }
}
