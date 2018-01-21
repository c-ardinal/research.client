using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class TapToHttpRequest : MonoBehaviour
{

    public string requestUrl;
    public enum MethodType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    [SerializeField] MethodType mt = MethodType.GET;
    [Multiline(15)] public string requestBody;
    private string methodType;


    void Start()
    {
        StartCoroutine(SendRequest());
    }

    void OnSelect()
    {
        StartCoroutine(SendRequest());

    }

    IEnumerator SendRequest()
    {
        switch (mt)
        {
            case MethodType.GET: methodType = "GET";
                break;
            case MethodType.POST: methodType = "POST";
                break;
            case MethodType.PUT: methodType = "PUT";
                break;
            case MethodType.DELETE: methodType = "DELETE";
                break;
        }

        UnityWebRequest request = new UnityWebRequest(requestUrl, methodType);
        // 下記でも可
        // UnityWebRequest request = new UnityWebRequest("http://example.com");
        // methodプロパティにメソッドを渡すことで任意のメソッドを利用できるようになった
        // request.method = UnityWebRequest.kHttpVerbGET;

        if (methodType.ToUpper() != "GET")
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(requestBody);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
        }

        // リクエスト送信
        yield return request.Send();

        // 通信エラーチェック
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                // UTF8文字列として取得する
                string text = request.downloadHandler.text;

                // バイナリデータとして取得する
                byte[] results = request.downloadHandler.data;
            }
        }
    }
}
