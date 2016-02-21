using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

public class formatScript : MonoBehaviour {

	public static string GetMd5Hash(string input) {
		MD5 md5Hash = MD5.Create();

		byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

		StringBuilder sBuilder = new StringBuilder();

		for (int i = 0; i < data.Length; i++) {
			sBuilder.Append(data[i].ToString("x2"));
		}

		return sBuilder.ToString();
	}

	public static string GetFormattedName(string theName) {
		theName = theName.Replace (" ",""); // Remove Spaces
		theName = theName.ToLower (); // Lowercase all
		theName = char.ToUpper(theName[0]) + theName.Substring(1); // Capitalize First Letter
		return theName;
	}

	public static int GetRandInt(int startNum, int endNum) {
		return (int)(Random.Range ((float)startNum,(float)endNum)+0.5f);
	}
}
