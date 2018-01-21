using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using HoloToolkit.Unity.InputModule;

public class PrototypeHttpRequest : MonoBehaviour, IInputClickHandler
{
    public string requestUrl = "http://192.168.2.150:8080/control";
    public string methodType = "POST";
    [Multiline(8)] public string onBody = "{\n  \"operations\":[\n    {\n      \"target\":\"\",\n      \"operation\":\"\"\n    }\n  ]\n}";
    [Multiline(8)] public string offBody = "{\n  \"operations\":[\n    {\n      \"target\":\"\",\n      \"operation\":\"\"\n    }\n  ]\n}";
    private static bool state = true;
    private string requestBody = "";

    private Renderer meshRenderer = null;
    private Material defaultMaterial = null;
    [SerializeField] private Material selectedMaterial = null;


    public void Awake()
    {
        this.meshRenderer = this.GetComponent<Renderer>();
        this.defaultMaterial = this.meshRenderer.material;
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (state == true)
        {
            requestBody = offBody;
            state = false;
            this.meshRenderer.material = this.defaultMaterial;
        }
        else
        {
            requestBody = onBody;
            state = true;
            this.meshRenderer.material = this.selectedMaterial;
        }

        UnityWebRequest request = new UnityWebRequest(requestUrl, methodType);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(requestBody);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // リクエスト送信
        request.Send();

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
