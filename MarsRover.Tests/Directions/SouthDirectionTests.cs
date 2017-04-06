﻿using MarsRover.Directions;
using NUnit.Framework;

namespace MarsRover.Tests.Directions
{
    [TestFixture]
    public class SouthDirectionTests : TestsUsingRover
    {
        private SouthDirection _direction;

        [SetUp]
        public new void SetUp()
        {
            _direction = new SouthDirection(Grid);
        }

        [Test]
        public void MoveBackward_GivenRover_MovesRoverNorth()
        {
            var expected = Grid.GetNextCoordinatesNorth(Rover.Coordinates);

            _direction.MoveBackward(Rover);

            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        [Test]
        public void MoveForward_GivenRover_MovesRoverSouth()
        {
            var expected = Grid.GetNextCoordinatesSouth(Rover.Coordinates);

            _direction.MoveForward(Rover);
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }
    }
}
