using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace iisewars {
	public partial class fmMain : Form {
		public fmMain() {
			InitializeComponent();
		}

		private void fmMain_Load(object sender, EventArgs e) {
			this.tbSolutionFile.Text = Properties.Settings.Default.SolutionFile;
		}

		private void btSolutionFile_Click(object sender, EventArgs e) {
			var dialog = new OpenFileDialog {
				CheckFileExists = true,
				CheckPathExists = true,
				FileName = this.tbSolutionFile.Text.Trim(),
				Filter = "Solution Files (.sln)|*.sln",
				InitialDirectory = Environment.CurrentDirectory,
				Multiselect = false,
				Title = "Select Solution File for WebApp to Use"
			};

			if (dialog.ShowDialog(this) != DialogResult.OK)
				return;

			this.tbSolutionFile.Text = dialog.FileName;

			Properties.Settings.Default.SolutionFile = dialog.FileName;
			Properties.Settings.Default.Save();
		}

		private void btGo_Click(object sender, EventArgs e) {
			if (!File.Exists(this.tbSolutionFile.Text.Trim())) {
				MessageBox.Show(
					"Selected solution file does not exist.",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			// Get localhost IP.
			var ipAddress = string.Empty;

			foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
				if (ip.AddressFamily == AddressFamily.InterNetwork)
					ipAddress = ip.ToString();

			if (string.IsNullOrWhiteSpace(ipAddress)) {
				MessageBox.Show(
					"Could not find IP for localhost.",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			// Get WebApp port.
			var assemblyName = string.Empty;
			var webAppPort = 0;
			var solutionLines = File.ReadAllLines(this.tbSolutionFile.Text.Trim());
			var projects = new List<string>();
			var path = this.tbSolutionFile.Text.Trim();

			path = path.Substring(0, path.LastIndexOf(@"\", StringComparison.InvariantCultureIgnoreCase));

			foreach (var line in solutionLines) {
				if (!line.Contains(".csproj"))
					continue;

				var filename = line.Substring(0, line.IndexOf(".csproj", StringComparison.InvariantCultureIgnoreCase) + ".csproj".Length);
				filename = filename.Substring(filename.LastIndexOf("\"", StringComparison.InvariantCultureIgnoreCase) + 1);

				projects.Add(
					string.Format(
						"{0}\\{1}",
						path,
						filename));
			}

			foreach (var pathname in projects) {
				var projectLines = File.ReadAllLines(pathname);

				foreach (var line in projectLines) {
					if (line.Contains("AssemblyName") &&
					    line.Contains("/AssemblyName")) {
						assemblyName = line.Substring(line.IndexOf("<AssemblyName>", StringComparison.InvariantCultureIgnoreCase) + "<AssemblyName>".Length);
						assemblyName = assemblyName.Substring(0, assemblyName.IndexOf("<", StringComparison.InvariantCultureIgnoreCase));
					}

					if (line.Contains("DevelopmentServerPort") &&
					    line.Contains("/DevelopmentServerPort")) {
						var developmentServerPort = line.Substring(line.IndexOf("<DevelopmentServerPort>", StringComparison.InvariantCultureIgnoreCase) + "<DevelopmentServerPort>".Length);
						developmentServerPort = developmentServerPort.Substring(0, developmentServerPort.IndexOf("<", StringComparison.InvariantCultureIgnoreCase));
						int.TryParse(developmentServerPort, out webAppPort);
					}
				}
			}

			if (string.IsNullOrWhiteSpace(assemblyName)) {
				MessageBox.Show(
					"Could not determine webapp assemblyname from solution.",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			if (webAppPort == 0) {
				MessageBox.Show(
					"Could not determine webapp port from solution.",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			// Step 1: Configure IIS Express with Local IP.
			var outputLines = new List<string>();
			var configFile = string.Format(
				"{0}\\IISExpress\\config\\applicationhost.config",
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
			var configLines = File.ReadAllLines(configFile);
			var foundEntry = configLines.Any(line => line.Contains(string.Format("{0}:{1}:{0}", ipAddress, webAppPort)));

			if (!foundEntry) {
				foreach (var line in configLines) {
					outputLines.Add(
						line);

					if (line.Contains(string.Format("*:{0}:localhost", webAppPort)))
						outputLines.Add(
							string.Format("                    <binding protocol=\"http\" bindingInformation=\"{0}:{1}:{0}\" />", ipAddress, webAppPort));
				}

				try {
					File.WriteAllLines(
						configFile,
						outputLines.ToArray());
				}
				catch (Exception ex) {
					MessageBox.Show(
						ex.Message,
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);

					return;
				}
			}

			this.pbStep1.Visible = true;
			this.lbStep1.ForeColor = SystemColors.ControlText;

			Application.DoEvents();
			Thread.Sleep(100);

			// Step 2: Enable Access to the URL for All Users.
			try {
				Process.Start(
					new ProcessStartInfo {
						FileName = string.Format("{0}\\System32\\netsh.exe", Environment.ExpandEnvironmentVariables("%SystemRoot%")),
						Arguments = string.Format("http add urlacl url=http://{0}:{1}/ user=everyone", ipAddress, webAppPort),
						Verb = "runas",
						WindowStyle = ProcessWindowStyle.Hidden
					});
			}
			catch (Exception ex) {
				MessageBox.Show(
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			this.pbStep2.Visible = true;
			this.lbStep2.ForeColor = SystemColors.ControlText;

			Application.DoEvents();
			Thread.Sleep(100);

			// Step 3: Open the Port in Windows Firewall.
			try {
				var fwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);
				var fwMgr = (INetFwMgr) Activator.CreateInstance(fwMgrType);
				var fwPorts = fwMgr.LocalPolicy.CurrentProfile.GloballyOpenPorts;
				var fwPortEnumerator = fwPorts.GetEnumerator();
				var fwAppPortFound = false;
				INetFwOpenPort fwAppPort = null;

				while (fwPortEnumerator.MoveNext()) {
					fwAppPort = (INetFwOpenPort) fwPortEnumerator.Current;

					if (fwAppPort.Port != webAppPort)
						continue;

					fwAppPortFound = true;
					break;
				}

				if (!fwAppPortFound)
					fwPorts.Add(fwAppPort);
			}
			catch (Exception ex) {
				MessageBox.Show(
					ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);

				return;
			}

			this.pbStep3.Visible = true;
			this.lbStep3.ForeColor = SystemColors.ControlText;
		}
	}
}