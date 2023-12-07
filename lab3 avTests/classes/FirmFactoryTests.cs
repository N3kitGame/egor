using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab3_av;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_av.Tests
{

    [TestClass()]
    public class FirmFactoryTests
    {
        private FirmFactory FirmFactory = new FirmFactory();
        [TestMethod()]
        public void CreateTest()
        {

            const string name = "name";
            const string country = "country";
            const string region = "region";
            const string town = "town";
            const string street = "street";
            const string postIndex = "postIndex";
            const string email = "email";
            const string websiteUrl = "websiteUrl";
            DateTime enterDate = new DateTime(2004, 4, 7);
            const string bossName = "bossName";
            const string officialBossName = "officialBossName";
            const string phoneNumber = "phoneNumber";

            Firm createdFirm = lab3_av.FirmFactory.Instance.Create(country, region, town, street, postIndex, email, websiteUrl,
                enterDate, bossName, officialBossName, phoneNumber);


            Assert.IsTrue(createdFirm.Country == country);
            Assert.IsTrue(createdFirm.Region == region);
            Assert.IsTrue(createdFirm.Town == town);
            Assert.IsTrue(createdFirm.Street == street);
            Assert.IsTrue(createdFirm.PostIndex == postIndex);
            Assert.IsTrue(createdFirm.Email == email);
            Assert.IsTrue(createdFirm.WebsiteUrl == websiteUrl);
            Assert.IsTrue(createdFirm.EnterDate == enterDate);
            Assert.IsTrue(createdFirm.Main.BossName == bossName);
            Assert.IsTrue(createdFirm.Main.OfficialBossName == officialBossName);
            Assert.IsTrue(createdFirm.Main.PhoneNumber == phoneNumber);

            foreach (var userField in lab3_av.FirmFactory.Instance.UserFields)
            {
                string fieldValue = null;
                fieldValue = createdFirm.GetField(userField);
                Assert.IsNotNull(fieldValue);
            }

            Assert.IsNotNull(createdFirm.Main);
            Assert.IsTrue(createdFirm.Main.Type.IsMain);
        }

        //создать 2 фирмы, проверить совпадение польз полей
        [TestMethod()]
        public void CreateTest_2Firms()
        {
            const string name = "name";
            const string country = "country";
            const string region = "region";
            const string town = "town";
            const string street = "street";
            const string postIndex = "postIndex";
            const string email = "email";
            const string websiteUrl = "websiteUrl";
            DateTime enterDate = new DateTime(2004, 4, 7);
            const string bossName = "bossName";
            const string officialBossName = "officialBossName";
            const string phoneNumber = "phoneNumber";

            Firm firm1 = lab3_av.FirmFactory.Instance.Create(country, region, town, street, postIndex, email, websiteUrl,
                enterDate, bossName, officialBossName, phoneNumber);

            Firm firm2 = lab3_av.FirmFactory.Instance.Create(country, region, town, street, postIndex, email, websiteUrl,
                enterDate, bossName, officialBossName, phoneNumber);

            const string value1 = "value1";
            const string value2 = "value2";

            firm1.SetField(lab3_av.FirmFactory.Instance.FieldName1, value1);
            firm2.SetField(lab3_av.FirmFactory.Instance.FieldName1, value2);

            Assert.IsFalse(firm1.GetField(lab3_av.FirmFactory.Instance.FieldName1)
                == firm2.GetField(lab3_av.FirmFactory.Instance.FieldName1));
        }

        //Создаем 2 фирмы у одной из них изменяем значение всех польз полей, проверяем, что они оказались не равны
        [TestMethod()]
        public void CreateTest_3Firms()
        {
            const string name = "name";
            const string country = "country";
            const string region = "region";
            const string town = "town";
            const string street = "street";
            const string postIndex = "postIndex";
            const string email = "email";
            const string websiteUrl = "websiteUrl";
            DateTime enterDate = new DateTime(2004, 4, 7);
            const string bossName = "bossName";
            const string officialBossName = "officialBossName";
            const string phoneNumber = "phoneNumber";

            Firm firm1 = FirmFactory.Create(country, region, town, street, postIndex, email, websiteUrl,
                enterDate, bossName, officialBossName, phoneNumber);

            Firm firm2 = FirmFactory.Create(country, region, town, street, postIndex, email, websiteUrl,
                enterDate, bossName, officialBossName, phoneNumber);

            const string value1 = "value1";
            const string value2 = "value2";
            const string value3 = "value3";
            const string value4 = "value4";
            const string value5 = "value5";
            const string value6 = "value6";


            firm1.SetField(FirmFactory.FieldName1, value1);
            firm1.SetField(FirmFactory.FieldName2, value2);
            firm1.SetField(FirmFactory.FieldName3, value3);
            firm1.SetField(FirmFactory.FieldName4, value4);
            firm1.SetField(FirmFactory.FieldName5, value5);

            firm2.SetField(FirmFactory.FieldName1, value5);
            firm2.SetField(FirmFactory.FieldName2, value4);
            firm2.SetField(FirmFactory.FieldName3, value6);
            firm2.SetField(FirmFactory.FieldName4, value2);
            firm2.SetField(FirmFactory.FieldName5, value1);

            Assert.IsFalse(firm1.GetField(FirmFactory.FieldName1)
                == firm2.GetField(FirmFactory.FieldName1));
            Assert.IsFalse(firm1.GetField(FirmFactory.FieldName2)
                == firm2.GetField(FirmFactory.FieldName2));
            Assert.IsFalse(firm1.GetField(FirmFactory.FieldName3)
                == firm2.GetField(FirmFactory.FieldName3));
            Assert.IsFalse(firm1.GetField(FirmFactory.FieldName4)
                == firm2.GetField(FirmFactory.FieldName4));
            Assert.IsFalse(firm1.GetField(FirmFactory.FieldName5)
                == firm2.GetField(FirmFactory.FieldName5));
        }
    }
}