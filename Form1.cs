using ABI_RC.Core.EventSystem;
using ABI_RC.Core.IO;
using ABI_RC.Core.Player;
using ABI_RC.Core.Util;
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
using static ABI_RC.Core.Util.CVRSyncHelper;

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

        private void forceInit_Click(object sender, EventArgs e)
        {

            SceneManager.LoadSceneAsync("Init");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watcher.Changed += new FileSystemEventHandler(onBundleGenerated);
            watcher.Created += new FileSystemEventHandler(onBundleGenerated);

            projects = getProjects();

            localMapSelect.Items.AddRange(projects.ToArray());
            localAvatarSelect.Items.AddRange(projects.ToArray());
            localPropSelect.Items.AddRange(projects.ToArray());
        }

        FileSystemWatcher watcher = new FileSystemWatcher();

        long lastUpdTime = 0, lastOpenTime = 0;
        bool disableLiveReload = false;
        List<String> projects;


        static public List<String> getProjects()
        {
            List<String> tmp = new List<String>();

            var bundleFiles = Directory.GetDirectories(getBundleFilePath(""));
            foreach (var bundleFile in bundleFiles)
            {
                tmp.Add(bundleFile.Split('/', '\\').Last());
            }

            return tmp;
        }

        public enum BundleFileType
        {
            WorldBundle, AvatarBundle, Folder, Spawnable
        }

        static public string getBundleFilePath(string projectName, BundleFileType fileType = BundleFileType.Folder)
        {
            var localLow = Environment.ExpandEnvironmentVariables("%AppData%").Replace("Roaming", "LocalLow");

            switch (fileType)
            {
                case BundleFileType.Spawnable:
                    {
                        return $"{localLow}/DefaultCompany/{projectName}/bundle.cvrprop";
                    }
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
                        LoadLocalWorld(e.FullPath);
                        lastOpenTime = nowTime;
                        disableLiveReload = false;
                    }
                });
            }
        }

        private void btnLoadMapClick(object sender, EventArgs e)
        {
            if (localMapSelect.SelectedIndex == -1) return;
            var proj = projects[localMapSelect.SelectedIndex];

            if (File.Exists(getBundleFilePath(proj, BundleFileType.WorldBundle)))
            {
                LoadLocalWorld(getBundleFilePath(proj, BundleFileType.WorldBundle));
            }
            else
            {
                MessageBox.Show($"There's no bundle file for this project now. Please click this button only during world file upload.");
            }
        }

        private void btnMapLiveReloadClick(object sender, EventArgs e)
        {
            if (watcher.EnableRaisingEvents)
            {
                watcher.EnableRaisingEvents = false;
                btnMapLiveReload.Text = "Start Live Reload";
                localMapSelect.Enabled = true;
            }
            else
            {
                if (localMapSelect.SelectedIndex == -1) return;
                var proj = projects[localMapSelect.SelectedIndex];
                startWatching(proj);
                localMapSelect.Enabled = false;
                btnMapLiveReload.Text = "Stop Live Reload";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadAvatrClick(object sender, EventArgs e)
        {
            if (localAvatarSelect.SelectedIndex == -1) return;
            var proj = projects[localAvatarSelect.SelectedIndex];

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

        public void LoadLocalProp(string localProp)
        {
            try
            {
                byte[] contentBytes = File.ReadAllBytes(localProp);

                LoadLocalProp(contentBytes, float.Parse(propPosX.Text)
                                          , float.Parse(propPosY.Text)
                                          , float.Parse(propPosZ.Text));
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed: {e.ToString()}");
            }

        }

        public void LoadLocalProp(byte[] localProp, float PosX, float PosY, float PosZ, string objectId = "00000000-0000-0000-0000-000000000000")
        {
            try
            {
                var propData = new PropData();

                propData.ObjectId = objectId;
                propData.InstanceId = Guid.NewGuid().ToString();

                propData.PositionX = PosX;
                propData.PositionY = PosY;
                propData.PositionZ = PosZ;
                propData.RotationX = 0;
                propData.RotationY = 0;
                propData.RotationZ = 0;

                CVRSyncHelper.Props.Add(propData);

                PropQueueSystem.Instance.AddCoroutine(
                    CVRObjectLoader.Instance.InstantiateProp(
                        DownloadJob.ObjectType.Prop, new AssetManagement.PropTags { }, objectId, propData.InstanceId, localProp
                        )
                    );
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed: {e.ToString()}");
            }

        }

        private void btnLoadPropClick(object sender, EventArgs e)
        {
            if (localPropSelect.SelectedIndex == -1) return;
            var proj = projects[localPropSelect.SelectedIndex];

            if (File.Exists(getBundleFilePath(proj, BundleFileType.Spawnable)))
            {
                LoadLocalProp(getBundleFilePath(proj, BundleFileType.Spawnable));
            }
            else
            {
                MessageBox.Show($"There's no bundle file for this project now. Please click this button only during avatar file upload process.");
            }
        }

        private void localPropSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void getPlayerPos_Click(object sender, EventArgs e)
        {
                var pos=ABI_RC.Core.Player.PlayerSetup.Instance.transform.position;

                 propPosX.Text = pos.x.ToString();
                 propPosY.Text = pos.y.ToString();
                 propPosZ.Text = pos.z.ToString();
        }

        public void LoadLocalWorld(string localWorld, string objectId = "00000000-0000-0000-0000-000000000000")
        {
            try
            {
                byte[] contentBytes = File.ReadAllBytes(localWorld);
                CVRObjectLoader.Instance.InitiateLoadIntoWorld(DownloadJob.ObjectType.World, objectId, contentBytes);
                if (loadDefaultAvatar.Checked)
                {
                    LoadLocalAvatar(Resource1.testAvatar);
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show($"Failed: {e.ToString()}");
            }
        }
    }
}
