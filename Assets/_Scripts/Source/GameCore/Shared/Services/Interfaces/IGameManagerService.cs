
public interface IGameManagerService
{
  void StopAllGameSystems();
  void ChangeScene(SceneTag sceneTag, float delay = 0);
  void Quit();
}
