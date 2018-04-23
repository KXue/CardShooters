using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class AudioDefinition{
	public string name;
	public AudioClip clip;
	[Range(0, 1)]
	public float volume = 1;
}
public class AudioHandler : MonoBehaviour {
	public AudioDefinition[] m_audioDefinition;
	private AudioSource m_audioSource;
	private Dictionary<string, AudioClip> m_sounds;
	private Dictionary<string, float> m_volumes;
	// Use this for initialization
	void Awake () {
		m_audioSource = GetComponent<AudioSource>();
		m_sounds = new Dictionary<string, AudioClip>();
		m_volumes = new Dictionary<string, float>();
		foreach(AudioDefinition def in m_audioDefinition){
			m_sounds.Add(def.name, def.clip);
			m_volumes.Add(def.name, def.volume);
		}
	}
	public void PlaySound(string name){
		m_audioSource.PlayOneShot(m_sounds[name], m_volumes[name]);
	}
}
