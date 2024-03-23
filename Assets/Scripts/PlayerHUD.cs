using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;
    [SerializeField] Image screenFlash;

    float flashDuration = 1.4f;

    FPSController player;
    Gun gunScript;
    int maxAmmo;
    Damager[] damagerScript;
    bool damaged = false;


    Color redTint = new Color(255,0,0,.7f);
    Color targetColor = new Color(255, 0, 0, 0);
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSController>();
        gunScript = FindObjectOfType<Gun>().GetComponent<Gun>();
        damagerScript = FindObjectsOfType<Damager>();
        gunScript.maxAmmoAction += MaxAmmo;
        gunScript.currentAmmo += ChangeAmmo;
        player.onDamagerHit += DecreaseHealth;
    }

    public void ChangeAmmo(int ammo)
    {
        if (ammo > 9)
        {
            currentAmmoText.text = "" + ammo;
        }
        else
        {
            currentAmmoText.text = "0" + ammo;
        }
    }

    public void MaxAmmo(int maxAmmo)
    {
        maxAmmoText.text = maxAmmo.ToString();
    }

    void DecreaseHealth()
    {
        StartCoroutine(CanBeDamaged());
    }

    IEnumerator CanBeDamaged()
    {
        if (!damaged)
        {
            healthBar.fillAmount -= .1f;
            screenFlash.color = redTint;
            damaged = true;
            yield return new WaitForSeconds(.5f);
            damaged = false;
        }
    }

    void ColorChange()
    {
       
    }
    void Update()
    {
        var currentColor = screenFlash.color;
        if (currentColor != targetColor)
        {
            currentColor = Color.LerpUnclamped(currentColor, targetColor, flashDuration * Time.deltaTime);
            screenFlash.color = currentColor;
        }
    }
}
