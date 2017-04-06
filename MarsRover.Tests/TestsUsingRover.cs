﻿using MarsRover.Directions;
using MarsRover.Grids;
using MarsRover.Vehicles;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Collections.Generic;

namespace MarsRover.Tests
{
    [TestFixture]
    public class TestsUsingRover : TestsUsingGrid
    {
        protected Rover Rover { get; set; }

        [SetUp]
        public new void SetUp()
        {
            Rover = Fixture.CreateRover(Grid);
        }

        protected static IEnumerable<CardinalDirection> CardinalDirections()
        {
            yield return CardinalDirection.East;
            yield return CardinalDirection.North;
            yield return CardinalDirection.South;
            yield return CardinalDirection.West;
        }

        protected Coordinates GetNextCoordinatesInDirection(IGrid grid, Coordinates coordinates,
            CardinalDirection cardinalDirection)
        {
            if (cardinalDirection == CardinalDirection.East)
                return grid.GetNextCoordinatesEast(coordinates);
            else if (cardinalDirection == CardinalDirection.North)
                return grid.GetNextCoordinatesNorth(coordinates);
            else if (cardinalDirection == CardinalDirection.South)
                return grid.GetNextCoordinatesSouth(coordinates);
            else
                return grid.GetNextCoordinatesWest(coordinates);
        }

        protected Coordinates GetNextCoordinatesInOppositeDirection(IGrid grid, Coordinates coordinates,
            CardinalDirection cardinalDirection)
        {
            if (cardinalDirection == CardinalDirection.East)
                return grid.GetNextCoordinatesWest(coordinates);
            else if (cardinalDirection == CardinalDirection.North)
                return grid.GetNextCoordinatesSouth(coordinates);
            else if (cardinalDirection == CardinalDirection.South)
                return grid.GetNextCoordinatesNorth(coordinates);
            else
                return grid.GetNextCoordinatesEast(coordinates);
        }

        protected void GivenRoverFacingDirection(CardinalDirection cardinalDirection)
        {
            Rover.Direction = DirectionFactory.GetDirection(cardinalDirection, Grid);
        }
    }
}
