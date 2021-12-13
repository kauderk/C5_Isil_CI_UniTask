using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ToogleSVA : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Image _img;
    [SerializeField] Sprite _defaultSprite, _pressedSprite;
    [SerializeField] AudioClip _pressAuido, _releaseAudio;
    [SerializeField] AudioSource _audioSource;

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = (_img.sprite == _defaultSprite) ? _pressedSprite : _defaultSprite;
        _audioSource.PlayOneShot(_pressAuido);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //_img.sprite = (_img.sprite == _defaultSprite) ? _defaultSprite : _pressedSprite;
        _audioSource.PlayOneShot(_releaseAudio);
    }
}
