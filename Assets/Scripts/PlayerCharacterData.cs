using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterData : MonoBehaviour
{
    public string chosenName;
    public string age;
    public string gender;
    public string sexuality;
    public string pronouns;

    public Mesh bodyType;
    public Color SkinColour;

    public Mesh hairstyle;
    public Color HairColour;

    public Mesh facialHairstyle;
    public Color facialHairColour;

    public string fear;
    public string hobby;
    public string faith;

    private void Update()
    {
        chosenName = name;
    }
}
