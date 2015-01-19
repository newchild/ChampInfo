using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChampInfo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private enum Index
		{
			empty = 0,
			e1 = 1,
			e2 = 2,
			e3 = 3,
			e4 = 4,
			e5 = 5,
			e6 = 6

		}
		private void ConnectButton_Click(object sender, EventArgs e)
		{
			Connectorclass grabChampion =  new Connectorclass(Convert.ToInt32(textBox1.Text));
			var champion = grabChampion.GetChampDTO();
            NameLabel.Text = champion.Name;   
			SpellQ.Text = champion.Spells[0].Name;
			SpellW.Text = champion.Spells[1].Name;
			SpellE.Text = champion.Spells[2].Name;
			SpellR.Text = champion.Spells[3].Name;
			var cleanQTooltip = champion.Spells[0].SanitizedTooltip;
			for (int i = 1; i <= 9; i++)
			{
				
				cleanQTooltip = cleanQTooltip.Replace("{{ e" + i  + " }}", getEInfo(champion, 0,i));
			}
			for (int i = 1; i <= 9; i++)
			{

				cleanQTooltip = cleanQTooltip.Replace("{{ a" + i + " }}", getAInfo(champion, 0, "a" + i));
			}
			var cleanWTooltip = champion.Spells[1].SanitizedTooltip;
			for (int i = 1; i <= 9; i++)
			{
				
				cleanWTooltip = cleanWTooltip.Replace("{{ e" + i  + " }}", getEInfo(champion, 1,i));
			}
			for (int i = 1; i <= 9; i++)
			{

				cleanWTooltip = cleanWTooltip.Replace("{{ a" + i + " }}", getAInfo(champion, 1, "a" + i));
			}
			var cleanETooltip = champion.Spells[2].SanitizedTooltip;
			for (int i = 1; i <= 9; i++)
			{
				
				cleanETooltip = cleanETooltip.Replace("{{ e" + i  + " }}", getEInfo(champion, 2,i));
			}
			for (int i = 1; i <= 9; i++)
			{

				cleanETooltip = cleanETooltip.Replace("{{ a" + i + " }}", getAInfo(champion, 2, "a" + i));
			}
			var cleanRTooltip = champion.Spells[3].SanitizedTooltip;
			for (int i = 1; i <= 9; i++)
			{

				cleanRTooltip = cleanRTooltip.Replace("{{ e" + i + " }}", getEInfo(champion, 3, i));
			}
			for (int i = 1; i <= 9; i++)
			{

				cleanRTooltip = cleanRTooltip.Replace("{{ a" + i + " }}", getAInfo(champion, 3, "a" + i));
			}
			QInfo.Text = cleanQTooltip;
			WInfo.Text = cleanWTooltip;
			EInfo.Text = cleanETooltip;
			RInfo.Text = cleanRTooltip;
			QInfo.Text += "  Range: " + champion.Spells[0].RangeBurn;
			WInfo.Text += "  Range: " + champion.Spells[1].RangeBurn;
			EInfo.Text += "  Range: " + champion.Spells[2].RangeBurn;
			RInfo.Text += "  Range: " + champion.Spells[3].RangeBurn;
			QInfo.Text += " Cost: " + champion.Spells[0].CostBurn + " " + champion.Spells[0].CostType;
			WInfo.Text += " Cost: " + champion.Spells[1].CostBurn + " " + champion.Spells[1].CostType;
			EInfo.Text += " Cost: " + champion.Spells[2].CostBurn + " " + champion.Spells[2].CostType;
			RInfo.Text += " Cost: " + champion.Spells[3].CostBurn + " " + champion.Spells[3].CostType;
		}

		private string getBasedmg(ChampDTO champion,int SpellSlot)
		{
			var returnstring = champion.Spells[SpellSlot].Effect[1].Aggregate("", (current, effect) => current + (effect.ToString() + "/"));
			returnstring = returnstring.Substring(0, returnstring.Length - 1);
			return returnstring;
		}
		private string getAInfo(ChampDTO champion, int SpellSlot, string key)
		{
			var returnstring = "";
			var effect = champion.Spells[SpellSlot];
			if (effect.Vars == null)
			{
				return "false Information";
			}
			foreach (var variable in effect.Vars)
			{
				
				if (variable.Key == key)
				{
					foreach (var helpervar in variable.Coeff)
					{
						returnstring += Convert.ToDecimal(helpervar).ToString() + "/";
					}
				}
				
			}


			try
			{
				returnstring = returnstring.Substring(0, returnstring.Length - 1);
			}
			catch (Exception e)
			{
				returnstring = "";
			}
			return returnstring;
		}
		private string getEInfo(ChampDTO champion, int SpellSlot, int position)
		{
			var returnstring = "";
			var effect = champion.Spells[SpellSlot];
			try
			{
				return effect.EffectBurn[(int)position];
			}
			catch (Exception e)
			{
				return "";
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}
	}
}
