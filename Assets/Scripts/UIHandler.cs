using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIHandler : MonoBehaviour {
	public Transform m_gameUI;
	public Transform m_pauseUI;
	bool m_isPaused = false;
	public bool paused{
		get{
			return m_isPaused;
		}
		set{
			if(value){
				PauseGame();
			}
			else{
				ResumeGame();
			}
		}
	}
	void Start()
	{
		SetCursorState(CursorLockMode.Locked);
	}
    public void PauseGame(){
        m_isPaused = true;
		Time.timeScale = 0;
		m_pauseUI.gameObject.SetActive(true);
		m_gameUI.gameObject.SetActive(false);
        SetCursorState(CursorLockMode.None);
    }
	public void ResumeGame(){
        m_isPaused = false;
		Time.timeScale = 1;
        m_pauseUI.gameObject.SetActive(false);
        m_gameUI.gameObject.SetActive(true);
		SetCursorState(CursorLockMode.Locked);
	}
	public void QuitGame(){
        Time.timeScale = 1;
        SetCursorState(CursorLockMode.None);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    void SetCursorState(CursorLockMode wantedMode)
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }
}
