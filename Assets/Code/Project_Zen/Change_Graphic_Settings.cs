using UnityEngine;
using UnityEngine.UI;

public class Change_Graphic_Settings : MonoBehaviour
{
    [SerializeField] private string GraphicSetting_PlayerPref = "GRAPHIC_SETTING";
    [SerializeField] Toggle[] grahicSettingToggle;

    private void Start()
    {
        SetGrahicSetting();
    }

    public void OnChangeSettings(Toggle _toggle)
    {
        string _Setting_Name = _toggle.GetComponent<Graphic_Settings_Name>().SettingsName;

        if (_Setting_Name == "LOW")
            SetGraphicSettingRuntime(0);
        else if (_Setting_Name == "MEDIUM")
            SetGraphicSettingRuntime(1);
        else if (_Setting_Name == "HIGH")
            SetGraphicSettingRuntime(2);

        else
            Debug.Log("Grahiic settings wrong input!!");
    }

    private void SetGraphicSettingRuntime(int _index)
    {
        QualitySettings.SetQualityLevel(_index, true);
        PlayerPrefs.SetInt(GraphicSetting_PlayerPref, _index);  
    }

    private void SetGrahicSetting()
    {
        int _index = PlayerPrefs.GetInt(GraphicSetting_PlayerPref, 0);
        QualitySettings.SetQualityLevel(_index, true);
        // update graphic settings UI
        grahicSettingToggle[_index].isOn = true;
    }
}
