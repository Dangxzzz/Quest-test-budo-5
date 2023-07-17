using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    #region Variables

    public Button StartMenu;
    public TextMeshProUGUI RightAnswersLabel;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        if (Scenes.RightAnswers >= 5)
        {
            RightAnswersLabel.text = $" You win! RightAnswers:{Scenes.RightAnswers}";
        }
        else
        {
            RightAnswersLabel.text = $" You lose! RightAnswers:{Scenes.RightAnswers}";
        }
        StartMenu.onClick.AddListener(OnStartMenuClick);
    }

    #endregion

    #region Private methods

    private void OnStartMenuClick()
    {
        SceneManager.LoadScene(Scenes.StartScene);
    }

    #endregion
}