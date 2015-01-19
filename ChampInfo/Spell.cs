﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChampInfo
{

    public class Spell
    {


        public string Name { get; set; }


        public string SanitizedDescription { get; set; }

        public string Tooltip { get; set; }


        public string SanitizedTooltip { get; set; }


        public Leveltip Leveltip { get; set; }

        public Image Image { get; set; }

        public string Resource { get; set; }

        public int Maxrank { get; set; }

   
        public int[] Cost { get; set; }


        public string CostType { get; set; }


        public string CostBurn { get; set; }


        public double[] Cooldown { get; set; }


        public string CooldownBurn { get; set; }


        public double[][] Effect { get; set; }


        public string[] EffectBurn { get; set; }


        public Var[] Vars { get; set; }


        public object Range { get; set; }

        public string RangeBurn { get; set; }


        public string Key { get; set; }


        public Altimage[] Altimages { get; set; }
    }

}
