﻿using System.Collections.Generic;
using UnityEngine;
using RoR2;

namespace RoR2Cheats
{
    public class Alias
    {
        private static readonly Dictionary<string, string[]> BodyAlias = new Dictionary<string, string[]>();
        private static readonly Dictionary<string, string[]> MasterAlias = new Dictionary<string, string[]>();
        private static readonly Dictionary<string, string[]> ItemAlias = new Dictionary<string, string[]>();
        private static Alias instance;

        public static Alias Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Alias();
                }

                return instance;
            }
        }

        private Alias()
        {
            BodyAlias.Add("ToolbotBody", new string[] { "MULT", "MUL-T" });
            BodyAlias.Add("MercBody", new string[] { "Mercenary" });
            BodyAlias.Add("MageBody", new string[] { "Artificer" });
            BodyAlias.Add("HANDBody", new string[] { "HAN-D" });
            BodyAlias.Add("TreebotBody", new string[] { "Treebot", "REX" });

            MasterAlias.Add("DroneBackupMaster", new string[] { "DroneBackup", "BackupDrone" });
            MasterAlias.Add("DroneMissileMaster", new string[] { "DroneMissile", "MissileDrone" });
            MasterAlias.Add("LemurianBruiserMasterFire", new string[] { "LemurianBruiserFire" });
            MasterAlias.Add("LemurianBruiserMasterIce", new string[] { "LemurianBruiserIce" });
            MasterAlias.Add("LemurianBruiserMasterPoison", new string[] { "LemurianBruiserPoison", "LemurianBruiserBlight", "LemurianBruisermalechite" });
            MasterAlias.Add("MercMonsterMaster", new string[] { "MercMonster" });
        }

        public string GetItemName(string name)
        {
            string langinvar;
            //Language.SetCurrentLanguage("fr");
            foreach (KeyValuePair<string, string[]> dictEnt in ItemAlias)
            {
                foreach (string alias in dictEnt.Value)
                {
                    if (alias.ToUpper().Contains(name.ToUpper()))
                    {
                        name = dictEnt.Key.ToString();
                        
                    }
                }
            }
            //if(BodyCatalog.allBodyPrefabs.Any<>)
            foreach (var item in RoR2.ItemCatalog.allItems)
            {
                langinvar = Language.GetString("ITEM_" + item.ToString().ToUpper() + "_NAME").ToUpper();
                //Debug.Log(langinvar + ":" + item.ToString());
                if (item.ToString().ToUpper().Contains(name.ToUpper()) || langinvar.Contains(name.ToUpper())) //needs testing
                {
                    return item.ToString();
                }
            }
            return null;
        }

        public string GetBodyName(string name)
        {
            foreach (KeyValuePair<string, string[]> dictEnt in BodyAlias)
            {
                foreach(string alias in dictEnt.Value)
                {
                    if (alias.ToUpper().Contains(name.ToUpper()))
                    {
                        name = dictEnt.Key.ToString();
                    }
                }
            }
            //if(BodyCatalog.allBodyPrefabs.Any<>)
            foreach(var body in RoR2.BodyCatalog.allBodyPrefabs)
            {
                if (body.name.ToUpper().Contains(name.ToUpper()))
                {
                    return body.name;
                }
            }
            return null;
        }

        internal string GetMasterName(string name)
        {
            foreach (KeyValuePair<string, string[]> dictEnt in MasterAlias)
            {
                foreach (string alias in dictEnt.Value)
                {
                    if (alias.ToUpper().Contains(name.ToUpper()))
                    {
                        name = dictEnt.Key.ToString();
                    }
                }
            }
            //if(BodyCatalog.allBodyPrefabs.Any<>)
            foreach (var master in RoR2.MasterCatalog.allMasters)
            {
                if (master.name.ToUpper().Contains(name.ToUpper()))
                {
                    return master.name;
                }
            }
            return null;
        }
    }
}