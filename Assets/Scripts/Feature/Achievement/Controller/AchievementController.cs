using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
    public AchievementView AchievementView;

    private static AchievementController _instance = null;
    public static AchievementController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<AchievementController>();
            }
            return _instance;
        }
    }

    [SerializeField] private List<AchievementModel> _achievementList;
    public float PopUpShowDurationCounter;

    private void Awake()
    {
        AchievementView.InitializeController(this);
    }
    // Update is called once per frame
    private void Update()
    {
        AchievementView.ShowDurationCounter();
    }

    public void UnlockAchievement(AchievementType type, string value)
    {
        AchievementModel achievement = _achievementList.Find(a => a.Type == type && a.Value == value);

        if (achievement != null && !achievement.IsUnlocked)
        {
            achievement.IsUnlocked = true;
            AchievementView.ShowAchivementPopUp(achievement);
        }
    }


}
