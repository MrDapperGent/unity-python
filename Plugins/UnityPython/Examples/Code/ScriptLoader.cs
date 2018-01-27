using UnityEngine;
using Microsoft.Scripting.Hosting;
using System.Collections;

public class ScriptLoader : MonoBehaviour {

	public TextAsset scriptFile;
	public bool OnAwake = true;

	private ScriptEngine thisEngine;
	private ScriptScope thisScope;
	private ScriptSource thisSource;

	private void Awake()
	{
		if (OnAwake)
			Init ();
	}

	private void Init()
	{
		thisEngine = global::UnityPython.CreateEngine();
		thisScope = thisEngine.CreateScope();
		thisSource = thisEngine.CreateScriptSourceFromString(scriptFile.text);
		thisSource.Execute(thisScope);
	}
}
