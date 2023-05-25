using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public enum TypeOfRate { Quadratic, Logarithmic, Linear }
public class DizzyDistortion : MonoBehaviour
{
    [SerializeField] private float _xLimit = 10;
    [SerializeField] private float _yLimit = 2;
    [SerializeField] private float _boringArea = 0.4f;
    [SerializeField] private float _changeRate = 0.01f;
    [SerializeField] private TypeOfRate _typeOfRate;

    UnityEngine.Rendering.Universal.LensDistortion _lensDistortion;
    private Volume _volume;

    private float fakeTime = 0;
    private bool _goingPositive = true;
    private float _rateOfChange = 0;

    private bool isDistorting = false;

    private void Awake()
    {
        DistortionController.ActivateDistort += StartDistort;
        LensDistortion tmp;
        UnityEngine.Rendering.VolumeProfile volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;
        if(!volumeProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));

        UnityEngine.Rendering.Universal.LensDistortion lensDistortion;
        

        if(volumeProfile.TryGet(out lensDistortion)) _lensDistortion = lensDistortion;
        else throw new System.NullReferenceException(nameof(lensDistortion));
        _lensDistortion.center.Override(new Vector2(0, 0));

        fakeTime = _boringArea;
    }


    private void CalculateRate()
    {
        switch (_typeOfRate) {
            case TypeOfRate.Quadratic:
                _rateOfChange = Mathf.Sqrt(_changeRate);
                break;
            case TypeOfRate.Linear:
                _rateOfChange = _changeRate;
                break;

        }
    }

    private void FixedUpdate()
    {
        if (isDistorting) Distort();
    }

    private void StartDistort()
    {
        if (isDistorting) return;
        StartCoroutine(ChangeDistortState());
    }

    private IEnumerator ChangeDistortState()
    {
        isDistorting = true;
        yield return new WaitForSeconds(5);
        isDistorting = false;
    }

    private void Distort()
    {
        CalculateRate();
        if (_goingPositive) fakeTime += _rateOfChange;
        else fakeTime -= _rateOfChange;

        if (fakeTime >= 1)
        {
            _goingPositive = false;
        }
        else if (fakeTime <= -1)
        {
            _goingPositive = true;
        }


        Vector2 currentCenter = _lensDistortion.center.value;
        _lensDistortion.center.Override(new Vector2(fakeTime * _xLimit, Mathf.Abs(fakeTime * _yLimit) * -1));
    }
}
