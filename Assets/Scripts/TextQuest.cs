using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextQuest : MonoBehaviour
{
    #region Variables

    public Button Answer1;
    public Button Answer2;
    public Button Answer3;
    public Button Answer4;

    public Image BackGround;
    public TMP_Text DescriptionLabel;
    public int Health = 2;
    public TMP_Text HealthLabel;
    public Button HelpButton;
    public Image LevelImage;
    public TMP_Text LevelNameLabel;

    public LevelConfig startLevelConfig;

    private Button[] _buttons;

    private LevelConfig _currentLevelConfig;
    private bool _isButtonClick;

    private int _score;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _buttons = new[] { Answer1, Answer2, Answer3, Answer4 };
        _currentLevelConfig = startLevelConfig;
        UpdateUi();
        Answer1.onClick.AddListener(() => OnButtonClick(0));
        Answer2.onClick.AddListener(() => OnButtonClick(1));
        Answer3.onClick.AddListener(() => OnButtonClick(2));
        Answer4.onClick.AddListener(() => OnButtonClick(3));
        HelpButton.onClick.AddListener(OnButtonHelpClick);
    }

    private void Update()
    {
        if (Health <= 0)
        {
            SceneManager.LoadScene(Scenes.GameOverScene);
        }
    }

    #endregion

    #region Private methods

    private void CheckAnswer(string answer)
    {
        _isButtonClick = true;
        if (answer == _currentLevelConfig.RightAnswer)
        {
            BackGround.color = Color.green;
            Scenes.RightAnswers++;
        }
        else
        {
            Health--;
            BackGround.color = Color.red;
        }
    }

    private LevelConfig GetNextLevel()
    {
        return _currentLevelConfig.NextLevels[0];
    }

    private bool IsNextLevelExist()
    {
        return _currentLevelConfig.NextLevels.Length != 0;
    }

    private void OnButtonClick(int buttonIndex)
    {
        string answer = _buttons[buttonIndex].GetComponentInChildren<TextMeshProUGUI>().text;
        if (!IsNextLevelExist())
        {
            SceneManager.LoadScene(Scenes.GameOverScene);
        }
        else
        {
            if (!_isButtonClick)
            {
                CheckAnswer(answer);
                _currentLevelConfig = GetNextLevel();
            }

            Invoke("UpdateUi", 3f);
        }
    }

    private void OnButtonHelpClick()
    {
        int deletedButtons = 0;
        for (int i = 0; deletedButtons < _buttons.Length / 2; i++)
        {
            int deleteButton = Random.Range(0, 3);
            if (_buttons[deleteButton].GetComponentInChildren<TextMeshProUGUI>().text !=
                _currentLevelConfig.RightAnswer)
            {
                _buttons[deleteButton].gameObject.SetActive(false);
                deletedButtons++;
            }
        }
    }

    private void UpdateUi()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (!_buttons[i].IsActive())
            {
                _buttons[i].gameObject.SetActive(true);
            }
        }

        _isButtonClick = false;
        Answer1.GetComponentInChildren<TextMeshProUGUI>().text = _currentLevelConfig.Answer1;
        Answer2.GetComponentInChildren<TextMeshProUGUI>().text = _currentLevelConfig.Answer2;
        Answer3.GetComponentInChildren<TextMeshProUGUI>().text = _currentLevelConfig.Answer3;
        Answer4.GetComponentInChildren<TextMeshProUGUI>().text = _currentLevelConfig.Answer4;
        BackGround.color = Color.gray;
        LevelNameLabel.text = _currentLevelConfig.Name;
        LevelImage.sprite = _currentLevelConfig.SpriteLevel;
        DescriptionLabel.text = _currentLevelConfig.Description;
        HealthLabel.text = $"Health{Health}";
    }

    #endregion
}
