using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

public class LocalHtmlLoader : MonoBehaviour
{
    [Header("Display Settings")]
    public Renderer targetRenderer; // ��� 3D-��������
    public UnityEngine.UI.RawImage uiImage; // ��� UI

    [Header("Server Settings")]
    public int serverPort = 3000;
    public bool autoStartServer = true;

    private string serverUrl;

    IEnumerator Start()
    {
        // ���������� ������� (������ � ���������)
#if UNITY_EDITOR
        if (autoStartServer) StartNodeServer();
#endif

        serverUrl = $"http://localhost:{serverPort}/screenshot";

        // ���� ������������� �������
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(LoadHtmlTexture());
    }

    IEnumerator LoadHtmlTexture()
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(serverUrl))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error: {request.error}");
                yield break;
            }

            Texture2D texture = DownloadHandlerTexture.GetContent(request);

            // ��������� ��������
            if (targetRenderer != null)
                targetRenderer.material.mainTexture = texture;

            if (uiImage != null)
                uiImage.texture = texture;
        }
    }

#if UNITY_EDITOR
    void StartNodeServer()
    {
        string nodePath = "node"; // ��� Windows
        string scriptPath = Path.Combine(Application.dataPath, "local-server.js");

        // ��� Mac/Linux:
        // string nodePath = "/usr/local/bin/node";

        System.Diagnostics.Process.Start(nodePath, $"\"{scriptPath}\"");
    }
#endif

    void OnApplicationQuit()
    {
        // ��������� ������ ��� ������
#if UNITY_EDITOR
        foreach (var process in System.Diagnostics.Process.GetProcessesByName("node"))
        {
            process.Kill();
        }
#endif
    }
}