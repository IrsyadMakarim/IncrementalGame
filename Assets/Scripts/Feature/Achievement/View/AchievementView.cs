using UnityEngine;
using UnityEngine.UI;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private Transform _popUpTransform;
    [SerializeField] private Text _popUpText;
    [SerializeField] private float _popUpShowDuration = 3f;

    private AchievementController _achievementController;

    public void InitializeController(AchievementController achievementController)
    {
        _achievementController = achievementController;
    }
    public void ShowAchivementPopUp(AchievementModel achievement)
    {
        _popUpText.text = achievement.Title;
        _achievementController.PopUpShowDurationCounter = _popUpShowDuration;
        _popUpTransform.localScale = Vector2.right;
    }

    public void ShowDurationCounter()
    {
        if (_achievementController.PopUpShowDurationCounter > 0)
        {
            _achievementController.PopUpShowDurationCounter -= Time.unscaledDeltaTime;
            _popUpTransform.localScale = Vector3.LerpUnclamped(_popUpTransform.localScale, Vector3.one, 0.5f);
        }
        else
        {
            _popUpTransform.localScale = Vector2.LerpUnclamped(_popUpTransform.localScale, Vector3.right, 0.5f);
        }
    }
}