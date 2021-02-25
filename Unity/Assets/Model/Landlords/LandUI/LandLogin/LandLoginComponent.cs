using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ETModel
{
    [ObjectSystem]
    public class LandLoginComponentAwakeSystem : AwakeSystem<LandLoginComponent>
    {
        public override void Awake(LandLoginComponent self)
        {
            self.Awake();
        }
    }

    public class LandLoginComponent:Component
    {
        //提示文本
        public Text prompt;

        public InputField account;
        public InputField password;

        //是否正在登录中（避免登录请求还没响应时连续点击登录）
        public bool isLogining;
        //是否正在注册中（避免登录请求还没响应时连续点击注册）
        public bool isRegistering;

        public void Awake()
        {
            // //获取父级"包"
            // FUI LandLogin  = this.GetParent<FUI>();

            // //初始化数据
            // AccountInput = LandLogin.Get("AccountInput");
            // PasswordInput = LandLogin.Get("PasswordInput");
            // Prompt = LandLogin.Get("Prompt");

            ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            //初始化数据
            account = rc.Get<GameObject>("Account").GetComponent<InputField>();
            password = rc.Get<GameObject>("Password").GetComponent<InputField>();
            prompt = rc.Get<GameObject>("Prompt").GetComponent<Text>();

            this.isLogining = false;
            this.isRegistering = false;

            //添加事件
            // LandLogin.Get("LoginButton").GObject.asButton.onClick.Add(() => LoginBtnOnClick());
            // LandLogin.Get("RegisterButton").GObject.asButton.onClick.Add(() => RegisterBtnOnClick());
            rc.Get<GameObject>("LoginButton").GetComponent<Button>().onClick.Add(() => LoginBtnOnClick());
            rc.Get<GameObject>("RegisterButton").GetComponent<Button>().onClick.Add(() => RegisterBtnOnClick());
        }

        private void RegisterBtnOnClick()
        {
            if (isLogining || isRegistering)
                return;
            this.isRegistering = true;
            LandHelper.Register(this.account.text, this.password.text).Coroutine();
        }

        private void LoginBtnOnClick()
        {
            if (isLogining || isRegistering)
                return;
            isLogining = true;
            LandHelper.Login(this.account.text, this.password.text).Coroutine();
        }
    }
}
