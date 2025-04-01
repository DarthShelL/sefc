using ClientPlugin.Settings;
using ClientPlugin.Settings.Layouts;
using HarmonyLib;
using Sandbox.Game.Entities;
using Sandbox.Game.Gui;
using Sandbox.Game.World;
using Sandbox.Graphics.GUI;
using Sandbox.ModAPI;
using SpaceEngineers.Game.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VRage.GameServices;
using VRage.Plugins;
using VRageMath;

namespace ClientPlugin
{
    // ReSharper disable once UnusedType.Global
    public class Plugin : IPlugin, IDisposable
    {
        public const string Name = "DarthsPlugin";
        public static Plugin Instance { get; private set; }
        private SettingsGenerator settingsGenerator;

        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public void Init(object gameInstance)
        {
            Instance = this;
            Instance.settingsGenerator = new SettingsGenerator();

            // TODO: Put your one time initialization code here.
            Harmony harmony = new Harmony(Name);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void Dispose()
        {
            // TODO: Save state and close resources here, called when the game exits (not guaranteed!)
            // IMPORTANT: Do NOT call harmony.UnpatchAll() here! It may break other plugins.

            Instance = null;
        }

        public void Update()
        {
            // TODO: Put your update code here. It is called on every simulation frame!

            if (MySession.Static.LocalHumanPlayer.Controller.ControlledEntity != null)
            {
                MyCubeBlock myCubeBlock1 = MySession.Static.LocalHumanPlayer.Controller.ControlledEntity as MyCubeBlock;
                MyCubeGrid MyGrid = myCubeBlock1.CubeGrid;

                float baseMass;
                float physicalMass;
                MyGrid.GetCurrentMass(out baseMass, out physicalMass);
                Vector3 velocity = MyGrid.GetPhysicsBody().LinearVelocity;


                MyHud.Chat.ShowMessage("Darth's plugin", "FUCK!", Color.Red);
            }
            //MyGuiManager.DrawString("Debug", "Fuck", new VRageMath.Vector2(-0.5f, -0.5f), 1f, null, VRage.Utils.MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP, true);
            //MyCubeGrid.
        }

        // ReSharper disable once UnusedMember.Global
        public void OpenConfigDialog()
        {
            Instance.settingsGenerator.SetLayout<Simple>();
            MyGuiSandbox.AddScreen(Instance.settingsGenerator.Dialog);
        }

        //TODO: Uncomment and use this method to load asset files
        /*public void LoadAssets(string folder)
        {

        }*/
    }
}