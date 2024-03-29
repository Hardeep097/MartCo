﻿using MartCo.Database;
using MartCo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartCo.Services
{
    public class ConfigurationsService
    {

        #region Singleton
        public static ConfigurationsService Instance
        {
            get
            {
                if (instance == null) instance = new ConfigurationsService();

                return instance;

            }
        }
        private static ConfigurationsService instance { get; set; }
        private ConfigurationsService()
        {

        }
        #endregion

        //public static ConfigurationsService ClassObject {
        //    get
        //    {
        //        if (privateInMemoryObject == null) privateInMemoryObject = new ConfigurationsService();

        //        return privateInMemoryObject;

        //    }
        //}
        //private static ConfigurationsService privateInMemoryObject { get; set; }
        //private ConfigurationsService()
        //{

        //}
        public Config GetConfig(String Key)
        {
            using (var context = new MCContext())
            {
                //return context.Configurations.Where(x => x.Key == Key).FirstOrDefault();
                //return context.Configurations.FirstOrDefault();
                return context.Configurations.Find(Key);
            }
        }
    }
}
