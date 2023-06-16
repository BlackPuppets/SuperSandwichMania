using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private CanvasGroup _ingredientsCanvasGroup;
    [SerializeField] private AudioClip _finishedGame;
    public void EndGame()
    {
        _endGameScreen.SetActive(true);
        _ingredientsCanvasGroup.interactable = false;
        AudioSource.PlayClipAtPoint(_finishedGame, Vector3.zero, 5f);
    }
    public void ChangeCurrentScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
