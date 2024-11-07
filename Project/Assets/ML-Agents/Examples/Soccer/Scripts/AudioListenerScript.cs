using UnityEngine;

public class AudioDetection : MonoBehaviour
{
    public int sampleSize = 256; // Number of audio samples to capture
    private float[] audioSamples;

    void Start()
    {
        audioSamples = new float[sampleSize];
    }

    void Update()
    {
        // Capture audio data from the AudioListener
        AudioListener.GetOutputData(audioSamples, 0);

        // Calculate the average audio level
        float audioLevel = 0f;
        foreach (var sample in audioSamples)
        {
            audioLevel += Mathf.Abs(sample);
        }
        audioLevel /= sampleSize;

        // Print or log the audio level
        Debug.Log("Audio Level: " + audioLevel);

        // Check if the audio level is above a certain threshold
        if (audioLevel > 0.01f) // Adjust this threshold as needed
        {
            Debug.Log("Audio detected!");
        }
    }
}
