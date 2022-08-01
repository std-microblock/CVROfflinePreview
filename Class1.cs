using ABI_RC.Core.IO;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using System.Threading.Tasks;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using ABI_RC.Core.Savior;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Specialized;
using System.Net;
using ABI_RC.Core.Extensions;

namespace CVROfflinePreview
{
    public class CVROfflinePreview : MelonMod
    {


        Form1 ctrlForm = new Form1();
        public override void OnUpdate()
        {
            
            if (Input.GetKeyDown(KeyCode.R))
                {
                    ctrlForm.Show();
                }
        }

    }
}
