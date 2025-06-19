using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public Camera Camera;

    public void ChangePlayMode()
    {
        var videoPlayer = Camera.GetComponent<VideoPlayer>();
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();
    }
}
