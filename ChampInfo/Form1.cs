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

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			Connectorclass grabChampion =  new Connectorclass(2);
			var champion = grabChampion.GetChampDTO();
            NameLabel.Text = champion.Name;   
			SpellQ.Text = champion.Spells[0].Name;
			SpellW.Text = champion.Spells[1].Name;
			SpellE.Text = champion.Spells[2].Name;
			SpellR.Text = champion.Spells[3].Name;
			var cleanQTooltip = champion.Spells[0].SanitizedTooltip.Replace("{{ e1 }}", getBasedmg(champion, 0)).Replace("{{ a1 }}",getScaling(champion,0));
			var cleanWTooltip = champion.Spells[1].SanitizedTooltip.Replace("{{ e1 }}", getBasedmg(champion, 1)).Replace("{{ a1 }}", getScaling(champion, 1));
			var cleanETooltip = champion.Spells[2].SanitizedTooltip.Replace("{{ e1 }}", getBasedmg(champion, 2)).Replace("{{ a1 }}", getScaling(champion, 2));
			QInfo.Text = cleanQTooltip;
			WInfo.Text = cleanWTooltip;
			EInfo.Text = cleanETooltip;
			//RInfo.Text = tooltip[3];*/
		}

		private string getBasedmg(ChampDTO champion,int SpellSlot)
		{
			var returnstring = "";
			foreach (var effect in champion.Spells[SpellSlot].Effect[1])
			{
				returnstring += effect.ToString() + "/";
			}
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
	}
}
