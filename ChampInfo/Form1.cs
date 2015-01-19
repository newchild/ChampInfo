using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
			var cleanQTooltip = champion.Spells[0].SanitizedTooltip.Replace("{{ a1 }}", getScaling(champion, 0));
			for (int i = 1; i <= 6; i++)
			{
				
				cleanQTooltip = cleanQTooltip.Replace("{{ e" + i  + " }}", getEInfo(champion, 0,i));
			}
			var cleanWTooltip = champion.Spells[1].SanitizedTooltip.Replace("{{ a1 }}", getScaling(champion, 0));
			for (int i = 1; i <= 6; i++)
			{
				
				cleanWTooltip = cleanWTooltip.Replace("{{ e" + i  + " }}", getEInfo(champion, 1,i));
			}
			var cleanETooltip = champion.Spells[2].SanitizedTooltip.Replace("{{ a1 }}", getScaling(champion, 0));
			for (int i = 1; i <= 6; i++)
			{
				
				cleanETooltip = cleanETooltip.Replace("{{ e" + i  + " }}", getEInfo(champion, 2,i));
			}
			var cleanRTooltip = champion.Spells[3].SanitizedTooltip.Replace("{{ a1 }}", getScaling(champion, 0));
			for (int i = 1; i <= 6; i++)
			{

				cleanRTooltip = cleanRTooltip.Replace("{{ e" + i + " }}", getEInfo(champion, 3, i));
			}
			QInfo.Text = cleanQTooltip;
			WInfo.Text = cleanWTooltip;
			EInfo.Text = cleanETooltip;
			RInfo.Text = cleanRTooltip;
		}

		private string getBasedmg(ChampDTO champion,int SpellSlot)
		{
			var returnstring = champion.Spells[SpellSlot].Effect[1].Aggregate("", (current, effect) => current + (effect.ToString() + "/"));
			returnstring = returnstring.Substring(0, returnstring.Length - 1);
			return returnstring;
		}
		private string getScaling(ChampDTO champion, int SpellSlot)
		{
			var returnstring = "";
			Var effect2;
			var effect = champion.Spells[SpellSlot];
			try
			{
				effect2 = effect.Vars[0];
			}
			catch (Exception e)
			{
				return "";
			}
			foreach (var variable in effect2.Coeff)
			{
				returnstring += Convert.ToDecimal(variable).ToString() + "/";
			}
				
			
			returnstring = returnstring.Substring(0, returnstring.Length - 1);
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
	}
}
