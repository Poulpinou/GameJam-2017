using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD_Manager : MonoBehaviour {

	#region Editor Fields
	[SerializeField] GameObject _goldBar;
	[SerializeField] GameObject _spellSlider;
	[SerializeField] GameObject _timer;
	[SerializeField] GameObject _wave;
	[SerializeField] GameObject _phaseDebug;


	#endregion

	#region Fields
	Phases _phases;
	Player _player;

	Text _goldText;
	Slider _spellScale;
	Text _timerText;
	Text _waveText;
	#endregion
	// Use this for initialization
	void Awake () {
		_phases = GameObject.FindObjectOfType<Phases>();
		_phases.OnPhaseChange += OnPhaseChange;

		_player = GameObject.FindObjectOfType<Player>();

		_goldText = _goldBar.GetComponent<Text>();
		_timerText = _timer.GetComponent<Text>();
		_waveText = _wave.GetComponent<Text>();
		_spellScale = _spellSlider.GetComponent<Slider>();

		OnPhaseChange();
	}

	void Update()
	{
		_goldText.text = "gold : " +  _player.get_pieces().ToString();
		_timerText.text = _phases.GetTimer.ToString();
	}
	
	public void OnPhaseChange()
	{
		BDB.Phase phase = _phases.getPhase();

		_phaseDebug.GetComponent<Text>().text = phase.ToString();
		switch (phase)
		{
			case BDB.Phase.Start:
				_goldBar.SetActive(false);
				_spellSlider.SetActive(false);
				_timer.SetActive(false);
				_wave.SetActive(false);
				break;
			case BDB.Phase.Timer:
				_goldBar.SetActive(true);
				_spellSlider.SetActive(true);
				_timer.SetActive(true);
				_wave.SetActive(false);
				break;
			case BDB.Phase.Battle:
				_goldBar.SetActive(true);
				_spellSlider.SetActive(true);
				_timer.SetActive(false);
				_wave.SetActive(true);
				break;
			case BDB.Phase.Win:
				_goldBar.SetActive(false);
				_spellSlider.SetActive(false);
				_timer.SetActive(false);
				_wave.SetActive(false);
				break;
			case BDB.Phase.Lose:
				_goldBar.SetActive(false);
				_spellSlider.SetActive(false);
				_timer.SetActive(false);
				_wave.SetActive(false);
				break;
			default:
				break;
		}
	}
}
