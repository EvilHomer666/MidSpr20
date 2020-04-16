using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip blowShield;
    [SerializeField] AudioClip recoverShield;
    [SerializeField] AudioClip speedDown;
    [SerializeField] AudioClip speedBoost;
    [SerializeField] AudioClip dangerWarning;
    [SerializeField] AudioClip collectPowerUp;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Custom functions to access sound FXs
    // Player SFX
    public void PlayerShieldDamage()
    {
        audioSource.PlayOneShot(blowShield, 0.7F);
        return;
    }
    public void PlayerShieldUp()
    {
        audioSource.PlayOneShot(recoverShield, 0.7F);
        return;
    }
    public void PlayerSpeedDown()
    {
        audioSource.PlayOneShot(speedDown, 0.7F);
        return;
    }
    public void PlayerSpeedBoost()
    {
        audioSource.PlayOneShot(speedBoost, 0.7F);
        return;
    }
    public void PlayerDangerWarning()
    {
        audioSource.PlayOneShot(dangerWarning, 0.7F);
        return;
    }

    public void PlayerCollectedPowerUp()
    {
        audioSource.PlayOneShot(collectPowerUp, 0.7f);
    }

    // Enemy SFX

    // Hazards SFX
}
