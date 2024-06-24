using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFrequencyDetection : MonoBehaviour { //human audio ranges https://en.wikipedia.org/wiki/Audio_frequency

	//public float size = 10.0f;
	//public float amplitutde = 1.0f;
	//public int cutoffSample = 128;
	public GameObject box1;
	public GameObject box2;
	public GameObject box3;
	public GameObject box4;

	public float spawnThresholdBox1 = 0.5f;
	public float spawnThresholdBox2 = 0.5f;
	public float spawnThresholdBox3 = 0.5f;
	public float spawnThresholdBox4 = 0.5f;

	public int[] frequencyBox1; //array
	public int[] frequencyBox2;
	public int[] frequencyBox3;
	public int[] frequencyBox4;

	//bool boxLock = false; //to lock the boxes on or off preventing them to be called indefinately

	//public FFTWindow fftWindow;
	//public float debugValue;
	public AudioSource myAudio;
	//private float[] samples = new float [8192]; //6400 //1024
	private float[] frequencyData = new float [8192]; //if array is out of range make sure this number is higher than the set frequency in the inspector

	// Use this for initialization
	void Start () {
		myAudio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		//myAudio.GetSpectrumData(samples, 0, fftWindow);
		//debugValue = samples[frequency];

		myAudio.GetSpectrumData (frequencyData, 0, FFTWindow.Rectangular);

		float freq1 = 0;
		for (int i = frequencyBox1[0]; i < frequencyBox1[1]; i++) { //array loop
			freq1 += frequencyData[i];
		}
		if (freq1 > spawnThresholdBox1) {
			//Instantiate (box1, new Vector3 (-3.42f, 0f, 0f), Quaternion.identity);
			//boxLock = true;
			box1.SetActive(true);
			//Debug.Log ("box1 active");
		} else {
			//Destroy (box1);
			//gameObject.SetActive(false);
			box1.SetActive(false);
			//boxLock = false;
		}

		float freq2 = 0;
		for (int i = frequencyBox2[0]; i < frequencyBox2[1]; i++) {
			freq2 += frequencyData[i];
		}
		if (freq2 > spawnThresholdBox2) {
			box2.SetActive(true);
			//boxLock = true;
			//Debug.Log ("box2 active");
		} else {
			box2.SetActive(false);
			//boxLock = false;
		}

		float freq3 = 0;
		for (int i = frequencyBox3[0]; i < frequencyBox3[1]; i++) {
			freq3 += frequencyData[i];
		}
		if (freq3 > spawnThresholdBox3) {
			box3.SetActive(true);
			//boxLock = true;
			//Debug.Log ("box3 active");
		} else {
			box3.SetActive(false);
			//boxLock = false;
		}

		float freq4 = 0;
		for (int i = frequencyBox4[0]; i < frequencyBox4[1]; i++) {
			freq4 += frequencyData[i];
		}
		if (freq4> spawnThresholdBox4) {
			box4.SetActive(true);
			//boxLock = true;
			//Debug.Log ("box4 active");
		} else {
			box4.SetActive(false);
			//boxLock = false;
		}
		//if (samples[frequencyBox4] > spawnThreshholdBox4) {
			//Instantiate(box4, transform.position, transform.rotation);
		//}
		
	}
}
