using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //�{�[����������\���̂���z���̍ŏ��l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;

    // ***** ���_��\������e�L�X�g
    private GameObject gamescoreText;
    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");

        // *****�V�[������GameScoreText�I�u�W�F�N�g���擾
        this.gamescoreText = GameObject.Find("GameScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //***** �X�R�A���I�u�W�F�N�g�ɐݒ�
        this.gamescoreText.GetComponent<Text>().text = this.score + "�_";
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //�Փˎ��ɌĂ΂��֐�
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