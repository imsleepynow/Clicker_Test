using UnityEngine;
using UnityEngine.InputSystem;

public class GameSystem : MonoBehaviour
{
    int nowPoint = 0; // 現在のポイント
    int fullPoint = 0; // このゲームを始めてからの累計ポイント

    float clickPoint = 1.0f; // クリックで増えるポイント
    float timePoint = 0.0f; // 時間ごとに増えるポイント
    float pointUpTime = 300.0f; // ポイントが増える間隔

    float fullGameTime = 0.0f; // ゲームが始まってからの時間
    float gameTime = 0.0f;

    float clickBonus = 1.0f; // クリックで増えるポイントのボーナス倍率
    float timePointBonus = 1.0f; // 時間経過で増えるポイントの数が増える倍率
    float timeBonus = 1.0f; // 時間経過でポイントが増える時間の間隔短縮倍率

    [SerializeField] PointRender renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fullGameTime += Time.deltaTime;

        PointCheck();
        Render();
    }

    void PointCheck()
    {
        var mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Click();
        }
        var kb = Keyboard.current;
        if (kb.spaceKey.wasPressedThisFrame)
        {
            Click();
        }

        if (timePoint > 0.0f)
        {
            gameTime += Time.deltaTime;
            if (gameTime >= pointUpTime * timeBonus)
            {
                int plus = (int)(timePoint * timePointBonus);
                PointPlus(plus);
                gameTime = 0.0f;
            }
        }
    }

    void Click()
    {
        int plus = (int)(clickPoint * clickBonus);
        PointPlus(plus);
    }

    void PointPlus (int plus)
    {
        nowPoint += plus;
        fullPoint += plus;
    }

    void Render()
    {
        renderer.RenderNowPoint(nowPoint);
    }
}
