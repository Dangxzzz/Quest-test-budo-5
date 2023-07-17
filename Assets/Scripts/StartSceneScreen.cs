using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneScreen : MonoBehaviour
{
    #region Variables

    public Button StartGameButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        StartGameButton.onClick.AddListener(OnStartGameButtonClick);
    }

    #endregion

    #region Public methods

    public void OnStartGameButtonClick()
    {
        SceneManager.LoadScene(Scenes.GameScene);
    }

    #endregion
}