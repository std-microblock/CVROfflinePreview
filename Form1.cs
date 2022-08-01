using ABI_RC.Core.EventSystem;
using ABI_RC.Core.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine.SceneManagement;

namespace CVROfflinePreview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Closing += Form1_Closing;
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                    e.Cancel = true;
                    Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ABI_RC.Core.Base.Content.WorldJoinPrevented = true;
            SceneManager.LoadSceneAsync("Init");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watcher.Changed += new FileSystemEventHandler(onBundleGenerated);
            watcher.Created += new FileSystemEventHandler(onBundleGenerated);

            projects =getProjects();

            comboBox1.Items.AddRange(projects.ToArray());
            comboBox2.Items.AddRange(projects.ToArray());
        }

        FileSystemWatcher watcher = new FileSystemWatcher();

        long lastUpdTime = 0, lastOpenTime = 0;
        bool disableLiveReload = false;
        List<String> projects;
       

        static public List<String> getProjects() {
            List<String> tmp=new List<String>();

            var bundleFiles = Directory.GetDirectories(getBundleFilePath(""));
            foreach(var bundleFile in bundleFiles)
            {
                tmp.Add(bundleFile.Split('/', '\\').Last());
            }

            return tmp;
        }

        public enum BundleFileType
        {
            WorldBundle,AvatarBundle,Folder
        }

        static public string getBundleFilePath(string projectName,BundleFileType fileType=BundleFileType.Folder)
        {
            var localLow = Environment.ExpandEnvironmentVariables("%AppData%").Replace("Roaming", "LocalLow");

            switch (fileType)
            {
                case BundleFileType.WorldBundle:
                    {
                        return $"{localLow}/DefaultCompany/{projectName}/bundle.cvrworld";
                    }
                case BundleFileType.AvatarBundle:
                    {
                        return $"{localLow}/DefaultCompany/{projectName}/bundle.cvravatar";
                    }
                case BundleFileType.Folder:
                    {
                        return $"{localLow}/DefaultCompany/{projectName}";
                    }
                default:
                    {
                        throw new Exception("That's IMPOSSIBLE!");
                    }
            }
        }

        public void startWatching(string projectName)
        {
            watcher.Path = getBundleFilePath(projectName);

            watcher.NotifyFilter = NotifyFilters.LastWrite;

            watcher.Filter = "*.cvrworld";

            watcher.EnableRaisingEvents = true;
        }

        private void onBundleGenerated(object source, FileSystemEventArgs e)
        {
            if (disableLiveReload) return;
            
            if (e.Name.EndsWith("bundle.cvrworld"))
            {
                Task.Run(async () =>
                {
                    var nowTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                    lastUpdTime = nowTime;

                    await Task.Delay(2000);

                    if (lastUpdTime == nowTime)
                    {
                        disableLiveReload = true;
                        await LoadLocalWorld(e.FullPath);
                        lastOpenTime = nowTime;
                        disableLiveReload = false;
                    }
                });
            }
        }

        private void button1_Click(object sender, EventArgs e) { 
            if(comboBox1.SelectedIndex==-1)return;
            var proj = projects[comboBox1.SelectedIndex];

            if (File.Exists(getBundleFilePath(proj,BundleFileType.WorldBundle)))
            {
                LoadLocalWorld(getBundleFilePath(proj, BundleFileType.WorldBundle));
            }
            else
            {
                MessageBox.Show($"There's no bundle file for this project now. Please click this button only during world file upload.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (watcher.EnableRaisingEvents)
            {
                watcher.EnableRaisingEvents = false;
                button2.Text = "Start Live Reload";
            }
            else
            {
                if (comboBox1.SelectedIndex == -1) return;
                var proj = projects[comboBox1.SelectedIndex];
                startWatching(proj);
                button2.Text = "Stop Live Reload";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1) return;
            var proj = projects[comboBox2.SelectedIndex];

            if (File.Exists(getBundleFilePath(proj, BundleFileType.AvatarBundle)))
            {
                LoadLocalAvatar(getBundleFilePath(proj, BundleFileType.AvatarBundle));
            }
            else
            {
                MessageBox.Show($"There's no bundle file for this project now. Please click this button only during avatar file upload process.");
            }
        }

        public async Task LoadLocalAvatar(string localAvatar, string objectId = "00000000-0000-0000-0000-000000000000")
        {
            try
            {
                byte[] contentBytes = File.ReadAllBytes(localAvatar);

                LoadLocalAvatar(contentBytes);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed: {e.ToString()}");
            }

        }

        public void LoadLocalAvatar(byte[] localAvatar, string objectId = "00000000-0000-0000-0000-000000000000")
        {
            try
            {
                AvatarQueueSystem.Instance.AddCoroutine(
                    CVRObjectLoader.Instance.InstantiateAvatar(
                        DownloadJob.ObjectType.Avatar, new AssetManagement.AvatarTags { }, objectId, "_PLAYERLOCAL", localAvatar
                        )
                    );
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed: {e.ToString()}");
            }

        }

        public async Task LoadLocalWorld(string localWorld, string objectId = "00000000-0000-0000-0000-000000000000")
        {
            try
            {
                byte[] contentBytes = File.ReadAllBytes(localWorld);
                CVRObjectLoader.Instance.InitiateLoadIntoWorld(DownloadJob.ObjectType.World, objectId, contentBytes);
                LoadLocalAvatar(Resource1.testAvatar);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed: {e.ToString()}");
            }
        }
    }
}
