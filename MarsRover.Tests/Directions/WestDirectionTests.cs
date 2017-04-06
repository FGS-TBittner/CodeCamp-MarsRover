﻿using MarsRover.Directions;
using NUnit.Framework;

namespace MarsRover.Tests.Directions
{
    [TestFixture]
    public class WestDirectionTests : TestsUsingRover
    {
        private WestDirection _direction;

        [SetUp]
        public new void SetUp()
        {
            _direction = new WestDirection(Grid);
        }

        [Test]
        public void MoveBackward_GivenRover_MovesRoverEast()
        {
            var expected = Grid.GetNextCoordinatesEast(Rover.Coordinates);

            _direction.MoveBackward(Rover);

            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        [Test]
        public void MoveForward_GivenRover_MovesRoverWest()
        {
            var expected = Grid.GetNextCoordinatesWest(Rover.Coordinates);

            _direction.MoveForward(Rover);
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }
    }
}
