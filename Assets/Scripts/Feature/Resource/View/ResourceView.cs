using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceView : MonoBehaviour
{
    private ResourceController _resource;
    public Text ResourceDescription;
    public Text ResourceUpgradeCost;
    public Text ResourceUnlockCost;
    public Image ResourceImage;
    public Button ResourceButton;

    public void InitalizeController(ResourceController resource)
    {
        _resource = resource;
        ResourceButton.onClick.AddListener(_resource.CheckUnlocked);
    }
    public ResourceConfig Config
    {
        get { return _resource.GetConfig(); }
    }

    public int Level
    {
        get { return _resource.GetLevel(); }
    }

    public void SetConfigName()
    {
        //ToString("0") berfungsi untuk membuang angka di belakang koma
        ResourceDescription.text = $"{Config.Name} Lv.{Level}\n+{_resource.GetOutput().ToString("0")}";
        ResourceUnlockCost.text = $"Unlock Cost\n{Config.UnlockCost}";
        ResourceUpgradeCost.text = $"Upgrade Cost\n{_resource.GetUpgradeCost()}";
    }

    public void SetUpgradeLevelName()
    {
        ResourceUpgradeCost.text = $"Upgrade Cost\n{_resource.GetUpgradeCost()}";
        ResourceDescription.text = $"{Config.Name } Lv.{Level}\n+{_resource.GetOutput().ToString("0")}";
    }

    public void ShowUnlocked()
    {
        ResourceUnlockCost.gameObject.SetActive(!_resource.IsUnlocked);
        ResourceUpgradeCost.gameObject.SetActive(_resource.IsUnlocked);
        ResourceImage.color = _resource.IsUnlocked? Color.white : Color.grey;
    }
}
