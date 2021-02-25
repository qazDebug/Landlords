using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FairyGUI;

namespace ETModel
{
    [UIFactory(LandUIType.LandLogin)]
    public class LandLoginFactory :IUIFactory
    {
        // public static void Create()
        // {
        //     FUIComponent fuiComponent = Game.Scene.GetComponent<FUIComponent>();
        //     //从整个LandFUI资源包中取得并创建LandLogin登录界面资源
        //     FUI fui = ComponentFactory.Create<FUI, GObject>(UIPackage.CreateObject(FUIType.LandFUI, LandUIType.LandLogin));
        //     fui.Name = LandUIType.LandLogin;
        //     //给fui添加LandLoginComponent组件，此组件是给UI元件添加事件方法
        //     fui.AddComponent<LandLoginComponent>();
        //     //把登录界面fui添加到全局的FUI组件中
        //     fuiComponent.Add(fui);
        // }
        public UI Create(Scene scene, string type, GameObject parent)
        {
            try 
            {
                Log.Info($"type:{type}");
                //加载AB包
                ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
                resourcesComponent.LoadBundle($"{type}.unity3d");

                //加载登录注册界面预设并生成实例
                GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset($"{type}.unity3d", $"{type}");
                GameObject landLogin = UnityEngine.Object.Instantiate(bundleGameObject);

                //设置UI层级，只有UI摄像机可以渲染
                landLogin.layer = LayerMask.NameToLayer(LayerNames.UI);
                UI ui = ComponentFactory.Create<UI, GameObject>(landLogin);

                ui.AddComponent<LandLoginComponent>();
                return ui;
            }
            catch (Exception e)
            {

                Log.Error(e);
                return null;
            }
        }

        public void Remove(string type)
        {
            Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle($"{type}.unity3d");
        }
    }
}