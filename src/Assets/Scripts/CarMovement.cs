using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
	// CarMovement.cs || @artndev 


	public AxleInfo [] carAxis = new AxleInfo[2];
	public float carSpeed;
	public float steerAngle;
	public Transform centerOfMass;

	[Header("AudioSource for engine sound")]
	// AudioSource для воспроизведения звука мотора
	public AudioSource audioSrc;

	float Countdown;
	float horInput;
	float vertInput;

	Rigidbody rb;
	GameObject car;


	void Start()
	{
		// устанавливаем центр массы Rigidbody у машиныы
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = centerOfMass.localPosition;
	}


	void FixedUpdate()
	{
		horInput = Input.GetAxis("Horizontal");
		vertInput = Input.GetAxis("Vertical");

		// если таймер обратного отсчета подошел к концу
		Countdown = gameObject.GetComponent<UIControl>().countdownLeft;
		if(Countdown == 0)
		{
			Accelerate();
			ManageHardBreak();
		}
	}


	// ускорение машины
	void Accelerate()
	{
		foreach(AxleInfo axle in carAxis)
		{
			if(axle.steering)
			{
				axle.rightWheel.steerAngle = steerAngle * horInput;
				axle.leftWheel.steerAngle = steerAngle * horInput;
			}
			if(axle.motor)
			{
				axle.rightWheel.motorTorque = carSpeed * vertInput;
				axle.leftWheel.motorTorque = carSpeed * vertInput;
				audioSrc.pitch = 2 + vertInput;
			}
			VisWheelsToColliders(axle.rightWheel, axle.visRightWheel);
			VisWheelsToColliders(axle.leftWheel, axle.visLeftWheel);
		}
	}


	// положение коллайдера присваивается соответствующей моделе колеса
	void VisWheelsToColliders(WheelCollider col, Transform visWheel)
	{
		Vector3 position;
		Quaternion rotation;

		col.GetWorldPose(out position, out rotation);

		visWheel.position = position;
		visWheel.rotation = rotation;
	}


	// управление тормозом машины
	void ManageHardBreak()
	{
		foreach(AxleInfo axle in carAxis)
		{
			if(Input.GetKey(KeyCode.Space))
			{
				axle.rightWheel.brakeTorque = 50000;
				axle.leftWheel.brakeTorque = 50000;
			}
			else
			{
				axle.rightWheel.brakeTorque = 0;
				axle.leftWheel.brakeTorque = 0;
			}
		}
	}

}


// класс служащий основой для массива carAxis
[System.Serializable]
public class AxleInfo
{
	public WheelCollider rightWheel;
	public WheelCollider leftWheel;

	public Transform visRightWheel;
	public Transform visLeftWheel;

	public bool steering;
	public bool motor;
}