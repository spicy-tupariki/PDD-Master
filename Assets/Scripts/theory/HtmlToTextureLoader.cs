using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

public class LocalHtmlLoader : MonoBehaviour
{
    [Header("Display Settings")]
    public Renderer targetRenderer; // Для 3D-объектов
    public UnityEngine.UI.RawImage uiImage; // Для UI

    [Header("Server Settings")]
    public int serverPort = 3000;
    public bool autoStartServer = true;

    private string serverUrl;

    IEnumerator Start()
    {
        // Автозапуск сервера (только в редакторе)
#if UNITY_EDITOR
        if (autoStartServer) StartNodeServer();
#endif

        serverUrl = $"http://localhost:{serverPort}/screenshot";

        // Ждем инициализации сервера
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

            // Применяем текстуру
            if (targetRenderer != null)
                targetRenderer.material.mainTexture = texture;

            if (uiImage != null)
                uiImage.texture = texture;
        }
    }

#if UNITY_EDITOR
    void StartNodeServer()
    {
        string nodePath = "node"; // Для Windows
        string scriptPath = Path.Combine(Application.dataPath, "local-server.js");

        // Для Mac/Linux:
        // string nodePath = "/usr/local/bin/node";

        System.Diagnostics.Process.Start(nodePath, $"\"{scriptPath}\"");
    }
#endif

    void OnApplicationQuit()
    {
        // Закрываем сервер при выходе
#if UNITY_EDITOR
        foreach (var process in System.Diagnostics.Process.GetProcessesByName("node"))
        {
            process.Kill();
        }
#endif
    }
}