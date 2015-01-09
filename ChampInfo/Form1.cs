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
			Connectorclass grabChampion =  new Connectorclass(1);
			var champion = grabChampion.GetChampDTO();
			SpellQ.Text = champion.Spells[0].Name;
			SpellW.Text = champion.Spells[1].Name;
			SpellE.Text = champion.Spells[2].Name;
			SpellR.Text = champion.Spells[3].Name;
			QInfo.Text = champion.Spells[0].SanitizedDescription;
			WInfo.Text = champion.Spells[1].SanitizedDescription;
			EInfo.Text = champion.Spells[2].SanitizedDescription;
			RInfo.Text = champion.Spells[3].SanitizedDescription;
		}
	}
}
