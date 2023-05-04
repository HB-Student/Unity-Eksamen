using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class levelsUI : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI tokensText;  
    private levelSystem levelSystem;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    public void setSlider(float amount){
        slider.value=amount;
    }

    public void setTokens(int amount){
        tokensText.text=amount.ToString();
    }

    public void setlevel(int level){
        levelText.text=level.ToString();
    }

    public void setLevelSystem(levelSystem system){
        levelSystem=system;
        setSlider(levelSystem.getExperienceToSlider());
        setlevel(levelSystem.getLevel());
        setTokens(levelSystem.getTokens());
        levelSystem.onExperienceChange+=levelSystem_onExperienceChange;
        levelSystem.onLevelChange+=levelSystem_onLevelChange;
        levelSystem.onTokenChange+=levelSystem_onTokenChange;
    }

    private void levelSystem_onExperienceChange(object sender, System.EventArgs e){
        setSlider(levelSystem.getExperienceToSlider());
    }
    private void levelSystem_onLevelChange(object sender, System.EventArgs e){
        setlevel(levelSystem.getLevel());
    }
        private void levelSystem_onTokenChange(object sender, System.EventArgs e){
        setTokens(levelSystem.getTokens());
    }

}
