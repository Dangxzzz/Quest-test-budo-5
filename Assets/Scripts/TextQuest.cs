using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextQuest : MonoBehaviour
{
    #region Variables

    public TMP_Text AnswersLabel;
    public Image BackGround;
    public TMP_Text DescriptionLabel;
    public Image LevelImage;
    public TMP_Text LevelNameLabel;
    public int NeedScore;

    public Level StartLevel;

    private Level _currentLevel;

    private readonly KeyCode[] _inputKeys =
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6,
        KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9,
    };
    
    private readonly int _offset = 48;

    private int _score;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _currentLevel = StartLevel;
        UpdateUi();
    }

    private void Update()
    {
        for (int i = 0; i < _inputKeys.Length; i++)
        {
            if (IsNextLevelExist() && Input.GetKeyDown(_inputKeys[i]))
            {
                int answer = Convert.ToInt32(_inputKeys[i]);
                Debug.Log(answer - _offset);
                CheckAnswer(answer);
            }
        }
    }

    private void CheckAnswer(int answer)
    {
        if (answer - _offset == _currentLevel.RightAnswer)
        {
            _score++;
            BackGround.color = Color.green;
        }
        else
        {
            BackGround.color = Color.red;
        }
    }

    #endregion

    #region Public methods

    public void FinishPressed()
    {
        if (IsNextLevelExist())
        {
            _currentLevel = _currentLevel.NextLevels[_currentLevel.NextLevels.Length - 1];
            UpdateUi();
        }
    }

    public void NextPressed()
    {
        if (IsNextLevelExist())
        {
            _currentLevel = GetNextLevel();
            UpdateUi();
        }
    }

    #endregion

    #region Private methods

    private Level GetNextLevel()
    {
        return _currentLevel.NextLevels[0];
    }

    private bool IsNextLevelExist()
    {
        return _currentLevel.NextLevels.Length != 0;
    }

    private void UpdateUi()
    {
        BackGround.color = Color.gray;
        LevelNameLabel.text = _currentLevel.Name;
        AnswersLabel.text = _currentLevel.Answers;
        LevelImage.sprite = _currentLevel.SpriteLevel;
        if (_currentLevel.NextLevels.Length == 0)
        {
            if (_score >= NeedScore)
            {
                DescriptionLabel.text = $"You win! Your score {_score}";
            }
            else
            {
                DescriptionLabel.text = $"You lose( Your score {_score}";
            }
        }
        else
        {
            DescriptionLabel.text = _currentLevel.Description;
        }
    }

    #endregion
}