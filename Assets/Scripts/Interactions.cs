using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Interactions : MonoBehaviour
{
    Gun gunScript;
    [SerializeField] bool noAmmoSpam;
    [SerializeField] TMP_Text maxAmmoText;
    public UnityEvent reload = new UnityEvent();
    UnityAction reloadAction;
    PlayerHUD hudScript;
    // Start is called before the first frame update
    void Start()
    {
        gunScript = GetComponentInChildren<Gun>();
        noAmmoSpam = true;
        reloadAction += ReloadFunction;
        hudScript = FindObjectOfType<PlayerHUD>().GetComponent<PlayerHUD>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 11 && Input.GetKey(KeyCode.E) && noAmmoSpam)
        {
           reload.Invoke();
           hudScript.ChangeAmmo(int.Parse(maxAmmoText.text));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            reload.AddListener(reloadAction);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            reload.RemoveListener(reloadAction);
        }
    }

    void ReloadFunction()
    {
        StartCoroutine(AddAmmo());
    }


    IEnumerator AddAmmo()
    {
        noAmmoSpam = false;
        gunScript.AddAmmo(int.Parse(maxAmmoText.text));
        yield return new WaitForSeconds(5);
        noAmmoSpam = true;
    }


}
