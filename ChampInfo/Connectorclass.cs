using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace ChampInfo
{
	internal class Connectorclass
	{
		private readonly ChampDTO _champ;

		public Connectorclass(int champid)
		{
			string jsonraw;
			WebResponse response;
			var uri = "http://cdn.leagueoflegends.com/patcher/data/locales/en_US/champData/champData" + champid + ".json";
			var connectionListener = WebRequest.Create(uri);
			connectionListener.ContentType = "application/json; charset=utf-8";
			try
			{
				response = connectionListener.GetResponse();
			}
			catch (WebException e)
			{
				response = null;
				_champ = null;
				return;
			}
			using (var sr = new StreamReader(response.GetResponseStream()))
			{
				jsonraw = sr.ReadToEnd();
			}
			var tempjson = JsonConvert.DeserializeObject<ChampDTO>(jsonraw);
			_champ = tempjson;
		}

		public ChampDTO GetChampDTO()
		{
			return _champ;
		}
	}
}