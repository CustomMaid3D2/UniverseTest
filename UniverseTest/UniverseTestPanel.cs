using BepInEx.Configuration;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.UI;
using UniverseLib.UI;
using UniverseLib.UI.Panels;

namespace UniverseTest
{
    public class UniverseTestPanel : PanelBase
    {
        public static ManualLogSource log;
        public static ConfigFile config;

        public UniverseTestPanel(UIBase owner, BepInEx.Configuration.ConfigFile Config, ManualLogSource Logger) : base(owner)
        {
            log = Logger;
            config = Config;
            log.LogMessage("UniverseTestPanel");
        }

        public override string Name => MyAttribute.PLAGIN_NAME;
        public override int MinWidth => 200;
        public override int MinHeight => 600;
        public override Vector2 DefaultAnchorMin => new Vector2(0.25f, 0.25f);
        public override Vector2 DefaultAnchorMax => new Vector2(0.75f, 0.75f);
        public override bool CanDragAndResize => true;

        protected override void ConstructPanelContent()
        {
            log.LogMessage("ConstructPanelContent");
            Text myText = UIFactory.CreateLabel(ContentRoot, "myText", "Hello world");
            UIFactory.SetLayoutElement(myText.gameObject, minWidth: 200, minHeight: 25);
        }
    }
}