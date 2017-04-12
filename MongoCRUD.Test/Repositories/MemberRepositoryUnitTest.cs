using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoCRUD.Core.Repositories;
using MongoCRUD.Core.Pocos;

namespace MongoCRUD.Test.Repositories
{
    [TestClass]
    public class MemberRepositoryUnitTest
    {
        [IgnoreAttribute]
        [TestMethod]
        public void MemberRepository_GetAll()
        {
            var data = MemberRepository.Instance.Get();

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count > 0);
        }

        [IgnoreAttribute]
        [TestMethod]
        public void MemberRepository_Get()
        {
            var id = "58ee3339e8ebb446cbb47afc";
            var data = MemberRepository.Instance.Get(id);

            Assert.IsNotNull(data);
            Assert.AreEqual(data.Balance, 0.12345M);
        }
        [IgnoreAttribute]
        [TestMethod]
        public void MemberRepository_Update()
        {
            var id = "58dd45ae819dff4bfccc144a";
            var member = MemberRepository.Instance.Get(id);
            var oriBalance = member.Balance;
            member.Balance = DateTime.Now.Millisecond;

            var data = MemberRepository.Instance.Update(member);

            Assert.IsNotNull(data);
            Assert.AreEqual(data.MatchedCount, 1);
            Assert.AreEqual(data.ModifiedCount, 1);
        }
        [IgnoreAttribute]
        [TestMethod]
        public void MemberRepository_UpdateAndFitch()
        {
            var id = "58dd45ae819dff4bfccc144a";
            var member = MemberRepository.Instance.Get(id);
            var oriBalance = member.Balance;
            member.Balance = DateTime.Now.Millisecond;

            var data = MemberRepository.Instance.UpdateAndFitch(member);

            Assert.IsNotNull(data);
            Assert.AreNotEqual(data.Balance, oriBalance);
        }

        //[IgnoreAttribute]
        [TestMethod]
        public void MemberRepository_Insert()
        {
            var member = new Member()
            {
                Name = string.Format("Blackie_{0}", DateTime.Now.ToString("yyyymmddhhmmss")),
                Balance = 0.12345678987654321M
            };

            MemberRepository.Instance.Insert(member);
        }

        [IgnoreAttribute]
        [TestMethod]
        public void MemberRepository_Delete()
        {
            var id = "58ea5f2d040ff069f1518b16";
            var data = MemberRepository.Instance.Delete(id);

            Assert.IsNotNull(data);
            Assert.AreEqual(data.DeletedCount, 1);
        }
    }
}
