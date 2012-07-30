/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.16
 * Time: 17:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Minder.Tools
{
	/// <summary>
	/// Description of PathCutHelper.
	/// </summary>
	public class PathCutHelper
	{
		public PathCutHelper()
		{
		}
		
		public string CutExecutableFileFromPath(string path)
		{
			if(string.IsNullOrEmpty(path))
				return string.Empty;
			string[] spliter = path.Split('\\');
			int executableFileLenght = spliter[spliter.Length-1].Length;
			
			string result = path.Substring(0, path.Length-executableFileLenght-1);
			return result;
		}
	}
}
