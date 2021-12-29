using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SystemAlarmClock;

namespace TESTINGPROGRAMM
{
    [TestClass]
    public class TestingCheckingForTransfer
    {
        /// <summary>
        /// Проверка переноса на 10 мин.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            MessageCustom messageCustom = new MessageCustom();

            Assert.IsTrue(messageCustom.checkingForTransfer("10.10.2010 14:22:10", 
                                                            "10.10.2010 14:20:10"));
        }

        /// <summary>
        /// Проверка переноса на 10 мин.
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            MessageCustom messageCustom = new MessageCustom();

            Assert.IsFalse(messageCustom.checkingForTransfer("10.10.2010 14:20:10",
                                                            "10.10.2010 14:28:10"));
        }

        /// <summary>
        /// Правильность выполнения данного теста говорит нам о том, что при совпадении времени
        /// события и времени напоминания напоминание так же будет перенесено на 10 минут 
        /// (ЛОГИКУ НЕ НАРУШАЕТ!)
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            MessageCustom messageCustom = new MessageCustom();

            Assert.IsFalse(messageCustom.checkingForTransfer("10.10.2010 14:20:10",
                                                            "10.10.2010 14:20:10"));
        }
    }

    [TestClass]
    public class TestingCalculatingReminderTime
    {
        /// <summary>
        /// проверка на вычисление времени напоминания
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            fmAddEvent AddEvent = new fmAddEvent();

            Assert.AreEqual(AddEvent.countingReminderTime("10.10.2010 14:22", 1, 1),
                                                          "9.10.2010 13:22");
            
        }

        /// <summary>
        /// проверка на вычисление времени напоминания
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            fmAddEvent AddEvent = new fmAddEvent();

            Assert.AreEqual(AddEvent.countingReminderTime("10.10.2010 14:22", 0, 1),
                                                          "10.10.2010 13:22");

        }

        /// <summary>
        /// проверка на вычисление времени напоминания
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            fmAddEvent AddEvent = new fmAddEvent();

            Assert.AreEqual(AddEvent.countingReminderTime("10.10.2010 14:22", 1, 0),
                                                          "9.10.2010 14:22");

        }

        /// <summary>
        /// проверка на вычисление времени напоминания
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            fmAddEvent AddEvent = new fmAddEvent();

            Assert.AreEqual(AddEvent.countingReminderTime("10.10.2010 14:22", 11, 0),
                                                          "29.9.2010 14:22");

        }

        /// <summary>
        /// проверка на вычисление времени напоминания
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            fmAddEvent AddEvent = new fmAddEvent();

            Assert.AreEqual(AddEvent.countingReminderTime("10.10.2010 14:22", 10, 0),
                                                          "30.9.2010 14:22");

        }

        /// <summary>
        /// проверка на вычисление времени напоминания
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            fmAddEvent AddEvent = new fmAddEvent();

            Assert.AreEqual(AddEvent.countingReminderTime("10.01.2010 14:22", 11, 0),
                                                          "30.12.2009 14:22");

        }

        /// <summary>
        /// проверка на вычисление времени напоминания
        /// </summary>
        [TestMethod]
        public void TestMethod7()
        {
            fmAddEvent AddEvent = new fmAddEvent();

            Assert.AreEqual(AddEvent.countingReminderTime("10.01.2010 14:22", 10, 15),
                                                          "30.12.2009 23:22");

        }
    }

    //[TestClass]
    //public class TestingMessageCustom
    //{

    //    [TestMethod]
    //    public void TestMethod1()
    //    {
    //        MessageCustom mC = new MessageCustom("День рождения у Поли",
    //                                                     "30.12.2009 23:22",
    //                                                     false);
    //        mC.Show();
    //        Assert.AreEqual(mC.Text, "Напонимание о событии");

    //    }
    //}



}
