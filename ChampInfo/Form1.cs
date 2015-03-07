using System;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
            Connectorclass grabChampion = new Connectorclass(Convert.ToInt32(textBox1.Text));
            var champion = grabChampion.GetChampDTO();
            NameLabel.Text = champion.Name;
            SpellQ.Text = champion.Spells[0].Name;
            SpellW.Text = champion.Spells[1].Name;
            SpellE.Text = champion.Spells[2].Name;
            SpellR.Text = champion.Spells[3].Name;
            var cleanQTooltip = champion.Spells[0].SanitizedTooltip;
            for (int i = 1; i <= 9; i++)
            {
                cleanQTooltip = cleanQTooltip.Replace("{{ e" + i + " }}", GetEInfo(champion, 0, i));
            }

            for (int i = 1; i <= 9; i++)
            {
                cleanQTooltip = cleanQTooltip.Replace("{{ a" + i + " }}", GetAInfo(champion, 0, "a" + i));
            }

            var cleanWTooltip = champion.Spells[1].SanitizedTooltip;
            for (int i = 1; i <= 9; i++)
            {
                cleanWTooltip = cleanWTooltip.Replace("{{ e" + i + " }}", GetEInfo(champion, 1, i));
            }

            for (int i = 1; i <= 9; i++)
            {
                cleanWTooltip = cleanWTooltip.Replace("{{ a" + i + " }}", GetAInfo(champion, 1, "a" + i));
            }

            var cleanETooltip = champion.Spells[2].SanitizedTooltip;
            for (int i = 1; i <= 9; i++)
            {
                cleanETooltip = cleanETooltip.Replace("{{ e" + i + " }}", GetEInfo(champion, 2, i));
            }

            for (int i = 1; i <= 9; i++)
            {
                cleanETooltip = cleanETooltip.Replace("{{ a" + i + " }}", GetAInfo(champion, 2, "a" + i));
            }

            var cleanRTooltip = champion.Spells[3].SanitizedTooltip;
            for (int i = 1; i <= 9; i++)
            {
                cleanRTooltip = cleanRTooltip.Replace("{{ e" + i + " }}", GetEInfo(champion, 3, i));
            }

            for (int i = 1; i <= 9; i++)
            {
                cleanRTooltip = cleanRTooltip.Replace("{{ a" + i + " }}", GetAInfo(champion, 3, "a" + i));
            }

            QInfo.Text = cleanQTooltip;
            WInfo.Text = cleanWTooltip;
            EInfo.Text = cleanETooltip;
            RInfo.Text = cleanRTooltip;
            QInfo.Text += @"  Range: " + champion.Spells[0].RangeBurn;
            WInfo.Text += @"  Range: " + champion.Spells[1].RangeBurn;
            EInfo.Text += @"  Range: " + champion.Spells[2].RangeBurn;
            RInfo.Text += @"  Range: " + champion.Spells[3].RangeBurn;
            QInfo.Text += @" Cost: " + champion.Spells[0].CostBurn + @" " + champion.Spells[0].CostType;
            WInfo.Text += @" Cost: " + champion.Spells[1].CostBurn + @" " + champion.Spells[1].CostType;
            EInfo.Text += @" Cost: " + champion.Spells[2].CostBurn + @" " + champion.Spells[2].CostType;
            RInfo.Text += @" Cost: " + champion.Spells[3].CostBurn + @" " + champion.Spells[3].CostType;
        }

/*
        private string GetBasedmg(ChampDTO champion, int spellSlot)
        {
            var returnstring = champion.Spells[spellSlot].Effect[1].Aggregate("",
                (current, effect) => current + (effect.ToString(CultureInfo.InvariantCulture) + "/"));
            returnstring = returnstring.Substring(0, returnstring.Length - 1);
            return returnstring;
        }
*/

        private static string GetAInfo(ChampDTO champion, int spellSlot, string key)
        {
            var returnstring = string.Empty;
            var effect = champion.Spells[spellSlot];
            if (effect.Vars == null)
            {
                return "false Information";
            }

            returnstring =
                effect.Vars.Where(variable => variable.Key == key)
                    .SelectMany(variable => variable.Coeff)
                    .Aggregate(returnstring, (current, helpervar) => current + (Convert.ToDecimal(helpervar) + "/"));
            try
            {
                returnstring = returnstring.Substring(0, returnstring.Length - 1);
            }
            catch (Exception)
            {
                returnstring = string.Empty;
            }

            return returnstring;
        }

        private static string GetEInfo(ChampDTO champion, int spellSlot, int position)
        {
            var returnstring = string.Empty;
            var effect = champion.Spells[spellSlot];
            try
            {
                return effect.EffectBurn[position];
            }
            catch (Exception)
            {
                return string.Empty;
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

/*
        private enum Index
        {
            Empty = 0,
            E1 = 1,
            E2 = 2,
            E3 = 3,
            E4 = 4,
            E5 = 5,
            E6 = 6
        }
*/
    }
}