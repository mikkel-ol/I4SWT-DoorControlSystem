using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DoorControlSystem.Unit.Test
{
    [TestFixture]
    public class DoorControlUnitTest
    {
        private DoorControl uut = null;

        [SetUp]
        public void Setup()
        {
            IDoor fakeDoor = new FakeDoor();
            IEntryNotification fakEntryNotification = new FakeEntryNotification();
            IUserValidation fakeUserValidation = new FakeUserValidation();

            uut = new DoorControl(fakeDoor, fakEntryNotification, fakeUserValidation);
        }

        [Test]
        public void RequestEntry_CallingValidateEntryRequestCorrectId_CalledCorrectly()
        {
            FakeDoor fakeDoor2 = new FakeDoor();
            FakeEntryNotification fakEntryNotification2 = new FakeEntryNotification();
            FakeUserValidation fakeUserValidation2 = new FakeUserValidation();
            DoorControl uut2 = new DoorControl(fakeDoor2, fakEntryNotification2, fakeUserValidation2);

            fakeUserValidation2.SetCorrectIDForTest("CorrectID");
            uut2.RequestEntry("CorrectID");

            Assert.That(fakeUserValidation2.GetWasIDCorrectForTest(), Is.EqualTo(true));
        }

        [Test]
        public void RequestEntry_CallingValidateEntryRequestWrongId_NotCalled()
        {
            FakeDoor fakeDoor2 = new FakeDoor();
            FakeEntryNotification fakEntryNotification2 = new FakeEntryNotification();
            FakeUserValidation fakeUserValidation2 = new FakeUserValidation();
            DoorControl uut2 = new DoorControl(fakeDoor2, fakEntryNotification2, fakeUserValidation2);

            fakeUserValidation2.SetCorrectIDForTest("CorrectID");
            uut2.RequestEntry("WrongID");

            Assert.That(fakeUserValidation2.GetWasIDCorrectForTest(), Is.EqualTo(false));

        }

        [Test]
        public void RequestEntry_CallingOpenCorrectID_CorrectlyCalled()
        {
            FakeDoor fakeDoor2 = new FakeDoor();
            FakeEntryNotification fakEntryNotification2 = new FakeEntryNotification();
            FakeUserValidation fakeUserValidation2 = new FakeUserValidation();
            DoorControl uut2 = new DoorControl(fakeDoor2, fakEntryNotification2, fakeUserValidation2);
            fakeUserValidation2.SetCorrectIDForTest("CorrectID");

            uut2.RequestEntry("CorrectID");

            Assert.That(fakeDoor2.GetHasDoorOpenBeenCalled(), Is.EqualTo(true));
        }

        [Test]
        public void RequestEntry_CallingOpenWrongID_CorrectlyNotCalled()
        {
            FakeDoor fakeDoor2 = new FakeDoor();
            FakeEntryNotification fakEntryNotification2 = new FakeEntryNotification();
            FakeUserValidation fakeUserValidation2 = new FakeUserValidation();
            DoorControl uut2 = new DoorControl(fakeDoor2, fakEntryNotification2, fakeUserValidation2);
            fakeUserValidation2.SetCorrectIDForTest("CorrectID");

            uut2.RequestEntry("WrongID");

            Assert.That(fakeDoor2.GetHasDoorOpenBeenCalled(), Is.EqualTo(false));
        }

        [Test]
        public void RequestEntry_CallingNotifyEntryGrantedCorrectID_CorrectlyCalled()
        {
            FakeDoor fakeDoor2 = new FakeDoor();
            FakeEntryNotification fakeEntryNotification2 = new FakeEntryNotification();
            FakeUserValidation fakeUserValidation2 = new FakeUserValidation();
            DoorControl uut2 = new DoorControl(fakeDoor2, fakeEntryNotification2, fakeUserValidation2);
            fakeUserValidation2.SetCorrectIDForTest("CorrectID");

            uut2.RequestEntry("CorrectID");

            Assert.That(fakeEntryNotification2.Test_HasNotifyEntryGrantedCalled, Is.EqualTo(true));
        }

        [Test]
        public void RequestEntry_CallingNotifyEntryGrantedWrongID_CorrectlyNotCalled()
        {
            FakeDoor fakeDoor2 = new FakeDoor();
            FakeEntryNotification fakeEntryNotification2 = new FakeEntryNotification();
            FakeUserValidation fakeUserValidation2 = new FakeUserValidation();
            DoorControl uut2 = new DoorControl(fakeDoor2, fakeEntryNotification2, fakeUserValidation2);
            fakeUserValidation2.SetCorrectIDForTest("CorrectID");

            uut2.RequestEntry("WrongID");

            Assert.That(fakeEntryNotification2.Test_HasNotifyEntryGrantedCalled, Is.EqualTo(false));
        }

        [Test]
        public void DoorOpen_CallingClose_CloseCalledCorrectly()
        {
            FakeDoor fakeDoor2 = new FakeDoor();
            FakeEntryNotification fakeEntryNotification2 = new FakeEntryNotification();
            FakeUserValidation fakeUserValidation2 = new FakeUserValidation();
            DoorControl uut2 = new DoorControl(fakeDoor2, fakeEntryNotification2, fakeUserValidation2);
 
            uut2.DoorOpen();
            
            Assert.That(fakeDoor2.GetHasDoorCloseBeenCalled, Is.EqualTo(true));
        }
    }
}
