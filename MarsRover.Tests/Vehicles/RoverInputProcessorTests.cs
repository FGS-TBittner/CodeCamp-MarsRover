﻿using MarsRover.Directions;
using MarsRover.Grids;
using MarsRover.Vehicles;
using MarsRover.Vehicles.Commands;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Tests.Vehicles
{
    [TestFixture]
    public class RoverInputProcessorTests : TestsUsingRover
    {
        private int _count;
        private IEnumerable<MovementCommand> _commands;
        private RoverInputProcessor _roverInputProcessor;

        [SetUp]
        public new void SetUp()
        {
            _count = Fixture.Create<int>();
            _roverInputProcessor = new RoverInputProcessor(Rover);
        }

        [TestCaseSource(nameof(CardinalDirections))]
        public void ExecuteCommands_GivenRoverFacingDirectionBackwardNTimes_MovesRoverNSpacesInOppositeDirection(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirectionNMovementCommands(cardinalDirection, MovementCommand.Backward, _count);
            var expected = GetCoordinatesNSpacesInOppositeDirection(Grid, Rover.Coordinates, cardinalDirection, _count);

            _roverInputProcessor.ExecuteCommands(_commands);
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(CardinalDirections))]
        public void ExecuteCommands_GivenRoverFacingDirectionForwardNTimes_MovesRoverNSpacesInDirectionFaced(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirectionNMovementCommands(cardinalDirection, MovementCommand.Forward, _count);
            var expected = GetCoordinatesNSpacesInDirection(Grid, Rover.Coordinates, cardinalDirection, _count);

            _roverInputProcessor.ExecuteCommands(_commands);
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        private Coordinates GetCoordinatesNSpacesInDirection(IGrid grid, Coordinates coordinates,
            CardinalDirection cardinalDirection, int count)
        {
            for (int i = 0; i < count; i++)
                coordinates = GetNextCoordinatesInDirection(grid, coordinates, cardinalDirection);

            return coordinates;
        }

        private Coordinates GetCoordinatesNSpacesInOppositeDirection(IGrid grid, Coordinates coordinates,
            CardinalDirection cardinalDirection, int count)
        {
            for (int i = 0; i < count; i++)
                coordinates = GetNextCoordinatesInOppositeDirection(grid, coordinates, cardinalDirection);

            return coordinates;
        }

        private void GivenRoverFacingDirectionNMovementCommands(CardinalDirection cardinalDirection,
            MovementCommand command, int count)
        {
            GivenRoverFacingDirection(cardinalDirection);
            _commands = Enumerable.Range(0, count).Select(c => command);
        }
    }
}
