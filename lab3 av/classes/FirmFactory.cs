﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_av
{
    //создаёт фирму
    public class FirmFactory
    {
        public static FirmFactory Instance { get; private set; } = null;
        //пользовательские поля
        public readonly string FieldName1 = "field1";
        public readonly string FieldName2 = "field2";
        public readonly string FieldName3 = "field3";
        public readonly string FieldName4 = "field4";
        public readonly string FieldName5 = "field5";
        //сделать список
        public readonly List<string> UserFields = new List<string>();
        private const string MainFirmName = "Main Firm";

        public FirmFactory()
        {
            if (Instance != null)
            {
                // throw new InvalidOperationException("Only one instance of FirmFactory possible");
            }
            Instance = this;
            UserFields.Add(FieldName1);
            UserFields.Add(FieldName2);
            UserFields.Add(FieldName3);
            UserFields.Add(FieldName4);
            UserFields.Add(FieldName5);
        }
        //создание фирмы
        public Firm Create(string country, string region,
            string town, string street, string postIndex, string email,
            string websiteUrl, DateTime enterDate,
            string bossName, string officialBossName, string phoneNumber)
        {
            Firm firm = new Firm(MainFirmName, country, region, town, street,
                postIndex, email, websiteUrl, enterDate, bossName,
                officialBossName, phoneNumber);

            FillUserFields(firm);
            return firm;
        }
        
        public void FillUserFields(Firm firm)
        {
            foreach (var pair in UserFields)
            {
                firm.AddField(pair);
            }
        }
    }
}
