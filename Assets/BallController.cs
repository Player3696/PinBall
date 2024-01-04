using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // ***** 得点を表示するテキスト
    private GameObject gamescoreText;
    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        // *****シーン中のGameScoreTextオブジェクトを取得
        this.gamescoreText = GameObject.Find("GameScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //***** スコアをオブジェクトに設定
        this.gamescoreText.GetComponent<Text>().text = this.score + "点";
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "SmallStarTag" || other.gameObject.tag == "SmallCloudTag")
        {
            this.score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag" || other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 20;
        }
    }
}