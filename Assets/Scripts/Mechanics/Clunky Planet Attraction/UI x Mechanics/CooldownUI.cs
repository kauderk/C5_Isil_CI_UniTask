using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CooldownUI : MonoBehaviour
{
    [SerializeField] Image bgImage;
    [SerializeField] TMP_Text cooldownPrompt;
    bool isBusy = false;
    float cooldown = 10.0f;
    float timer_ = 0.0f;

    private void Start()
    {
        bgImage.fillAmount = 0;
        cooldownPrompt.text = Mathf.RoundToInt(cooldown).ToString();
    }

    private void Update()
    {
        if (isBusy)
        {
            ApplyCooldown();
        }
    }

    public void ApplyCooldown()
    {
        timer_ -= Time.deltaTime;

        if (timer_ < 0.0f)
        {
            isBusy = false;
            cooldownPrompt.text = Mathf.RoundToInt(cooldown).ToString();
            bgImage.fillAmount = 0.0f;
        }
        else
        {
            cooldownPrompt.text = Mathf.RoundToInt(timer_).ToString();
            bgImage.fillAmount = timer_ / cooldown;
        }
    }

    public void useCooldown()
    {
        if (!isBusy)
        {
            isBusy = true;
            cooldownPrompt.text = Mathf.RoundToInt(cooldown).ToString();
            timer_ = cooldown;
            FindObjectOfType<SpawnRandom>().SpawnRandomAmount(3);
        }
    }

    //public async void ApplyCooldown()
    //{
    //    if (isBusy)
    //        return;

    //    bgImage.fillAmount = 0;
    //    isBusy = true;
    //    timer_ = cooldown;
    //    await CoolingDown();
    //    isBusy = false;
    //}

    //async Task CoolingDown()
    //{
    //    while (bgImage.fillAmount <= 1f)
    //    {
    //        timer_ -= 1;
    //        cooldownPrompt.text = Mathf.RoundToInt(bgImage.fillAmount).ToString();
    //        bgImage.fillAmount += Time.deltaTime / 1.0f;
    //        await Task.Delay(1);
    //    }
    //    bgImage.fillAmount = 1;
    //}
}
