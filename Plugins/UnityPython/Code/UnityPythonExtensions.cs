using Microsoft.Scripting.Hosting;
using System.Collections.Generic;

public static class UnityPythonExtensions {

	public static ICollection<string> GetUnitySearchPaths(this ScriptEngine engine)
	{
		var paths = engine.GetSearchPaths ();
		if (paths.Contains (".")) {
			paths.Remove (".");
		}
		return paths;
	}

	public static void EmptySearchPaths(this ScriptEngine engine)
	{
		var paths = engine.GetSearchPaths ();
		paths.Clear ();
		engine.SetSearchPaths (paths);
	}

}