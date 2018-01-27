using UnityEngine;
using IronPython.Hosting;

namespace Exodrifter.UnityPython.Examples
{
	public class PythonLibrary : MonoBehaviour
	{
		void Start()
		{
			var engine = Python.CreateEngine();
			var scope = engine.CreateScope();

			// Add the python library path to the engine. Note that this will
			// not work for builds; you will need to manually place the python
			// library files in a place that your code can find it at runtime.
			var paths = engine.GetSearchPaths();
			if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor) {
				print (Application.dataPath + "/StreamingAssets/Python/Lib");
				paths.Add (Application.dataPath + "/StreamingAssets/Python/Lib");
			}
			// Not tested on android yet, since the files are compressed, it may require a WWW call to get them first.
			if (Application.platform == RuntimePlatform.Android) {
				paths.Add ("jar:file://" + Application.dataPath + "!/assets/Python/Lib");
			}
			engine.SetSearchPaths (paths);

			string code = @"
import os
filename = os.path.abspath ('test.txt');";

			var source = engine.CreateScriptSourceFromString(code);
			source.Execute(scope);

			Debug.Log(scope.GetVariable<string>("filename"));
		}
	}
}