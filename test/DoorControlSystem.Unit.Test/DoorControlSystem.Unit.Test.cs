using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace DoorControlSystem.Unit.Test
{
    [TestFixture]
    public class DoorControlUnitTest
    {
        private DoorControl uut = null;
        private IAlarm _alarm = null;
        private IDoor _door = null;
        private IUserValidation _userValidation = null;
        private IEntryNotification _entryNotification = null;

        [SetUp]
        public void Setup()
        {
            _alarm = Substitute.For<IAlarm>();
            _door = Substitute.For<IDoor>();
            _userValidation = Substitute.For<IUserValidation>();
            _entryNotification = Substitute.For<IEntryNotification>();
            uut = new DoorControl(_door, _entryNotification, _userValidation);
        }

        [Test]
        public void RequestEntry_CallingDoorOpenCorrectID_CalledCorrectly()
        {
            _userValidation.ValidateEntryRequest("ID").Returns(true);

            uut.RequestEntry("ID");


            _door.Received().Open();
        }

        [Test]
        public void RequestEntry_CallingDoorOpenWrongID_OpenNotCalled()
        {
            _userValidation.ValidateEntryRequest("WrongID").Returns(false);

            uut.RequestEntry("WrongID");


            _door.DidNotReceive().Open();
        }

        [Test]
        public void RequestEntry_CallNotifyEntryGrantedCorrectID_MethodCalled()
        {
            _userValidation.ValidateEntryRequest("ID").Returns(true);

            uut.RequestEntry("ID");

            _entryNotification.Received().NotifyEntryGranted();
        }

        [Test]
        public void RequestEntry_CallNotifyEntryGrantedWrongID_MethodNotCalled()
        {
            _userValidation.ValidateEntryRequest("WrongID").Returns(false);

            uut.RequestEntry("WrongID");

            _entryNotification.DidNotReceive().NotifyEntryGranted();
        }


        [Test]
        public void DoorOpen_CallClose_CloseCalled()
        {

            uut.DoorOpen();

            _door.Received().Close();
        }

        //
        //  OLD HANDWRITTEN TESTS
        //
        /*
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
        }*/
    }
}
