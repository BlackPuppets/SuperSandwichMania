using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SandwichManager : MonoBehaviour
{
    [Header("ObjectsReferences")]
    [SerializeField] private BuildSandwichController _buildSandwichController;
    [SerializeField] private Image _sandwichImage;
    [SerializeField] private TextMeshProUGUI _sandwichName;
    [SerializeField] private TextMeshProUGUI _ingredientName_1;
    [SerializeField] private TextMeshProUGUI _ingredientName_2;
    [SerializeField] private TextMeshProUGUI _ingredientName_3;
    [SerializeField] private PointsController _pointsController;
    [Header("SandwichList")]
    [SerializeField] private List<Sandwich> _sandwiches = new List<Sandwich>();
    [Header("Audio")]
    [SerializeField] private AudioClip _correctSandwich;
    [SerializeField] private AudioClip _wrongSandwich;

    private Sandwich currentSandwich;

    // Start is called before the first frame update
    void Awake()
    {
        _buildSandwichController.NewSandwichEvent += CheckSandwich;
        GenerateNewSandwich();
    }

    private void CheckSandwich(Ingredient[] addedIngredients)
    {
        foreach (Ingredient ingredient in currentSandwich.sandwichIngredients)
        {
            //If sandwich doesn't contain ingredient
            if (!addedIngredients.Contains(ingredient))
            {
                _pointsController.totalPoints += -100;
                AudioSource.PlayClipAtPoint(_wrongSandwich, Vector3.zero, 5f);
                return;
            }
            
        }
        _pointsController.totalPoints += 200;
        AudioSource.PlayClipAtPoint(_correctSandwich, Vector3.zero, 5f);
        GenerateNewSandwich();
    }

    private void GenerateNewSandwich()
    {
        currentSandwich = _sandwiches[Random.Range(0, _sandwiches.Count)];
        _buildSandwichController.SetNewSandwich(currentSandwich);
        SetSandwichUI();
    }

    private void SetSandwichUI()
    {
        _sandwichImage.sprite = currentSandwich.sandwichSprite;
        _sandwichName.text = currentSandwich.sandwichName;
        _ingredientName_1.text = currentSandwich.sandwichIngredients[0].ingredientType.ToString();
        _ingredientName_2.text = currentSandwich.sandwichIngredients[1].ingredientType.ToString();
        _ingredientName_3.text = currentSandwich.sandwichIngredients[2].ingredientType.ToString();
    }
}
