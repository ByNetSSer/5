using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private CinemachineBasicMultiChannelPerlin _multiChannelPerlin;
    private float _shakeTime;
    private bool _canShake;

    private float _totalShakeTime;
    private float _shakeIntensity;

    private float _currentIntensity;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _multiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    /// <summary>
    /// Method to apply a simple Shake to the Virtual Camera attatched to the script component, using intensity for screen shake power and time for duration.
    /// </summary>
    /// <param name="intensity">amount of power for the shake of the camera.</param>
    /// <param name="time">duration of the shake of the camera.</param>
    public void ShakeCameraSimple(float intensity, float time)
    {
        _currentIntensity = intensity;
        _shakeTime = time;

        _totalShakeTime = 0;

        _canShake = true;
    }

    /// <summary>
    /// Method to apply a gradual Shake to the Virtual Camera attatched to the script component, using intensity for screen shake power and time for duration.
    /// </summary>
    /// <param name="intensity">amount of power for the shake of the camera.</param>
    /// <param name="time">duration of the shake of the camera.</param>
    public void ShakeCameraGradual(float intensity, float time)
    {
        _currentIntensity = intensity;
        _shakeTime = time;

        _totalShakeTime = time;
        _shakeIntensity = intensity;

        _canShake = true;
    }

    private void Update()
    {
        if (!_canShake) return;

        _shakeTime -= Time.deltaTime;

        if(_totalShakeTime > 0)
        {
            float _scaleTime = 1 - (_shakeTime / _totalShakeTime);
            _currentIntensity = Mathf.Lerp(_shakeIntensity, 0, _scaleTime);
        }

        _multiChannelPerlin.m_AmplitudeGain = _currentIntensity;

        if (_shakeTime > 0) return;

        _shakeTime = 0;

        _multiChannelPerlin.m_AmplitudeGain = 0;

        _canShake = false;
    }
}
