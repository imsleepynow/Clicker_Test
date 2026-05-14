using UnityEngine;
using TMPro;
public class PointRender : MonoBehaviour
{
    // ゲームシステムの各UIを画面上のテキストに適応させるだけですよ
    [SerializeField] TextMeshProUGUI nowPoint;
    string nowPointBase = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowPointBase = nowPoint.text;
    }

    public void RenderNowPoint(int point)
    {
        nowPoint.text = nowPointBase + point.ToString();
    }
}
