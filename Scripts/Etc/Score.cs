using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GUIText scoreGUIText;
	public int score = 0;
	//private int cScore;

	// ハイスコアを表示するGUIText
	public GUIText highScoreGUIText;
	private int highScore;

	// PlayerPrefsで保存するためのキー
	private string highScoreKey = "highScore";
	private string ScoreKey = "score";

	bool isLose;
	float colortime = 0.5f;
	
	// Use this for initialization
	void Start () {
		//scoreGUIText = GetComponent<GUIText> ();
		if (Application.loadedLevelName == "Stage1") {
			Initialize1 ();
		}
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreGUIText.text = "" + score + "おい ～"; //空文字につけるとint型のスコアが文字列に変わる

		// スコアがハイスコアより大きければ
		if (highScore < score) {
			highScore = score;
		}
		// スコア・ハイスコアを表示する
		scoreGUIText.text = score.ToString () + "おい ～";

		if(Application.loadedLevelName == "GameOver"){
			scoreGUIText.text = "今回 の おい ～ 数 : " + score.ToString () + " おい ～";
			highScoreGUIText.text = "最大 おい ～ 数 : " + highScore.ToString () + " おい ～";
		}

		if (isLose) {
			scoreGUIText.color = new Color (255,0,0,0.59f);
			colortime -= Time.deltaTime;
			if(colortime <= 0f){
			scoreGUIText.color = new Color (255,255,255,0.59f);
				colortime = 0.5f;
				isLose = false;
			}
		}
	}
	// ゲーム開始前の状態に戻す
	private void Initialize1 ()
	{
		// スコアを0に戻す
		score = 0;
		PlayerPrefs.DeleteKey (ScoreKey);
	}
	private void Initialize (){
		// ハイスコアを取得する。保存されてなければ0を取得する。
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
		score = PlayerPrefs.GetInt (ScoreKey, 0);
	}
	void AddScore(int p){
		score += p;
	}
	void LoseScore(int m){
		isLose = true;
		score -= m;		
	}
	// ハイスコアの保存
	public void Save ()
	{
		// ハイスコアを保存する
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.SetInt (ScoreKey, score);
		PlayerPrefs.Save ();
		
		// ゲーム開始前の状態に戻す
		//Initialize ();
	}
}
