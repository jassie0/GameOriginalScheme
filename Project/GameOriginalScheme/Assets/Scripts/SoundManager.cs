﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }

//    public AudioSource soilderDie;
    public AudioSource dingBox;
    public AudioSource getSoilder;
    public AudioSource kingDie;
    public AudioSource soilderDie;
    //public AudioSource zidanBingAttack;
    //public AudioSource getSoilder;
    //public AudioSource getDing;

/*    public AudioSource move;

    public AudioSource reload;
    public AudioSource pistolShot;
    public AudioSource shotGunShot;
    public AudioSource jumpGunShot;

    public AudioSource dieKnife;
    public AudioSource boom;
    public AudioSource dieSpine;
    public AudioSource bossmiss;
    public AudioSource teleporter;
    public AudioSource bossfail;
    public AudioSource bossattack;
    public AudioSource missshotgun;
    public AudioSource misslonggun;

    public AudioSource BeAttacked0, BeAttacked1;*/
    // Use this for initialization

    static Dictionary<string, AudioSource> dict;

    void Start()
    {
        dict = new Dictionary<string, AudioSource>()
        {
            
            {"dingBox", dingBox },
            {"getSoilder", getSoilder },
            {"kingDie", kingDie },
            {"soilderDie", soilderDie }
            /*            {"move", move },
                        {"pickup", pickup },
                        {"reload", reload },
                        {"pistolShot", pistolShot },
                        {"shotGunShot", shotGunShot },
                        {"jumpGunShot", jumpGunShot},
                        {"dieKnife", dieKnife},
                        {"boom", boom},
                        {"dieSpine", dieSpine },
                        {"teleporter", teleporter },
                        {"bossfail",bossfail },
                        {"bossattack",bossattack },
                        {"missshotgun",missshotgun },
                        {"misslonggun",misslonggun },
                        {"bossmiss",bossmiss },
                        {"beattacked0",BeAttacked0 },
                        {"beattacked1", BeAttacked1}
                    };*/
        };
    }


    public static void PlaySound(string soundName) 
    {

        dict[soundName].Play();
        /*
        if (soundName == "move")
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = dict["move"].clip;
            source.volume = dict["move"].volume;
            source.pitch = dict["move"].pitch;
            source.Play();
            Destroy(source, source.clip.length);
        }
        else if (soundName == "bossattack")
        {

            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = dict["bossattack"].clip;
            source.volume = dict["bossattack"].volume;
            source.pitch = dict["bossattack"].pitch;
            source.Play();
            Destroy(source, source.clip.length);
        }
        else
        {
            
        }*/
    }
}