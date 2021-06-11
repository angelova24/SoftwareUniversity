namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            this.fish = new Fish("Fish");
            this.aquarium = new Aquarium("Correct", 2);
        }

        [Test]
        public void NameShouldSetCorrectly()
        {
            Assert.AreEqual("Correct", aquarium.Name);
        }

        [Test]
        public void NameShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10));
        }

        [Test]
        public void CapacityShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Correct", -1));
        }

        [Test]
        public void CapacityShouldSetCorrectly()
        {
            Assert.AreEqual(2, this.aquarium.Capacity);
        }

        [Test]
        public void CountShouldSetCorrectly()
        {
            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfIsFull()
        {
            this.aquarium = new Aquarium("Correct", 1);
            this.aquarium.Add(new Fish("Fish"));

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish("Fish2")));
        }

        [Test]
        public void RemoveShouldThrowArgumentExceptionIfFishDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Doesntexists"));
        }

        [Test]
        public void RemoveFishShouldRemoveCorrectly()
        {

            this.aquarium.Add(this.fish);

            this.aquarium.RemoveFish("Fish");

            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void SellFishShouldThrowArgumentExceptionIfFishDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Incorrect"));
        }

        [Test]
        public void SellFishShouldSellCorrectly()
        {
            this.aquarium.Add(fish);

            var targetFish = this.aquarium.SellFish("Fish");

            Assert.AreEqual(targetFish, fish);
        }

        [Test]
        public void SellFishShouldSetAvailableCorrectly()
        {
            this.aquarium.Add(fish);

            var targetFish = this.aquarium.SellFish("Fish");

            Assert.IsFalse(targetFish.Available);
        }

        [Test]
        public void Test_Report()
        {
            var anotherFish = new Fish("Memo");

            aquarium.Add(fish);
            aquarium.Add(anotherFish);

            string expectedMeassege = $"Fish available at {aquarium.Name}: {fish.Name}, {anotherFish.Name}";

            Assert.That(aquarium.Report(), Is.EqualTo(expectedMeassege));

        }
    }
}
