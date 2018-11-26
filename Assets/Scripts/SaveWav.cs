using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WavUtility;
using System.IO;
using UnityEngine.Networking;

public class SaveWav : MonoBehaviour
{
    private AudioClip audioClip;
    AudioSource audioSource;
    int recordTime = 3;
    const int sampleRate = 50000;
    float timer;
    int minFreq;
    int maxFreq;
    Recording Recording;

    // Use this for initialization
    void Start()
    {
        
        Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);
        Debug.Log(minFreq + "min");
        Debug.Log(maxFreq + "max");
        audioSource = GetComponent<AudioSource>();
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            RecordAudio();
            Debug.Log("success");
        }


    }
    public void RecordAudio()
    {
        if (Microphone.devices.Length == 0)
        {
            Debug.LogWarning("No microphone found to record audio clip sample with.");
            return;
        }
        string mic = Microphone.devices[0];
        audioSource.clip = Microphone.Start(null, false, recordTime, sampleRate);
        audioSource.Play();
        Debug.Log(Microphone.IsRecording(null));
        Debug.Log("microsuccess");

        SaveWavFile();
        Debug.Log("stop");




    }
    public string SaveWavFile()
    {

        string filePath;
        filePath = Directory.GetCurrentDirectory();
        byte[] bytes = WavUtility.FromAudioClip(audioSource.clip, out filePath, true);
        Debug.Log(filePath);
        return filePath;


    }







}
