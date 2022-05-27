using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UniverseLib;
using UniverseLib.Config;
using UniverseLib.UI;

namespace UniverseTest
{
    public class MyAttribute
    {
        public const string PLAGIN_NAME = "UniverseTest";
        public const string PLAGIN_VERSION = "22.05.27";
        public const string PLAGIN_FULL_NAME = "COM3D2.UniverseTest.Plugin";
    }

    [BepInPlugin(MyAttribute.PLAGIN_FULL_NAME, MyAttribute.PLAGIN_NAME, MyAttribute.PLAGIN_VERSION)]// 버전 규칙 잇음. 반드시 2~4개의 숫자구성으로 해야함. 미준수시 못읽어들임
    public class UniverseTest : BaseUnityPlugin
    {
        public static ManualLogSource log;
        public static ConfigFile config;

        public static UIBase myUIBase { get; private set; }
        public static UniverseTestPanel myPanel { get; private set; }

        public void Awake()
        {
            log = Logger;
            config = Config;
            log.LogMessage("Awake");

            UniverseLibConfig universeLibConfig = new UniverseLibConfig
            {
                Force_Unlock_Mouse = new bool?(false),
                Disable_EventSystem_Override = new bool?(true),
                Allow_UI_Selection_Outside_UIBase = new bool?(true)
            };
            Universe.Init(0, UniverseInit, LogHandler, universeLibConfig);
        }

        private void UniverseInit()
        {
            log.LogMessage("UniverseInit st");

            myUIBase = UniversalUI.RegisterUI(MyAttribute.PLAGIN_NAME, UiUpdate);
            myUIBase.Enabled = true;

            myPanel = new UniverseTestPanel(myUIBase, config, log);
            myPanel.Enabled = true;

            log.LogMessage("UniverseInit ed");
        }

        private void UiUpdate()
        {

        }

        private static void LogHandler(string log, LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                case LogType.Exception:
                    UniverseTest.log.LogError(log);
                    break;
                case LogType.Assert:
                case LogType.Warning:
                    UniverseTest.log.LogWarning(log);
                    break;
                case LogType.Log:
                    UniverseTest.log.LogMessage(log);
                    break;
            }
        }
    }
}
