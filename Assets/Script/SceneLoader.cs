using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // �̵��� ���� �̸��� �ν����Ϳ��� ������ �� �ֵ��� public ������ ����
    public string sceneName;

    // �� �޼��带 ��ư Ŭ�� �� ȣ���ϵ��� ����
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
