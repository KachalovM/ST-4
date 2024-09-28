using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_InitialState_IsLocked()
        {
            var bugPro = new BugPro();
            Assert.AreEqual(BugPro.State.Locked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_InsertCoin_ChangesStateToUnlocked()
        {
            var bugPro = new BugPro();
            bugPro.InsertCoin();
            Assert.AreEqual(BugPro.State.Unlocked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_Push_InLockedState_DoesNotChangeState()
        {
            var bugPro = new BugPro();
            bugPro.Push();
            Assert.AreEqual(BugPro.State.Locked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_Push_InUnlockedState_ChangesStateToLocked()
        {
            var bugPro = new BugPro();
            bugPro.InsertCoin();
            bugPro.Push();
            Assert.AreEqual(BugPro.State.Locked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_MultipleCoins_DoesNotChangeStateFromUnlocked()
        {
            var bugPro = new BugPro();
            bugPro.InsertCoin();
            bugPro.InsertCoin();
            Assert.AreEqual(BugPro.State.Unlocked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_MultiplePushes_DoesNotChangeStateFromLocked()
        {
            var bugPro = new BugPro();
            bugPro.Push();
            bugPro.Push();
            Assert.AreEqual(BugPro.State.Locked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_TransitionSequence_LockedToUnlockedAndBack()
        {
            var bugPro = new BugPro();
            bugPro.InsertCoin();
            Assert.AreEqual(BugPro.State.Unlocked, bugPro.CurrentState);
            bugPro.Push();
            Assert.AreEqual(BugPro.State.Locked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_FireInvalidTrigger_DoesNotThrowException()
        {
            var bugPro = new BugPro();
            bugPro.Push();
            Assert.AreEqual(BugPro.State.Locked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_InsertCoin_WhenAlreadyUnlocked_DoesNothing()
        {
            var bugPro = new BugPro();
            bugPro.InsertCoin();
            bugPro.InsertCoin();
            Assert.AreEqual(BugPro.State.Unlocked, bugPro.CurrentState);
        }

        [TestMethod]
        public void Test_Push_WithoutInsertingCoin_RemainsLocked()
        {
            var bugPro = new BugPro();
            bugPro.Push();
            Assert.AreEqual(BugPro.State.Locked, bugPro.CurrentState);
        }
    }
}