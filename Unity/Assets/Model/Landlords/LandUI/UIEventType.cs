using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public static partial class FUIType
    {
        public const string LandFUI = "LandFUI";
        // public const string LandLogin = "LandLogin";
    }
    public static partial class LandUIType
    {
        public const string LandLogin = "LandLogin";
        public const string LandLobby = "LandLobby";
        public const string SetUserInfo = "SetUserInfo";
    }

    public static partial class UIEventType
    {
        //斗地主EventIdType
		public const string LandInitSceneStart = "LandInitSceneStart";
        public const string LandLoginFinish = "LandLoginFinish";
        public const string LandInitLobby = "LandInitLobby";
        public const string LandInitSetUserInfo = "LandInitSetUserInfo";
        public const string LandSetUserInfoFinish = "LandSetUserInfoFinish";
        
    }

    // [Event(UIEventType.LandInitSceneStart)]
    // public class InitSceneStart_CreateLandLogin :AEvent
    // {
    //    public override void Run()
    //     {
    //         // Game.Scene.GetComponent<UIComponent>().Remove(LandUIType.LandLogin);
    //         RunAsync().Coroutine();
    //     }
    //     public async ETVoid RunAsync()
    //     {
    //         FUIComponent fuiComponent = Game.Scene.GetComponent<FUIComponent>();
    //         //实际比例
    //         float ratioCurrent = fuiComponent.Root.GObject.actualWidth / fuiComponent.Root.GObject.actualHeight;
    //         //设计比例
    //         float ratioDesign = (float)1280 / (float)720;
    //         if (ratioCurrent > ratioDesign) //当前屏幕宽度超出
    //         {
    //             fuiComponent.Root.GObject.x -= (fuiComponent.Root.GObject.actualHeight * ratioDesign - fuiComponent.Root.GObject.actualWidth) / 2;
    //         }
    //         else if (ratioCurrent < ratioDesign)//当前屏幕高度超出
    //         {
    //             //Log.Debug("物体高度：" + self.Root.GObject.height + "物体宽度：" + self.Root.GObject.width + "真实高度" + self.Root.GObject.actualHeight + "真实宽度" + self.Root.GObject.actualWidth + "屏幕高度" + Screen.height + "屏幕宽度" + Screen.width);
    //             //真实设计高度 - 屏幕真实高度
    //             fuiComponent.Root.GObject.y -= (fuiComponent.Root.GObject.actualWidth / ratioDesign - fuiComponent.Root.GObject.actualHeight) / 2;
    //             //Log.Debug("理想高度为：" + self.Root.GObject.width / ratioDesign);
    //         }

    //         //加载一次FUI资源
    //         await Game.Scene.GetComponent<FUIPackageComponent>().AddPackageAsync(FUIType.LandFUI);

    //         //创建登陆界面
    //         // LandLoginFactory.Create();
    //     }
    // }

    [Event(UIEventType.LandLoginFinish)]
    public class LandLoginFinished : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Remove(LandUIType.LandLogin);
            // RunAsync().Coroutine();
        }
    }

    [Event(UIEventType.LandInitLobby)]
    public class InitLobby_CreateLandLobby : AEvent
    {
       public override void Run()
       {
           Game.Scene.GetComponent<UIComponent>().Create(LandUIType.LandLobby);
       }
    }

    [Event(UIEventType.LandInitSceneStart)]
    public class InitSceneStart_CreateLandLogin :AEvent
    {
        public override void Run()
       {
           Game.Scene.GetComponent<UIComponent>().Create(LandUIType.LandLogin);
       }
    }

    [Event(UIEventType.LandInitSetUserInfo)]
    public class LandInitUserInfo_CreateSetUserInfo : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Create(LandUIType.SetUserInfo);
        }
    }

    [Event(UIEventType.LandSetUserInfoFinish)]
    public class LandSetUserInfoFinish : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Remove(LandUIType.SetUserInfo);
        }
    }


}