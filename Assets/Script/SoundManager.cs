using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource Bgm;
    public AudioClip Menu;
    public AudioClip Stage01;
    public AudioClip Stage01_01;
    public AudioClip Stage01_01_01;
    public AudioClip Stage01_02;
    public AudioClip Stage02;

    public AudioSource ButtonBullet_Audio;
    public AudioClip ButtonBullet;

    public AudioSource ButtonNext_Audio;
    public AudioClip ButtonNext;

    public AudioSource Damage_Audio;
    public AudioClip Damage;

    public AudioSource Die_Audio;
    public AudioClip Die;

    public AudioSource Move_Audio;
    public AudioClip Move;

    public AudioSource Sliding_Audio;
    public AudioClip Sliding;

    public AudioSource Attack_Audio;
    public AudioClip Attack;

    public AudioSource Barrier_Audio;
    public AudioClip Barrier;

    public AudioSource Destroy_Audio;
    public AudioClip Destroy_Clip;

    public AudioSource Heal_Audio;
    public AudioClip Heal;

    public float bgmVolume = 1.0f;
    public float sfxVolume = 1.0f;

    public static SoundManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<SoundManager>();
            }
            return m_instance;
        }
    }

    private static SoundManager m_instance;

    private void Awake()
    {
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        Bgm_Play();
    }

    public void Bgm_Play()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Bgm.loop = true;
            Bgm.clip = Menu;
            Bgm.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Stage01")
        {
            Bgm.loop = true;
            Bgm.clip = Stage01;
            Bgm.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Stage01_01")
        {
            Bgm.loop = true;
            Bgm.clip = Stage01_01;
            Bgm.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Stage01_02")
        {
            Bgm.loop = true;
            Bgm.clip = Stage01_02;
            Bgm.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Stage01_01_01")
        {
            Bgm.loop = true;
            Bgm.clip = Stage01_01_01;
            Bgm.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Stage02")
        {
            Bgm.loop = true;
            Bgm.clip = Stage02;
            Bgm.Play();
        }
    }

    public void Bgm_Stop()
    {
        Bgm.Stop();
    }

    public void ButtonBullet_Play()
    {
        ButtonBullet_Audio.PlayOneShot(ButtonBullet);
    }

    public void BuutonBullet_Stop()
    {
        ButtonBullet_Audio.Stop();
    }

    public void ButtonNext_Play()
    {
        ButtonNext_Audio.PlayOneShot(ButtonNext);
    }

    public void ButtonNext_Stop()
    {
        ButtonNext_Audio.Stop();
    }

    public void Damage_Play()
    {
        Damage_Audio.PlayOneShot(Damage);
    }

    public void Damage_Stop()
    {
        Damage_Audio.Stop();
    }

    public void Die_Play()
    {
        Die_Audio.PlayOneShot(Die);
    }

    public void Die_Stop()
    {
        Die_Audio.Stop();
    }

    public void Move_Play()
    {
        if (!Move_Audio.isPlaying)
        {
            Move_Audio.PlayOneShot(Move);
        }
    }

    public void Move_Stop()
    {
        Move_Audio.Stop();
    }

    public void Sliding_Play()
    {
        Sliding_Audio.PlayOneShot(Sliding);
    }

    public void Sliding_Stop()
    {
        Sliding_Audio.Stop();
    }

    public void Attack_Play()
    {
        if (!Attack_Audio.isPlaying)
        {
            Attack_Audio.PlayOneShot(Attack);
        }
    }

    public void Attack_Stop()
    {
        Attack_Audio.Stop();
    }

    public void Barrier_Play()
    {
        Barrier_Audio.PlayOneShot(Barrier);
    }

    public void Barrier_Stop()
    {
        Barrier_Audio.Stop();
    }

    public void Destroy_Play()
    {
        Destroy_Audio.PlayOneShot(Destroy_Clip);
    }

    public void Destroy_Stop()
    {
        Destroy_Audio.Stop();
    }

    public void Heal_Play()
    {
        Heal_Audio.PlayOneShot(Heal);
    }

    public void Heal_Stop()
    {
        Heal_Audio.Stop();
    }
}
