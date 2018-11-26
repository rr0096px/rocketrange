using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static SavWav;

public class Recording : MonoBehaviour
{
    AudioSource source;
    int recordTime = 3;

    // Use this for initialization
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        int minFreq, maxFreq;
        Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);
        source.clip = Microphone.Start(null, true, recordTime, 44100);
        source.Play();
        if(recordTime > 3){
            StopRecording();
        }

    }

    public void StopRecording(){
        Microphone.End(null);
        Debug.Log("end");
        SaveFile();
        StartCoroutine("LoadClip");
    }

    public string SaveFile(){
        if (source.clip == null)
            return "";
        
            source.clip = SavWav.TrimSilence(source.clip, 0f);
                
        string fileName = recordTime.ToString();
        string path = DATA_PATH + '/' + fileName;
         if(SavWav.Save(path,source.clip))
              return fileName;
        return "";

    }

    public string DATA_PATH{
        get { return Application.persistentDataPath; }
    }
    IEnumerator LoadClip(string _path, System.Action<AudioClip> _callback){
        WWW www = new WWW("file://" + _path);
        Debug.Log("loding" + _path);
        yield return www;
        AudioClip clip = www.GetAudioClip(false);
        int skip_size = (int)((float)clip.frequency * 0f);
        float[] samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);
        clip.SetData(samples, skip_size);

        clip.GetData(samples, 0);
        if(_callback != null){
            _callback(clip);
        }
    }

}
