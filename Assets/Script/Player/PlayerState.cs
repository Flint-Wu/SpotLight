using System.Collections;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float Health;
    public float maxHealth;
    public float ReLifeSpeed;

    // 无敌时间设置
    public float invincibilityDuration = 2f;
    private bool isInvincible = false;

    // 受击音效
    public AudioClip hurtSound;
    public AudioSource audioSource;

    void Start()
    {
        Health = maxHealth;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Health < maxHealth)
        {
            Health += Time.deltaTime * ReLifeSpeed;
        }
    }

    public void GotHurt(float damage)
    {
        if (!isInvincible)
        {
            Health -= damage;
            PlayHurtSound();
            StartCoroutine(InvincibilityCoroutine());  // 开始无敌时间
        }
    }

    private void PlayHurtSound()
    {
        audioSource.clip = hurtSound;
        audioSource.PlayOneShot(hurtSound);
        audioSource.Play();
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;  // 开始无敌
        yield return new WaitForSeconds(invincibilityDuration);  // 等待无敌时间结束
        isInvincible = false;  // 解除无敌
    }
}
