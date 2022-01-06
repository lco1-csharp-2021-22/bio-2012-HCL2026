using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIO2012Q2
{
	class Program
	{
		static void Main(string[] args)
		{
			string flipping = "GHIJKL";
			string t = "AE";
			int times = 100;
			List<char> flipList = new List<char> { };
			foreach(char c in flipping.ToCharArray())
			{
				flipList.Add(c);
			}
			List<string> table = new List<string> 
			{
				"ADEF",
				"BCGH",
				"CBIJ",
				"DAKL",
				"EAMN",
				"FANO",
				"GBOP",
				"HBPQ",
				"ICQR",
				"JCRS",
				"KDST",
				"LDTM",
				"MULE",
				"NUEF",
				"OVFG",
				"PVGH",
				"QWHI",
				"RWIJ",
				"SXJK",
				"TXKL",
				"UVMN",
				"VUOP",
				"WXQR",
				"XWST"
			};
			List<List<char>> stations = new List<List<char>> { };
			foreach(string s in table)
			{
				List<char> temp = new List<char> { };
				foreach(char c in s.ToCharArray())
				{
					temp.Add(c);
				}
				stations.Add(temp);
			}
			for (int i = 0; i < times; i++)
			{
				t = nextWay(t, ref stations, ref flipList);
			}
			Console.WriteLine(t);
			Console.ReadKey();
		}

		static int findSta(char c, ref List<List<char>> stations)
		{
			for(int i = 0; i < 24; i++)
			{
				if (stations[i][0] == c)
				{
					return i;
				}
			}
			return -1;
		}

		static char findWay(int i, char c, ref List<List<char>> stations, ref List<char> flipList)
		{
			int from = stations[i].IndexOf(c);
			if(from >= 2)
			{
				if (!flipList.Contains(stations[i][0]))
				{
					if(from == 3)
					{
						char temp = stations[i][2];
						stations[i][2] = stations[i][3];
						stations[i][3] = temp;
					}
				}
				return stations[i][1];
			}
			else if(from == 1)
			{
				char w = stations[i][2];
				if (flipList.Contains(stations[i][0]))
				{
					char temp = stations[i][2];
					stations[i][2] = stations[i][3];
					stations[i][3] = temp;
				}
				return w;
			}
			return ' ';
		}

		static string nextWay(string way, ref List<List<char>> stations, ref List<char> flipList)
		{
			int i = findSta(char.Parse(way.Substring(1,1)) , ref stations);
			char w = findWay(i, char.Parse(way.Substring(0, 1)), ref stations, ref flipList);
			StringBuilder sb = new StringBuilder();
			sb.Append(char.Parse(way.Substring(1, 1)));
			sb.Append(w);
			return sb.ToString();
		}
	}
}
