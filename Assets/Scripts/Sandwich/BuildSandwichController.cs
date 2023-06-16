using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class BuildSandwichController : MonoBehaviour
{
    [Header("TopBum")]
    [SerializeField] private Transform _topBum;
    [SerializeField] private Vector3 _topBumIncrease;
    private Vector3 _originalTopBum;
    //Instead of being a SpriteRenderer Array, this could be changed for a system that instantiates a generic prefab that is assigned it's ingredient.
    //This prefab solution would work better on a more generic system where the amount of ingredients is larger or not of a fixed size.
    //Since the amount is fixed, going for a more simple way.
    [Header("SandwichArray")]
    [SerializeField] private SpriteRenderer[] _ingredientSprites = new SpriteRenderer[3];

    private Sandwich _sandwich;
    private Ingredient[] _addedIngredients = new Ingredient[3];

    private Animator _sandwichAnimator;
    private const string FINISHED_SANDWICH = "a_FinishedSandwich";

    private int ingredientAmount = 0;

    //Using event to prevent cyclical vartiable reference(Not having to reference Sandwich Manager)
    public delegate void NewSandwich(Ingredient[] addedIngredients);
    public event NewSandwich NewSandwichEvent;

    private void Start()
    {
        _sandwichAnimator = GetComponent<Animator>();
        _originalTopBum = _topBum.localPosition;
    }

    public void SetNewSandwich(Sandwich newSandwich)
    {
        _sandwich = newSandwich;
    }

    public void ReceiveIngredient(Ingredient ingredient)
    {
        //Case check for clicking before finished sandwich finishes playing
        if (ingredientAmount >= 3)
        {
            return;
        }
        _addedIngredients[ingredientAmount] = ingredient;
        AddIngredientSprite(ingredient.ingredientSprite);
        ingredientAmount++;
        _topBum.localPosition += _topBumIncrease;
        if (ingredientAmount >= 3)
        {
            _sandwichAnimator.Play(FINISHED_SANDWICH);
        }
    }

    //Calling this through animation event
    private void FinishedSandwich()
    {
        NewSandwichEvent(_addedIngredients);
        ingredientAmount = 0;
        Array.Clear(_addedIngredients, 0, _addedIngredients.Length);
        ResetIngredientsSprites();
    }

    private void AddIngredientSprite(Sprite ingredientSprite)
    {
        _ingredientSprites[ingredientAmount].sprite = ingredientSprite;
        _ingredientSprites[ingredientAmount].enabled = true;
    }

    private void ResetIngredientsSprites()
    {
        foreach(SpriteRenderer spriteRenderer in _ingredientSprites)
        {
            spriteRenderer.enabled = false;
        }
        _topBum.localPosition = _originalTopBum;
    }
}
