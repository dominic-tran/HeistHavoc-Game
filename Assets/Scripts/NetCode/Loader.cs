using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

// Contributors: Dominic
public static class Loader
{
    public enum Scene
    { 
        MainMenu,
        LobbyScene,
        NetcodeTestScene,
        CharacterSelectScene,
    }
    private static Scene targetScene;

    public static void Load(Scene tagetScene)
    {
        Loader.targetScene = tagetScene;
        SceneManager.LoadScene(Scene.LobbyScene.ToString());
    }
    public static void LoadNetwork(Scene targetScene)
    {
        NetworkManager.Singleton.SceneManager.LoadScene(targetScene.ToString(), LoadSceneMode.Single);
    }
    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
