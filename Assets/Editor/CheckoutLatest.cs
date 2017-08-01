using System.Diagnostics;
using UnityEngine;
using UnityEditor;

public static class CheckoutLatest
{
	public static void EditorXR ()
	{
		// if you want your Cloud Build target's branch to checkout a different EditorXR branch, 
		// just change the branch variable here - this way we can have CI on any branch
		const string branch = "development";
		const string repoUrl = "https://github.com/Unity-Technologies/EditorVR";

		string gitArguments = "lfs clone --recursive -b " + branch + " " + repoUrl;

		UnityEngine.Debug.Log("running EditorXR checkout command:");
		StartProcess(gitArguments);
	}

	static void StartProcess (string command)
	{
		UnityEngine.Debug.Log("git " + command);
		ProcessStartInfo startInfo = new ProcessStartInfo("git", command);

		startInfo.WorkingDirectory = Application.dataPath;
		startInfo.UseShellExecute = false;
		startInfo.RedirectStandardInput = false;
		startInfo.RedirectStandardOutput = false;
		startInfo.RedirectStandardError = false;

		Process process = new Process();
		process.StartInfo = startInfo;
		process.Start();

		process.WaitForExit(200000);

		AssetDatabase.Refresh();
	}
}
