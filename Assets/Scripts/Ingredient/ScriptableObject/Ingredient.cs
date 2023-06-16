using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Ingredient.Enum;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "ScriptableObjects/Ingredient")]
public class Ingredient : ScriptableObject
{
    public eIngredientType ingredientType;
    public Sprite ingredientSprite;
}
