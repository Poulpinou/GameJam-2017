using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD_Manager : MonoBehaviour {

	#region Editor Fields
	[SerializeField] GameObject _goldBar;
	[SerializeField] GameObject _timer;
	[SerializeField] GameObject _wave;
	[SerializeField] GameObject _phaseDebug;
	[SerializeField] GameObject _winLose;


	#endregion

	#region Fields
	Phases _phases;
	Player _player;

	Text _goldText;
	Text _timerText;
	Text _waveText;
	Text _winLoseText;
	#endregion
	// Use this for initialization
	void Awake () {
		_phases = GameObject.FindObjectOfType<Phases>();
		_phases.OnPhaseChange += OnPhaseChange;

		_player = GameObject.FindObjectOfType<Player>();

		_goldText = _goldBar.GetComponent<Text>();
		_timerText = _timer.GetComponent<Text>();
		_waveText = _wave.GetComponent<Text>();
		_winLoseText = _winLose.GetComponent<Text>();

		OnPhaseChange();
	}

	void Update()
	{
		_goldText.text = "gold : " +  _player.get_pieces().ToString();
		_timerText.text = ((int)_phases.GetInvertedTimer + 1).ToString();
		if(_phases.getPhase() == BDB.Phase.Lose)
		{
			_winLoseText.text = "YOU LOST !!!!";
		}
		if (_phases.getPhase() == BDB.Phase.Win)
		{
			_winLoseText.text = "YOU WIN !!!!";
		}
	}
	
	public void OnPhaseChange()
	{
		BDB.Phase phase = _phases.getPhase();

		_phaseDebug.GetComponent<Text>().text = phase.ToString();
		switch (phase)
		{
			case BDB.Phase.Start:
				_goldBar.SetActive(false);
				_timer.SetActive(false);
				_wave.SetActive(false);
				_winLose.SetActive(false);
				break;
			case BDB.Phase.Timer:
				_goldBar.SetActive(true);
				_timer.SetActive(true);
				_wave.SetActive(false);
				_winLose.SetActive(false);
				break;
			case BDB.Phase.Battle:
				_goldBar.SetActive(true);
				_timer.SetActive(false);
				_wave.SetActive(true);
				_winLose.SetActive(false);
				break;
			case BDB.Phase.Win:
				_goldBar.SetActive(false);
				_timer.SetActive(false);
				_wave.SetActive(false);
				_winLose.SetActive(true);
				break;
			case BDB.Phase.Lose:
				_goldBar.SetActive(false);
				_timer.SetActive(false);
				_wave.SetActive(false);
				_winLose.SetActive(true);
				break;
			case BDB.Phase.Survive:
				_goldBar.SetActive(false);
				_timer.SetActive(false);
				_wave.SetActive(false);
				_winLose.SetActive(false);
				break;
			default:
				break;
		}
	}
}
