﻿using UnityEngine;
using System.Collections;

public class Sampler_Lesson1 : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool _debugPlay;

    [Header("Config")]
    [SerializeField] private AudioClip _audioClip;
    [SerializeField, Range(1, 8)] private int _numVoices = 2;
    [SerializeField] private SamplerVoice_Lesson1 _samplerVoicePrefab;

    private SamplerVoice_Lesson1[] _samplerVoices;
    private int _nextVoiceIndex;

    private void Awake()
    {
        _samplerVoices = new SamplerVoice_Lesson1[_numVoices];

        for (int i = 0; i < _numVoices; ++i)
        {
            SamplerVoice_Lesson1 samplerVoice = Instantiate(_samplerVoicePrefab);
            samplerVoice.transform.parent = transform;
            samplerVoice.transform.localPosition = Vector3.zero;
            _samplerVoices[i] = samplerVoice;
        }
    }

    private void Update()
    {
        if (_debugPlay)
        {
            Play();
            _debugPlay = false;
        }
    }

    private void Play()
    {
        _samplerVoices[_nextVoiceIndex].Play(_audioClip);

        _nextVoiceIndex = (_nextVoiceIndex + 1) % _samplerVoices.Length;
    }
}
