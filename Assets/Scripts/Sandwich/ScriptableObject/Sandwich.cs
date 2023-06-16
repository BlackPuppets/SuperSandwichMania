using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sandwich", menuName = "ScriptableObjects/Sandwich")]
public class Sandwich : ScriptableObject
{
    public string sandwichName;
    public Sprite sandwichSprite;
    public Ingredient[] sandwichIngredients = new Ingredient[3];
    //Since it's a fixed amount of ingredients, using Array, if i wanted to change so that sandwichs amount of ingredients could be different from one another, this would be a List
}
