using NUnit.Framework;

namespace GitHubAutomation
{
    [TestFixture]
    public class SmokeTests
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void Test1()
        {
            steps.OpenPage();
            steps.SetTypeDates("8.1.2018", "", "oneway");
            steps.SetCityes("Минск, Беларусь", "Париж, Франция");
            steps.Submit();
        }

        [Test]
        public void Test2()
        {
            steps.OpenPage();
            steps.SetTypeDates("9.1.2018", "8.2.2018", "round", true);
            steps.SetCityes("Москва, Россия, Sheremetyevo", "Тель-Авив, Израиль");
            steps.Submit();
        }

        [Test]
        public void Test3()
        {
            steps.OpenPage();
            steps.SetTypeDates("8.1.2018", "", "oneway");
            steps.SetCityes("Минск, Беларусь", " ");
            steps.Submit();
            Assert.IsTrue(steps.GetErrorCity1("Введите название горда или аэропорта"));
        }

        [Test]
        public void Test4()
        {
            steps.OpenPage();
            steps.SetTypeDates("1.2.2018", "15.3.2018", "multi");
            steps.SetCityesMulti("Минск, Беларусь", "Алматы, Казахстан", "Астана, Казахстан", "Вильнюс, Литва");
            steps.Submit();
        }

        [Test]
        public void Test5()
        {
            steps.OpenPage();
            steps.SetTypeDates("1.2.2018", "", "oneway");
            steps.SetCityes("Полоцк", "Минск, Беларусь");
            steps.Submit();
            Assert.IsTrue(steps.GetErrorCity0("Такое название города или аэропорта не найдено"));
        }

        [Test]
        public void Test6()
        {
            steps.OpenPage();
            steps.SetTypeDates("8.1.2018", "", "oneway", true);
            steps.SetCityes("Берлин, Германия, все аэропорты", "Москва, Россия, все аэропорты");
            steps.SetPass(4, 1);
            steps.SetPass(1, 2);
            steps.Submit();
            steps.SelFirst();
        }

        [Test]
        public void Test7()
        {
            steps.OpenPage();
            steps.SetTypeDates("8.1.2018", "15.2.2018", "round");
            steps.SetAirline();
            steps.SetCityes("Минск, Беларусь", "Анкара, Турция, Esenboga");
            steps.Submit();
        }

        [Test]
        public void Test8()
        {
            steps.OpenPage();
            steps.SetTypeDates("1.2.2018", "28.2.2018", "round");
            steps.SetCityes("Минск, Беларусь", "Лос-Анджелес, США, International");
            steps.Submit();
            steps.SelSort("fast");
        }

        [Test]
        public void Test9()
        {
            steps.OpenPage();
            steps.SetTypeDates("1.2.2018", "28.2.2018", "round");
            steps.SetCityes("Минск, Беларусь", "Лос-Анджелес, США, International");
            steps.DecreasePass();
            steps.Submit();
            Assert.IsTrue(steps.GetErrorAdult("Укажите число пассажиров"));
        }

        [Test]
        public void Test10()
        {
            steps.OpenPage();
            steps.SetTypeDates("1.2.2018", "28.2.2018", "round");
            steps.SetCityes("Минск, Беларусь", " ");
            steps.DecreasePass();
            steps.Submit();
            Assert.IsTrue(steps.GetErrorAdult("Укажите число пассажиров") && steps.GetErrorCity1("Введите название горда или аэропорта"));
        }
    }
}
