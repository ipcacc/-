using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 이동할 씬의 이름을 인스펙터에서 지정할 수 있도록 public 변수로 설정
    public string sceneName;

    // 이 메서드를 버튼 클릭 시 호출하도록 설정
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
