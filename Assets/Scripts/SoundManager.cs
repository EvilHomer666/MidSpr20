using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Player SFX clips
    [SerializeField] AudioClip blowShield;
    [SerializeField] AudioClip recoverShield;
    [SerializeField] AudioClip speedDown;
    [SerializeField] AudioClip speedBoost;
    [SerializeField] AudioClip dangerWarning;
    [SerializeField] AudioClip collectPowerUp;

    // Enemies SFX clips
    [SerializeField] AudioClip enemyShipEngaged;
    [SerializeField] AudioClip enemyShipDestroyed;

    // Hazards SFX clips
    [SerializeField] AudioClip largeAsteroidHit;
    [SerializeField] AudioClip smallAsteroidHit;
    [SerializeField] AudioClip largeAsteroidDestroyed;
    [SerializeField] AudioClip smallAsteroidDestroyed;

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
        audioSource.PlayOneShot(blowShield, 1.2F);
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
        audioSource.PlayOneShot(dangerWarning, 0.3F);
        return;
    }
    public void PlayerCollectedPowerUp()
    {
        audioSource.PlayOneShot(collectPowerUp, 0.5f);
        return;
    }

    // Enemy SFX
    public void EnemyShipEngaged()
    {
        audioSource.PlayOneShot(enemyShipEngaged, 1.7F);
        return;
    }
    public void EnemyShipDestroyed()
    {
        audioSource.PlayOneShot(enemyShipDestroyed, 1.7F);
        return;
    }

    // Hazards SFX
    public void LargeAsteroidHit()
    {
        audioSource.PlayOneShot(largeAsteroidHit, 1.7F);
        return;
    }
    public void SmallAsteroidHit()
    {
        audioSource.PlayOneShot(smallAsteroidHit, 1.7F);
        return;
    }
    public void LargeAsteroidDestroyed()
    {
        audioSource.PlayOneShot(largeAsteroidDestroyed, 1.7F);
        return;
    }
    public void SmallAsteroidDestroyed()
    {
        audioSource.PlayOneShot(smallAsteroidDestroyed, 1.7F);
        return;
    }
}
