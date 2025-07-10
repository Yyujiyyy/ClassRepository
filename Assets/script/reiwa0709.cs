using System.Collections.Generic;
using UnityEngine;

public class reiwa0709 : MonoBehaviour
{
    [SerializeField] private GameObject[] Cubes;
    [SerializeField][Range(0f, 1f)][Header("時間")] private float WaitSeconds;
    [SerializeField][Range(0, 100)][Header("個数")] private int MaxAmount = 50;

    //配置開始位置
    private int startX = -9;
    private int startY = 5;

    [Header(" 縦方向の列")][Range(0,100)] public int rowLength = 10;
    [Header(" 横方向の列")][Range(0, 100)] public int columnCount = 10;

    // 生成したCubeのTransformを順に格納（スケール操作用）
    private List<Transform> cubeList = new List<Transform>();

    private int scaleIndex = 0;             // 現在スケール操作中のCubeインデックス
    private float timer = 0f;               // スケール変更のための経過時間タイマー
    private bool isShrinking = true;        // 現在の動作状態（true=縮小中、false=拡大中）

    void Start()
    {
        int placedCount = 0; // 生成したCubeのカウント

        // 横方向に列をループ
        for (int col = 0; col < columnCount; col++)
        {
            // スネーク状に配置するため、偶数列は上から下、奇数列は下から上
            bool isNormalOrder = (col % 2 == 0);

            // 縦方向の行数分ループ
            for (int row = 0; row < rowLength; row++)
            {
                // MaxAmountを超えたらループ終了
                if (placedCount >= MaxAmount) break;

                // Y座標計算
                // 偶数列：上から下に配置（startYからrow分だけ下に移動）
                // 奇数列：下から上に配置（startYから行数分戻ってrow分だけ上に移動）
                int yPos = isNormalOrder
                    ? (startY - row)
                    : (startY - (rowLength - 1) + row);

                // 配置位置の計算（Xは列番号分ずらす、Yは上で計算）
                Vector3 spawnPos = new Vector3(startX + col, yPos, 0);

                // 登録したCube配列から順に取得（ placedCountが配列長を超えたらループ）
                GameObject prefab = Cubes[placedCount % Cubes.Length];

                // 取得したプレハブを指定位置・回転で生成
                GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);

                // スケール操作用にTransformをリストに保存
                cubeList.Add(obj.transform);

                // 配置したCube数をカウントアップ
                placedCount++;
            }
        }
    }

    void Update()
    {
        // もしCubeが一つもなければ何もしない
        if (cubeList.Count == 0) return;

        // 経過時間をカウントアップ
        timer += Time.deltaTime;

        // WaitSeconds秒以上経ったら次のCubeのスケールを変更
        if (timer >= WaitSeconds)
        {
            // 現在対象のCubeのTransform取得
            Transform t = cubeList[scaleIndex];

            if (isShrinking)
            {
                // 縮小中はスケールを0.5倍に設定
                t.localScale = Vector3.one * 0.5f;

                // 次のCubeへ
                scaleIndex++;

                // 最後まで縮小したら
                if (scaleIndex >= cubeList.Count)
                {
                    // 拡大は逆順スタートなので最後尾に移動
                    scaleIndex = cubeList.Count - 1;

                    // 拡大モードに切り替え
                    isShrinking = false;
                }
            }
            else
            {
                // 拡大中はスケールを元に戻す（1倍）
                t.localScale = Vector3.one;

                // 逆方向に移動
                scaleIndex--;

                // 全て拡大し終えたら
                if (scaleIndex < 0)
                {
                    // 縮小は順方向スタートなので先頭に戻す
                    scaleIndex = 0;

                    // 縮小モードに切り替え
                    isShrinking = true;
                }
            }

            // タイマーをリセットして次の待機へ
            timer = 0f;
        }
    }
}