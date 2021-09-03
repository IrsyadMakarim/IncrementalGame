using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    public ResourceView ResourceView;
    private ResourceConfig _config;
    private int _level = 1;

    public bool IsUnlocked = false;

    private void Awake() 
    {
        ResourceView.InitalizeController(this);
    }
    public void SetConfig(ResourceConfig config)
    {
        _config = config;
        ResourceView.SetConfigName();
        SetUnlocked(_config.UnlockCost == 0);
    }

    public ResourceConfig GetConfig()
    {
        return _config;
    }

    public double GetOutput()
    {
        return _config.Output * _level;
    }

    public int GetLevel()
    {
        return _level;
    }

    public double GetUpgradeCost()
    {
        return _config.UpgradeCost * _level;
    }

    public double GetUnlockCost()
    {
        return _config.UnlockCost;
    }

    public void UpgradeLevel()
    {
        double upgradeCost = GetUpgradeCost();
        if (GameManager.Instance.TotalGold < upgradeCost)
        {
            return;
        }
        ResourceView.SetUpgradeLevelName();
        GameManager.Instance.AddGold(-upgradeCost);
        _level++;
    }

    public void UnlockResource()
    {
        double unlockCost = GetUnlockCost();
        if (GameManager.Instance.TotalGold  < unlockCost)
        {
            return;
        }

        SetUnlocked(true);
        GameManager.Instance.ShowNextResource();

        AchievementController.Instance.UnlockAchievement(AchievementType.UnlockResource, _config.Name);
    }
    
    public void SetUnlocked(bool unlocked)
    {
        IsUnlocked = unlocked;
        ResourceView.ShowUnlocked();
    }

    public void CheckUnlocked()
    {
        if(IsUnlocked)
        {
            UpgradeLevel();
        }
        else
        {
            UnlockResource();
        }
    }
}
