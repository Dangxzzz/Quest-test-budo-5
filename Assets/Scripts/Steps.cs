using UnityEngine;

public class Level : MonoBehaviour
{
    #region Variables

    [TextArea(4, 6)]
    public string Answers;
    [TextArea(4, 12)]
    public string Description;
    [TextArea(1, 12)]
    public string Name;

    public Level[] NextLevels;
    public int RightAnswer;
    public Sprite SpriteLevel;

    #endregion
}