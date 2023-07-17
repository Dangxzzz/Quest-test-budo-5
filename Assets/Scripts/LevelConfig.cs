using UnityEngine;

[CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "Configs/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    #region Variables

    public string Answer1;
    public string Answer2;
    public string Answer3;
    public string Answer4;

    [TextArea(4, 12)]
    public string Description;
    [TextArea(1, 12)]
    public string Name;

    public LevelConfig[] NextLevels;
    public string RightAnswer;
    public Sprite SpriteLevel;

    #endregion
}