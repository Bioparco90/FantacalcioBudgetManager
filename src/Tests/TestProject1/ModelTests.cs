using Model;

namespace TestProject1
{
    [TestClass]
    public class ModelTests
    {
        //    public static void TestModels<T>(Action<T> action) where T : Player, new()
        //    {
        //        T player = new()
        //        {
        //            Name = "Foo",
        //            Price = 1,
        //        };

        //        Assert.AreEqual("Foo", player.Name);
        //        Assert.AreEqual(1, player.Price);
        //        action(player);

        //    }

        //    [TestMethod]
        //    public void GKs() => TestModels<Goalkeeper>(p => Assert.AreEqual(3, p.MaxPerTeam));

        //    [TestMethod]
        //    public void DEFs() => TestModels<Defender>(p => Assert.AreEqual(8, p.MaxPerTeam));

        //    [TestMethod]
        //    public void MIDs() => TestModels<Midfielder>(p => Assert.AreEqual(8, p.MaxPerTeam));

        //    [TestMethod]
        //    public void FWs() => TestModels<Forward>(p => Assert.AreEqual(6, p.MaxPerTeam));

        //    [TestMethod]
        //    public void CheckType() => TestModels<Midfielder>(Assert.IsInstanceOfType<Midfielder>);

        //    [TestMethod]
        //    public void CheckTypeWrong() => TestModels<Midfielder>(Assert.IsNotInstanceOfType<Forward>);

        //    private static void TeamCreation(Action<Team> action)
        //    {
        //        Team team = new Team()
        //        {
        //            Name = "Foo",
        //        };

        //        action(team);
        //    }



        //    [TestMethod]
        //    public void CheckAddingPlayerToList()
        //    {
        //        TeamCreation(t =>
        //        {
        //            Goalkeeper g1 = new()
        //            {
        //                Name = "Foo",
        //                Price = 2,
        //            };

        //            Logics logic = new(t);

        //            Assert.IsTrue(logic.AddGoalkeeper(g1));
        //        });
        //    }

        //    [TestMethod]
        //    public void CheckAddingMultiplePlayersToList()
        //    {
        //        TeamCreation(t =>
        //        {
        //            Goalkeeper g1 = new()
        //            {
        //                Name = "Foo1",
        //                Price = 2,
        //            };
        //            Goalkeeper g2 = new()
        //            {
        //                Name = "Foo2",
        //                Price = 2,
        //            };
        //            Goalkeeper g3 = new()
        //            {
        //                Name = "Foo3",
        //                Price = 2,
        //            };
        //            Logics logic = new(t);

        //            Assert.IsTrue(logic.AddGoalkeeper(g1));
        //            Assert.IsTrue(logic.AddGoalkeeper(g2));
        //            Assert.IsTrue(logic.AddGoalkeeper(g3));
        //        });
        //    }

        //    [TestMethod]
        //    public void CheckAddingMultiplePlayersToListFails()
        //    {
        //        TeamCreation(t =>
        //        {
        //            Goalkeeper g1 = new()
        //            {
        //                Name = "Foo1",
        //                Price = 2,
        //            };
        //            Goalkeeper g2 = new()
        //            {
        //                Name = "Foo2",
        //                Price = 2,
        //            };
        //            Goalkeeper g3 = new()
        //            {
        //                Name = "Foo3",
        //                Price = 2,
        //            };
        //            Goalkeeper g4 = new()
        //            {
        //                Name = "Foo4",
        //                Price = 2,
        //            };

        //            Logics logic = new(t);

        //            Assert.IsTrue(logic.AddGoalkeeper(g1));
        //            Assert.IsTrue(logic.AddGoalkeeper(g2));
        //            Assert.IsTrue(logic.AddGoalkeeper(g3));
        //            Assert.IsFalse(logic.AddGoalkeeper(g4));
        //        });
        //    }

        //    [TestMethod]
        //    public void GetPlayersPerRole()
        //    {
        //        TeamCreation(t =>
        //        {
        //            Goalkeeper g1 = new()
        //            {
        //                Name = "Foo1",
        //                Price = 2,
        //            };
        //            Goalkeeper g2 = new()
        //            {
        //                Name = "Foo2",
        //                Price = 2,
        //            };
        //            Goalkeeper g3 = new()
        //            {
        //                Name = "Foo3",
        //                Price = 2,
        //            };

        //            Logics logic = new(t);

        //            logic.AddGoalkeeper(g1);
        //            logic.AddGoalkeeper(g2);
        //            logic.AddGoalkeeper(g3);

        //            var count = t.Goalkeepers.Count;
        //            Assert.AreEqual(3, count);

        //            t.Goalkeepers.ForEach(g => Debug.WriteLine(g.Name));
        //        });
        //    }
    }
}
