using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof (Light))]
public class SoftFlicker : MonoBehaviour {

	public float MinLightIntensity = 0.44f;
	public float MaxLightIntensity = 2.4f;

	public float AccelerateTime = 17.1f;

	private float _targetIntensity = .7f;
	private float _lastIntensity = 1.0f;

	private float _timePassed = 0.0f;

	private Light _lt;
	private const double Tolerance = 0.0001;

	public bool on = false;

	CursorLockMode screenLock;

	private void Start() {
		_lt = GetComponent<Light>();
		_lastIntensity = _lt.intensity;
		FixedUpdate();
		on = true;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			on = !on;
		}
		if (on) {
			_lt.enabled = true;
		} else if (!on) {
			_lt.enabled = false;
		}
	}

	private void FixedUpdate() {

		_timePassed += Time.deltaTime;
		_lt.intensity = Mathf.Lerp(_lastIntensity, _targetIntensity, _timePassed/AccelerateTime);

		if (Math.Abs(_lt.intensity - _targetIntensity) < Tolerance) {
			_lastIntensity = _lt.intensity;
			_targetIntensity = Random.Range(MinLightIntensity, MaxLightIntensity);
			_timePassed = 0.0f;
		}
	}
}
	